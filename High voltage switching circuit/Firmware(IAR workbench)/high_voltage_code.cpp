#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include "stm32f4xx.h"

// bool type definition
typedef enum
{
    false = 0,
    true = !false
} bool;

// PC -> Controller data struc
typedef struct
{
    int Start_Bit; // it is set 250
    int Com_Bit;   // 1 = DAC, 2 = CH1, 3 = CH2
    int Pin1_Bit;  // DATA 1-1 or SELECTION (1,2,3) that is only used when Com_Bit is 2,3 .( 1 = HIGH VOLTAGE ON, 2 = HIGH VOLTAGE OFF, 3 = HIGH VOLTAGE OFF or  DYNAMIC VOLTGAE(FLICKER BY FREQUENCY)) 
    int Pin2_Bit;  // DATA 1-2(DATA 1-1, 1-2 IS SET. ex) 2020 --> pin1 = 20, pin2 =20 (data type is BYTE)
    int Pin3_Bit;  // DATA 2-1
    int Pin4_Bit;  // DATA 2-2
    int Stop_Bit;  // it is set 251
} DataPacket;

DataPacket rdata;

void Init_rdata()
{ // Received data
    rdata.Start_Bit = 0;
    rdata.Com_Bit = 0;
    rdata.Pin1_Bit = 0;
    rdata.Pin2_Bit = 0;
    rdata.Pin3_Bit = 0;
    rdata.Pin4_Bit = 0;
    rdata.Stop_Bit = 0;
}

void ALL_Actuator_Set(void);
void ALL_Actuator_Time_measurement(void);

int ch1_time = 0; // working time(set value by frequency(dynamic value))
int ch2_time = 0;
int idle_time = 0;
int ch1_count = 0; // count for timer
int ch2_count = 0;
int idle_count = 0;
int recv_buffer[7];     // PC->Controller로 받을 data buffer
int Parsing_send_i = 0; // Contorller->PC data order
int Parsing_recv_i = 0; // PC->Controller data order

int ch1_mode = 0; // 0 = not use, 1 = use static ,2 = use dynamic
int ch2_mode = 0;
bool ch1_work_state = false; // working state
bool ch2_work_state = false;

bool ch1_off_state = false; // control variable(CH1's off state), only one activation
bool ch2_off_state = false;

bool ch1_on_state = false; // control variable(CH1's on state), only one activation
bool ch2_on_state = false;

// DAC control (high voltage switch circuit control)
int ch1_dac_value = -1;
int ch2_dac_value = -1;

// Dynamic Value Buffer
int ch1_dynamic_value = -1; // Frequency
int ch2_dynamic_value = -1;

void Init_TIM2()
{
    uint16_t PrescalerValue;

    TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;

    NVIC_InitTypeDef NVIC_InitStructure;
    NVIC_InitStructure.NVIC_IRQChannel = TIM2_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x0f;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x0f;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);

    RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);

    SystemCoreClockUpdate();
    PrescalerValue = 419;
    TIM_TimeBaseStructure.TIM_Period = 19;

    TIM_TimeBaseStructure.TIM_Prescaler = PrescalerValue;
    TIM_TimeBaseStructure.TIM_ClockDivision = 0;
    TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

    TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);

    /* TIM IT enable */
    TIM_ITConfig(TIM2, TIM_IT_Update, ENABLE);

    /* TIMX enable counter */
    TIM_Cmd(TIM2, ENABLE);
}

void Init_TIM3()
{
    uint16_t PrescalerValue;

    TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;

    NVIC_InitTypeDef NVIC_InitStructure;
    NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x0f;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x0f;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);

    RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);

    SystemCoreClockUpdate();
    PrescalerValue = 419;
    TIM_TimeBaseStructure.TIM_Period = 19;

    TIM_TimeBaseStructure.TIM_Prescaler = PrescalerValue;
    TIM_TimeBaseStructure.TIM_ClockDivision = 0;
    TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

    TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);

    /* TIM IT enable */
    TIM_ITConfig(TIM3, TIM_IT_Update, ENABLE);

    /* TIMX enable counter */
    TIM_Cmd(TIM3, ENABLE);
}

