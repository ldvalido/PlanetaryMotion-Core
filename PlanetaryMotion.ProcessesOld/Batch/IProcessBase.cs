using PlanetaryMotion.Processes.Option;

namespace PlanetaryMotion.Processes.Batch
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProcessBase
    {
        /// <summary>
        /// Executes the specified option.
        /// </summary>
        /// <param name="idExecution">The option.</param>
        void Execute(int idExecution);
        /// <summary>
        /// Determines whether [has unique execution].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has unique execution]; otherwise, <c>false</c>.
        /// </returns>
        bool HasUniqueExecution();
        /// <summary>
        /// Executions the key.
        /// </summary>
        /// <returns></returns>
        string ExecutionKey();
    }
}
