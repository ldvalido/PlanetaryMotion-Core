using System;
using System.Diagnostics;
using PlanetaryMotion.Processes.Option;
using System.Collections.Generic;
using System.Linq;
using PlanetaryMotion.IOC;

namespace PlanetaryMotion.Processes.Batch
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PlanetaryMotion.Processes.Batch.IProcessManager" />
    public class ProcessManager : IProcessManager
    {

        #region Implementation of IProcessManager        
        /// <summary>
        /// Executes the process.
        /// </summary>
        /// <param name="processOption">The process option.</param>
        /// 
        public void ExecuteProcess(ServiceLocatorFluent container , ProcessOption processOption)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var previousColor = Console.ForegroundColor;
            try
            {   
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The process is preparing to execute");
                var processes = container.Resolve<IEnumerable<IProcessBase>>();
                var process = processes.FirstOrDefault(p => string.Compare(p.ExecutionKey(), processOption.Batch,StringComparison.OrdinalIgnoreCase) == 0);
                if (process != null)
                {
                    if (process.HasUniqueExecution())
                    {
                        process.Execute(0);
                    }
                    else
                    {
                        for (var i = 0; i < processOption.Days; i++)
                        {
                            if (i%processOption.DeliveryResume == 0)
                            {
                                Console.WriteLine($"Executing process #{i} of {processOption.Days}");
                            }
                            process.Execute(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The process does not exists");
                }
                Console.WriteLine("The execution was succesfully");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error was ocurre: {ex.Message}" );
            }
            Console.ForegroundColor = previousColor;
            stopWatch.Stop();
            Console.WriteLine($"Time Elapsed: {stopWatch.ElapsedMilliseconds / 1000} seconds");
        }

        #endregion
    }
}
