using System;
using System.Management;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MonitoramentoDeCPUaLaTaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) { 
                try
                {

                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("root\\CIMV2",
                        "SELECT * FROM Win32_PerfFormattedData_PerfProc_Process");


                    foreach (ManagementObject queryObj in searcher.Get())
                    {


                        Console.WriteLine("ProcessID: {0}", queryObj["IDProcess"]);
                        Console.WriteLine("Name: {0}", queryObj["Name"]);
                        Console.WriteLine("Handles: {0}", queryObj["HandleCount"]);
                        Console.WriteLine("Threads: {0}", queryObj["ThreadCount"]);
                        Console.WriteLine("Memory: {0}", queryObj["WorkingSetPrivate"]);
                        Console.WriteLine("CPU%: {0}", queryObj["PercentProcessorTime"]);
                    }


                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }  
                Thread.Sleep(1000);
            }
        }
    }
}