void Init_TIM4()
{
    uint16_t PrescalerValue;

    TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;

    NVIC_InitTypeDef NVIC_InitStructure;
    NVIC_InitStructure.NVIC_IRQChannel = TIM4_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x0f;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x0f;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);

    RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM4, ENABLE);

    SystemCoreClockUpdate();
    PrescalerValue = 419;
    TIM_TimeBaseStructure.TIM_Period = 19;

    TIM_TimeBaseStructure.TIM_Prescaler = PrescalerValue;
    TIM_TimeBaseStructure.TIM_ClockDivision = 0;
    TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

    TIM_TimeBaseInit(TIM4, &TIM_TimeBaseStructure);

    /* TIM IT enable */
    TIM_ITConfig(TIM4, TIM_IT_Update, ENABLE);

    /* TIMX enable counter */
    TIM_Cmd(TIM4, ENABLE);
}

void Init_USART1(void)
{

    GPIO_InitTypeDef GPIO_InitStructure;
    USART_InitTypeDef USART_InitStructure;
    NVIC_InitTypeDef NVIC_InitStructure;

    // Enable peripheral
    RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1, ENABLE);

    // Configure USART Interrupt
    NVIC_InitStructure.NVIC_IRQChannel = USART1_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0x0f;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0x0f;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);

    // GPIO AF config
    GPIO_PinAFConfig(GPIOA, GPIO_PinSource9, GPIO_AF_USART1);
    GPIO_PinAFConfig(GPIOA, GPIO_PinSource10, GPIO_AF_USART1);

    // Configure GPIO(UART TX/RX)
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_9; // USART TX Pin Number
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
    GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_Init(GPIOA, &GPIO_InitStructure);

    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10; // USART RX Pin Number
    GPIO_Init(GPIOA, &GPIO_InitStructure);

    // Configure UART peripheral
    USART_InitStructure.USART_BaudRate = 115200; // Baudrate
    USART_InitStructure.USART_WordLength = USART_WordLength_8b;
    USART_InitStructure.USART_StopBits = USART_StopBits_1;
    USART_InitStructure.USART_Parity = USART_Parity_No;
    USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
    USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;

    USART_Init(USART1, &USART_InitStructure);

    // Enable USART receive interrupt
    USART_ITConfig(USART1, USART_IT_RXNE, ENABLE);

    USART_Cmd(USART1, ENABLE);
}

void Init_DAC1_PA4()
{

    GPIO_InitTypeDef GPIO_InitStructure;
    DAC_InitTypeDef DAC_InitStructure;
    /* GPIOA clock enable (to be used with DAC) */
    RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
    /* DAC Periph clock enable */
    RCC_APB1PeriphClockCmd(RCC_APB1Periph_DAC, ENABLE);

    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_4;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AN;
    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;

    GPIO_Init(GPIOA, &GPIO_InitStructure);

    DAC_InitStructure.DAC_Trigger = DAC_Trigger_None;
    DAC_InitStructure.DAC_WaveGeneration = DAC_WaveGeneration_None;
    DAC_InitStructure.DAC_OutputBuffer = DAC_OutputBuffer_Enable;
    DAC_InitStructure.DAC_LFSRUnmask_TriangleAmplitude = DAC_TriangleAmplitude_4095;
    DAC_Init(DAC_Channel_1, &DAC_InitStructure);

    DAC_SetChannel1Data(DAC_Align_12b_R, 0);
    DAC_Cmd(DAC_Channel_1, ENABLE);
}

void Init_DAC2_PA5()
{
    GPIO_InitTypeDef GPIO_InitStructure;
    DAC_InitTypeDef DAC_InitStructure;
    /* GPIOA clock enable (to be used with DAC) */
    RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
    /* DAC Periph clock enable */
    RCC_APB1PeriphClockCmd(RCC_APB1Periph_DAC, ENABLE);

    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_5;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AN;
    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;

    GPIO_Init(GPIOA, &GPIO_InitStructure);

    DAC_InitStructure.DAC_Trigger = DAC_Trigger_None;
    DAC_InitStructure.DAC_WaveGeneration = DAC_WaveGeneration_None;
    DAC_InitStructure.DAC_OutputBuffer = DAC_OutputBuffer_Enable;
    DAC_InitStructure.DAC_LFSRUnmask_TriangleAmplitude = DAC_TriangleAmplitude_4095;
    DAC_Init(DAC_Channel_2, &DAC_InitStructure);

    DAC_SetChannel2Data(DAC_Align_12b_R, 0);
    DAC_Cmd(DAC_Channel_2, ENABLE);
}

void Init_GPIO_D()
{
    GPIO_InitTypeDef GPIO_InitStructure;
    RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_8 | GPIO_Pin_10 | GPIO_Pin_12 | GPIO_Pin_14;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
    GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
    GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;

    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
    GPIO_Init(GPIOD, &GPIO_InitStructure);
}

