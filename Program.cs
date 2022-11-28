using System;
using System.Management;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MonitoramentoDeCPUeRAM
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;

            cpuCounter = new PerformanceCounter("Processor","% Processor Time","_Total", "CARINE-VAIO");

            cpuCounter.NextValue();

            System.Threading.Thread.Sleep(1000);// 1 second wait

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            Console.WriteLine("CPU : "+cpuCounter.NextValue()+"%");
            Console.WriteLine("RAM : " + ramCounter.NextValue()+"MB");
        }
    }
}
