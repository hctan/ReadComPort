using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadComPort
{
    class Program
    {
        static void Main(string[] args)
        {
            bool portOpen = false;
            SerialPort mySerialPort = new SerialPort("COM3");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            
            mySerialPort.DataReceived += MySerialPort_DataReceived;

            try
            {
                mySerialPort.Open();
                portOpen = true;
            }

            catch (IOException ex)
            {
                Debug.Print("IO Exception: " + ex);
            }

            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            Console.ReadKey();

            if (portOpen)
            {
                mySerialPort.Close();
            }
        }

        private static void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Debug.Print("Data Received:");
            Debug.Print(indata);
        }
    }
}
