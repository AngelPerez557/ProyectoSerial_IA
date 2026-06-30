using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Web;

namespace CentralControl.Models
{
    public class SerialControl
    {
        SerialPort serialPort { get; set; }
        int readout { get; set; }
        int writeout { get; set; }
        String port { get; set; }
        int frequency { get; set; }

        public SerialControl(string port_, int readout_ = 2000, int writeout_ = 2000, int frequency = 9600)
        {
            this.port = port_;
            this.readout = readout_;
            this.writeout = writeout_;
            this.frequency = frequency;
            this.serialPort = new SerialPort(this.port, this.frequency, Parity.None, 8, StopBits.One);
            this.serialPort.ReadTimeout = this.readout;
            this.serialPort.WriteTimeout = this.writeout;
            Thread.Sleep(1000);
        }

        public void Open()
        {
            if (!this.serialPort.IsOpen)
            {
                this.serialPort.Open();
            }
        }

        public void Close()
        {
            if (this.serialPort.IsOpen)
            {
                this.serialPort.Close();
            }
        }

        public void Write(string param)
        {
            this.serialPort.WriteLine(param);
        }

        public string Read()
        {
            return this.serialPort.ReadLine();
        }

    }
}