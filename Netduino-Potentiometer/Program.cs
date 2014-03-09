using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Netduino_Potentiometer
{
    public class Program
    {
        public static void Main()
        {
            AnalogInput pot = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);
            OutputPort led = new OutputPort(Pins.GPIO_PIN_D0, false);
            pot.Offset = 0;
            pot.Scale = 100000;

            double potValue = 0.0;
            int sleepValue = 0;

            while (true)
            {
                potValue = pot.Read();
                sleepValue = (int)(potValue);
                Debug.Print(potValue + " " + sleepValue);
                led.Write(true);
                Thread.Sleep(sleepValue);
                led.Write(false);
                Thread.Sleep(sleepValue);
            }
        }

    }
}