int main()
{
    Init_TIM2();
    Init_TIM3();
    Init_TIM4();
    Init_USART1();
    Init_DAC1_PA4();
    Init_DAC2_PA5();
    Init_GPIO_D();
    while (1)
    {
    }
}

void TIM2_IRQHandler(void) // Set  DAC  Value
{
    if (TIM_GetITStatus(TIM2, TIM_IT_Update) == SET)
    {
        TIM_ClearITPendingBit(TIM2, TIM_IT_Update);
        if (ch1_dac_value != -1 && ch1_dac_value >= 0 && ch1_dac_value <= 4095)
        {
            DAC_SetChannel1Data(DAC_Align_12b_R, ch1_dac_value);
            ch1_dac_value = -1;
        }
        if (ch2_dac_value != -1 && ch2_dac_value >= 0 && ch2_dac_value <= 4095)
        {
            DAC_SetChannel2Data(DAC_Align_12b_R, ch2_dac_value);
            ch2_dac_value = -1;
        }
    }
}

void TIM3_IRQHandler(void) // ch1
{
    if (TIM_GetITStatus(TIM3, TIM_IT_Update) == SET)
    {
        TIM_ClearITPendingBit(TIM3, TIM_IT_Update);
        if (ch1_work_state == true && ch1_off_state == false)
        {
            if (ch1_mode == 0)
            {
                GPIO_WriteBit(GPIOD, GPIO_Pin_12, Bit_RESET);
                GPIO_WriteBit(GPIOD, GPIO_Pin_14, Bit_RESET);
                ch1_off_state = true;
            }
            else if (ch1_mode == 1 && ch1_on_state == false)
            {
                GPIO_WriteBit(GPIOD, GPIO_Pin_12, Bit_SET);
                ch1_on_state = true;
            }
            else if (ch1_mode == 2)
            {
                if (ch1_count == 0)
                {
                    GPIO_WriteBit(GPIOD, GPIO_Pin_12, Bit_SET);
                }
                else if (ch1_count == ch1_time)
                {
                    GPIO_WriteBit(GPIOD, GPIO_Pin_12, Bit_RESET);
                }
                else if (ch1_count == (ch1_time + idle_time))
                {
                    GPIO_WriteBit(GPIOD, GPIO_Pin_14, Bit_SET);
                }
                else if (ch1_count == (ch1_time * 2 + idle_time))
                {
                    GPIO_WriteBit(GPIOD, GPIO_Pin_14, Bit_RESET);
                }
                else if (ch1_count == ((ch1_time + idle_time) * 2))
                {
                    ch1_count = -1;
                }
                ch1_count++;
            }
        }
    }
}

void TIM4_IRQHandler(void) // ch2
{
    if (TIM_GetITStatus(TIM4, TIM_IT_Update) == SET)
    {
        TIM_ClearITPendingBit(TIM4, TIM_IT_Update);
        if (ch2_work_state == true)
        {
            if (ch2_mode == 0 && ch2_off_state == false)
            {
                GPIO_WriteBit(GPIOD, GPIO_Pin_8, Bit_RESET);
                GPIO_WriteBit(GPIOD, GPIO_Pin_10, Bit_RESET);
                ch2_off_state = true;
            }
            else if (ch2_mode == 1 && ch2_on_state == false)
            {
                GPIO_WriteBit(GPIOD, GPIO_Pin_8, Bit_SET);
                ch2_on_state = true;
            }
            else if (ch2_mode == 2)
            {
                if (ch2_count == 0)
                {
                    GPIO_WriteBit(GPIOD, GPIO_Pin_8, Bit_SET);
                }
                else if (ch2_count == ch2_time)
                {
                    GPIO_WriteBit(GPIOD, GPIO_Pin_8, Bit_RESET);
                }
                else if (ch2_count == (ch2_time + idle_time))
                {
                    GPIO_WriteBit(GPIOD, GPIO_Pin_10, Bit_SET);
                }
                else if (ch2_count == (ch2_time * 2 + idle_time))
                {
                    GPIO_WriteBit(GPIOD, GPIO_Pin_10, Bit_RESET);
                }
                else if (ch2_count == ((ch2_time + idle_time) * 2))
                {
                    ch2_count = -1;
                }
                ch2_count++;
            }
        }
    }
}

