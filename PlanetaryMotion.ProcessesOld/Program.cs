using Autofac;
using PlanetaryMotion.IOC;
using PlanetaryMotion.Processes.Batch;
using PlanetaryMotion.Processes.Option;

namespace PlanetaryMotion.Processes
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {

            var options = new ProcessOption();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var container = new ServiceLocatorFluent().CreateContainer().Build();

                var application = container.Resolve<IProcessManager>();

                application.ExecuteProcess(container, options);
            }
        }
    }
}
