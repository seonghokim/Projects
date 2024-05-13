using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SerialPort port;
        byte strat_byte = 250;
        byte command_byte = 0;
        byte pin1_byte = 0; 
        byte pin2_byte = 0;
        byte pin3_byte = 0;
        byte pin4_byte = 0;
        byte stop_byte = 251;

        byte[] send_data = new byte[7];

        // CH1에 대한 변수 선언
        bool check_input_ch1 = false;
        bool check_output_ch1 = false;
        bool check_static_using_ch1 = false;
        bool check_dynamic_using_ch1 = false;

        // CH2에 대한 변수 선언
        bool check_input_ch2 = false;
        bool check_output_ch2 = false;
        bool check_static_using_ch2 = false;
        bool check_dynamic_using_ch2 = false;


        private void voltage_enter_Click(object sender, EventArgs e)
        {
            port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            port.Open();

            int DAC_value_CH1 = 0;
            int DAC_value_CH2 = 0;
            int Pin_1 = 0;
            int Pin_2 = 0;
            int Pin_3 = 0;
            int Pin_4 = 0;
            bool check_DAC = false;
            bool check_DAC_CH1 = int.TryParse(voltage_dac_ch1.Text, out DAC_value_CH1);
            bool check_DAC_CH2 = int.TryParse(voltage_dac_ch2.Text, out DAC_value_CH2);

            double tmp1 = Convert.ToDouble(DAC_value_CH1) * 1.24091;//3300v 기준
            //double tmp1 = Convert.ToDouble(DAC_value_CH1) * 0.819;
            DAC_value_CH1 = Convert.ToInt32(tmp1);

            double tmp2 = Convert.ToDouble(DAC_value_CH2) * 1.24091;//3300v 기준
            //double tmp2 = Convert.ToDouble(DAC_value_CH2) * 0.819;//3300v 기준
            DAC_value_CH2 = Convert.ToInt32(tmp2);

            if (voltage_dac_ch1.Text != "" && voltage_dac_ch2.Text != "")
            {
                check_DAC = true;
            }
            else
            {
                check_DAC = false;
            }

            check_DAC = check_DAC && check_DAC_CH1 && check_DAC_CH2;

            if (check_DAC == true)
            {

                if(DAC_value_CH1 >= 0 && DAC_value_CH1 <= 4095 && DAC_value_CH2 >= 0 && DAC_value_CH2 <= 4095)
                {
                    dac_using.BackColor = Color.Red;

                    Pin_1 = DAC_value_CH1 / 100;
                    Pin_2 = DAC_value_CH1 % 100;
                    Pin_3 = DAC_value_CH2 / 100;
                    Pin_4 = DAC_value_CH2 % 100;

                    send_data[0] = strat_byte;
                    send_data[1] = (Byte)1;
                    send_data[2] = Convert.ToByte(Pin_1);
                    send_data[3] = Convert.ToByte(Pin_2);
                    send_data[4] = Convert.ToByte(Pin_3);
                    send_data[5] = Convert.ToByte(Pin_4);
                    send_data[6] = stop_byte;

                    //FA 01 0C 12 0C 12 FB (1V) CH1, CH2

                    port.Write(send_data, 0, 7);
                }
                else
                {
                    MessageBox.Show("입력값이 올바르지 않습니다.  input value : (0~4095)");
                }
            }
            else
            {
                MessageBox.Show("입력값이 올바르지 않습니다.");
            }
           
            port.Close();
        }


        private void voltage_reset_Click(object sender, EventArgs e)
        {
            port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            port.Open();

            send_data[0] = strat_byte;
            send_data[1] = (Byte)1;
            send_data[2] = 0;
            send_data[3] = 0;
            send_data[4] = 0;
            send_data[5] = 0;
            send_data[6] = stop_byte;

            //FA 01 0C 12 0C 12 FB (1V) CH1, CH2

            port.Write(send_data, 0, 7);

            dac_using.BackColor = Color.Transparent;

            port.Close();

        }

        /************************** CHANEL 1 ********************************/

        private void static_input_ch1_Click(object sender, EventArgs e)
        {
            static_input_ch1.BackColor = Color.Red;
            static_input_ch1.ForeColor = Color.White;
            static_output_ch1.BackColor = SystemColors.Control;
            static_output_ch1.ForeColor = SystemColors.ControlText;

            check_input_ch1 = true;
            check_output_ch1 = false;
        }

        private void static_output_ch1_Click(object sender, EventArgs e)
        {
            static_input_ch1.BackColor = SystemColors.Control;
            static_input_ch1.ForeColor = SystemColors.ControlText;
            static_output_ch1.BackColor = Color.Red;
            static_output_ch1.ForeColor = Color.White;

            check_input_ch1 = false;
            check_output_ch1 = true;
        }

        private void static_enter_ch1_Click(object sender, EventArgs e)
        {
            port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            port.Open();

            if (check_input_ch1 == true)
            {
                if (check_dynamic_using_ch1 == false)
                {
                    static_using_ch1.BackColor = Color.Red;
                    check_static_using_ch1 = true;

                    send_data[0] = strat_byte;
                    send_data[1] = (Byte)2;
                    send_data[2] = (Byte)1;
                    send_data[3] = 0;
                    send_data[4] = 0;
                    send_data[5] = 0;
                    send_data[6] = stop_byte;

                    //FA 02 01 00 00 00 FB (in)

                    port.Write(send_data, 0, 7);
                }
                else
                {
                    MessageBox.Show("Dynamic부분을 Off하고 사용해주세요");
                }  
            }
            else if(check_output_ch1 == true)
            {
                if (check_dynamic_using_ch1 == false)
                {
                    static_using_ch1.BackColor = Color.Red;
                    check_static_using_ch1 = true;

                    send_data[0] = strat_byte;
                    send_data[1] = (Byte)2;
                    send_data[2] = (Byte)2;
                    send_data[3] = 0;
                    send_data[4] = 0;
                    send_data[5] = 0;
                    send_data[6] = stop_byte;

                    //FA 02 02 00 00 00 FB(out)

                    port.Write(send_data, 0, 7);
                }
                else
                {
                    MessageBox.Show("Dynamic부분을 Off하고 사용해주세요");
                }

            }
            else
            {
                MessageBox.Show("입력값이 올바르지 않습니다.");
            }

            port.Close();
        }

        private void all_off_ch1_Click(object sender, EventArgs e)
        {
            port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            port.Open();

            static_input_ch1.BackColor = SystemColors.Control;
            static_input_ch1.ForeColor = SystemColors.ControlText;
            static_output_ch1.BackColor = SystemColors.Control;
            static_output_ch1.ForeColor = SystemColors.ControlText;

            static_using_ch1.BackColor = Color.Transparent;
            dynamic_using_ch1.BackColor = Color.Transparent;

            check_input_ch1 = false;
            check_output_ch1 = false;

            check_static_using_ch1 = false;
            check_dynamic_using_ch1 = false;

            send_data[0] = strat_byte;
            send_data[1] = (Byte)2;
            send_data[2] = (Byte)3;
            send_data[3] = 0;
            send_data[4] = 0;
            send_data[5] = 0;
            send_data[6] = stop_byte;

            //FA 02 03 00 00 00 FB (ALL off)

            port.Write(send_data, 0, 7);

            port.Close();

        }

        private void dynamic_enter_ch1_Click(object sender, EventArgs e)
        {
            port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            port.Open();

            int hz_value = 0;
            int hz_input1 = 0;
            int hz_input2 = 0;
            // dynamic_hz_ch1
            bool check_hz = int.TryParse(dynamic_hz_ch1.Text, out hz_value);

            if (hz_value >= 1 && hz_value <= 300 && dynamic_hz_ch1.Text != "" && check_hz == true)
            {
                if(check_static_using_ch1 == false)
                {
                    hz_input1 = hz_value / 10;
                    hz_input2 = hz_value % 10;

                    dynamic_using_ch1.BackColor = Color.Red;
                    check_dynamic_using_ch1 = true;

                    send_data[0] = strat_byte;
                    send_data[1] = (Byte)2;
                    send_data[2] = (Byte)3;
                    send_data[3] = Convert.ToByte(hz_input1);
                    send_data[4] = Convert.ToByte(hz_input2);
                    send_data[5] = 0;
                    send_data[6] = stop_byte;

                    // FA 02 03 XX XX 00 FB (vibe)

                    port.Write(send_data, 0, 7);

                }
                else
                {
                    MessageBox.Show("Static부분을 Off하고 사용해주세요");
                }
            }
            else
            {
                MessageBox.Show("입력값이 올바르지 않습니다. input value : (1~300)");
            }

            port.Close();

        }
        /********************************************************************/

        /************************** CHANEL 2 ********************************/
        private void static_input_ch2_Click(object sender, EventArgs e)
        {
            static_input_ch2.BackColor = Color.Red;
            static_input_ch2.ForeColor = Color.White;
            static_output_ch2.BackColor = SystemColors.Control;
            static_output_ch2.ForeColor = SystemColors.ControlText;

            check_input_ch2 = true;
            check_output_ch2 = false;
        }

        private void static_output_ch2_Click(object sender, EventArgs e)
        {
            static_input_ch2.BackColor = SystemColors.Control;
            static_input_ch2.ForeColor = SystemColors.ControlText;
            static_output_ch2.BackColor = Color.Red;
            static_output_ch2.ForeColor = Color.White;

            check_input_ch2 = false;
            check_output_ch2 = true;
        }

        private void static_enter_ch2_Click(object sender, EventArgs e)
        {
            port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            port.Open();

            if (check_input_ch2 == true)
            {
                if (check_dynamic_using_ch2 == false)
                {
                    static_using_ch2.BackColor = Color.Red;
                    check_static_using_ch2 = true;

                    send_data[0] = strat_byte;
                    send_data[1] = (Byte)3;
                    send_data[2] = (Byte)1;
                    send_data[3] = 0;
                    send_data[4] = 0;
                    send_data[5] = 0;
                    send_data[6] = stop_byte;

                    //FA 03 01 00 00 00 FB (in)

                    port.Write(send_data, 0, 7);
                }
                else
                {
                    MessageBox.Show("Dynamic부분을 Off하고 사용해주세요");
                }
            }
            else if (check_output_ch2 == true)
            {
                if (check_dynamic_using_ch2 == false)
                {
                    static_using_ch2.BackColor = Color.Red;
                    check_static_using_ch2 = true;

                    send_data[0] = strat_byte;
                    send_data[1] = (Byte)3;
                    send_data[2] = (Byte)2;
                    send_data[3] = 0;
                    send_data[4] = 0;
                    send_data[5] = 0;
                    send_data[6] = stop_byte;

                    //FA 03 02 00 00 00 FB (out)

                    port.Write(send_data, 0, 7);

                }
                else
                {
                    MessageBox.Show("Dynamic부분을 Off하고 사용해주세요");
                }

            }
            else
            {
                MessageBox.Show("입력값이 올바르지 않습니다.");
            }

            port.Close();
        }

        private void all_off_ch2_Click(object sender, EventArgs e)
        {
            port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            port.Open();

            static_input_ch2.BackColor = SystemColors.Control;
            static_input_ch2.ForeColor = SystemColors.ControlText;
            static_output_ch2.BackColor = SystemColors.Control;
            static_output_ch2.ForeColor = SystemColors.ControlText;

            static_using_ch2.BackColor = Color.Transparent;
            dynamic_using_ch2.BackColor = Color.Transparent;

            check_input_ch2 = false;
            check_output_ch2 = false;

            check_static_using_ch2 = false;
            check_dynamic_using_ch2 = false;

            send_data[0] = strat_byte;
            send_data[1] = (Byte)3;
            send_data[2] = (Byte)3;
            send_data[3] = 0;
            send_data[4] = 0;
            send_data[5] = 0;
            send_data[6] = stop_byte;

            //FA 03 03 00 00 00 FB (ALL off)

            port.Write(send_data, 0, 7);

            port.Close();
        }

        private void dynamic_enter_ch2_Click(object sender, EventArgs e)
        {
            port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            port.Open();

            int hz_value = 0;
            int hz_input1 = 0;
            int hz_input2 = 0;
            // dynamic_hz_ch1
            bool check_hz = int.TryParse(dynamic_hz_ch2.Text, out hz_value);

            if (hz_value >= 1 && hz_value <= 300 && dynamic_hz_ch2.Text != "" && check_hz == true)
            {
                if (check_static_using_ch2 == false)
                {
                    hz_input1 = hz_value / 10;
                    hz_input2 = hz_value % 10;

                    dynamic_using_ch2.BackColor = Color.Red;
                    check_dynamic_using_ch2 = true;

                    send_data[0] = strat_byte;
                    send_data[1] = (Byte)3;
                    send_data[2] = (Byte)3;
                    send_data[3] = Convert.ToByte(hz_input1);
                    send_data[4] = Convert.ToByte(hz_input2);
                    send_data[5] = 0;
                    send_data[6] = stop_byte;

                    // FA 03 03 XX XX 00 FB (vibe)

                    port.Write(send_data, 0, 7);

                }
                else
                {
                    MessageBox.Show("Static부분을 Off하고 사용해주세요");
                }
            }
            else
            {
                MessageBox.Show("입력값이 올바르지 않습니다. input value : (1~300)");
            }

            port.Close();
        }
        /********************************************************************/
    }
}