void ALL_Actuator_Set(void)
{
    if (rdata.Start_Bit == 250 && rdata.Stop_Bit == 251)
    {
        if (rdata.Com_Bit == 1)
        { // ch1, ch2 DAC set(0~4095)
            ch1_dac_value = rdata.Pin1_Bit * 100 + rdata.Pin2_Bit;
            ch2_dac_value = rdata.Pin3_Bit * 100 + rdata.Pin4_Bit;
        }
        else if (rdata.Com_Bit == 2)
        { // CH1
            if (rdata.Pin1_Bit == 1)
            { // input - static voltage output
                ch1_mode = 1;
                ch1_work_state = true;
            }
            else if (rdata.Pin1_Bit == 2)
            { // output - not use
                ch1_mode = 0;
                ch1_work_state = true;
            }
            else if (rdata.Pin1_Bit == 3)
            { // all stop and initialization or dynamic voltage
                if (rdata.Pin2_Bit == 0 && rdata.Pin3_Bit == 0)
                { // all stop and initialization
                    ch1_mode = 0;
                    ch1_work_state = true;
                }
                if (rdata.Pin2_Bit != 0 || rdata.Pin3_Bit != 0)
                { // dynamic voltage
                    ch1_dynamic_value = rdata.Pin2_Bit * 10 + rdata.Pin3_Bit;
                    idle_time = 10; // timer speed = 10KHz, So, 1ms count is 10
                    ch1_time = (5000 / ch1_dynamic_value) - idle_time;
                    ch1_mode = 2;
                    ch1_work_state = true;
                }
            }
        }
        else if (rdata.Com_Bit == 3)
        { // CH2
            if (rdata.Pin1_Bit == 1)
            { // input - static voltage output
                ch2_mode = 1;
                ch2_work_state = true;
            }
            else if (rdata.Pin1_Bit == 2)
            { // output - not use
                ch2_mode = 0;
                ch2_work_state = true;
            }
            else if (rdata.Pin1_Bit == 3)
            { // all stop and initialization or dynamic voltage
                if (rdata.Pin2_Bit == 0 && rdata.Pin3_Bit == 0)
                { // all stop and initialization
                    ch2_mode = 0;
                    ch2_work_state = true;
                }
                if (rdata.Pin2_Bit != 0 || rdata.Pin3_Bit != 0)
                { // dynamic voltage
                    ch2_dynamic_value = rdata.Pin2_Bit * 10 + rdata.Pin3_Bit;
                    idle_time = 10; // timer speed = 1MHz, So, 1ms count is 1000
                    ch2_time = (5000 / ch2_dynamic_value) - idle_time;
                    ch2_mode = 2;
                    ch2_work_state = true;
                }
            }
        }
    }
}

void USART1_IRQHandler(void) // Data Packet
{
    if (USART_GetITStatus(USART1, USART_IT_RXNE) == SET)
    {
        recv_buffer[Parsing_recv_i] = USART_ReceiveData(USART1);
        if (Parsing_recv_i == 0)
        { // only 250 data received
            rdata.Start_Bit = recv_buffer[Parsing_recv_i];
            ch1_work_state = false;
            ch2_work_state = false;
            ch1_off_state = false;
            ch2_off_state = false;
            ch1_on_state = false;
            ch2_on_state = false;
            ch1_count = 0;
            ch2_count = 0;
        }
        else if (Parsing_recv_i == 1)
        { // com (1~3)
            rdata.Com_Bit = recv_buffer[Parsing_recv_i];
        }
        else if (Parsing_recv_i == 2)
        { // pin1(data1-1)
            rdata.Pin1_Bit = recv_buffer[Parsing_recv_i];
        }
        else if (Parsing_recv_i == 3)
        { // pin2(data1-2)
            rdata.Pin2_Bit = recv_buffer[Parsing_recv_i];
        }
        else if (Parsing_recv_i == 4)
        { // pin3(data2-1)
            rdata.Pin3_Bit = recv_buffer[Parsing_recv_i];
        }
        else if (Parsing_recv_i == 5)
        { // pin4(data2-2)
            rdata.Pin4_Bit = recv_buffer[Parsing_recv_i];
        }
        else if (Parsing_recv_i == 6)
        { // only 251 data received
            rdata.Stop_Bit = recv_buffer[Parsing_recv_i];
            ALL_Actuator_Set();
            Init_rdata();
            Parsing_recv_i = -1;
        }
        Parsing_recv_i++;
    }
}