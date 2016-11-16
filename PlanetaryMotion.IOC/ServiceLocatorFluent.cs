using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.DependencyModel;

namespace PlanetaryMotion.IOC
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceLocatorFluent
    {
        #region const        
        /// <summary>
        /// The assembly prefix name
        /// </summary>
        private const string AssemblyPrefixName = "planetarymotion";
        #endregion
        #region Public Properties        
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        static IContainer Container { get; set; }
        #endregion

        #region Private Properties        
        /// <summary>
        /// The builder
        /// </summary>
        protected ContainerBuilder Builder;
        #endregion

        #region Virtual Methods                
        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <param name="loadedAsm">The loaded asm.</param>
        /// <returns></returns>
        public ServiceLocatorFluent CreateContainer()
        {
            LoadAssemblies();

            var loadedAsm = GetLoadedAssemblies();

            Builder = new ContainerBuilder();
            Builder.RegisterAssemblyTypes(loadedAsm)
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerDependency().
                PropertiesAutowired();
            return this;
        }
        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public ServiceLocatorFluent CreateContainer<T>(T config)
        {
            CreateContainer();
            
            OnCreateContainer(Builder,GetLoadedAssemblies(), config);
            return this;
        }
        /// <summary>
        /// Registers the type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="I"></typeparam>
        /// <returns></returns>
        public ServiceLocatorFluent Register<T>(T instance) where T : class
        {
            Builder.RegisterInstance(instance).AsImplementedInterfaces().AsSelf().As<T>();
            return this;
        }
        /// <summary>
        /// Builds this instance.
        /// </summary>
        public ServiceLocatorFluent Build()
        {
            Container = Builder.Build();
            return this;
        }
        /// <summary>
        /// Gets the raw container.
        /// </summary>
        /// <returns></returns>
        public IContainer GetRawContainer()
        {
            return Container;
        }

        /// <summary>
        /// Called when [create container].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="loadedAssemblies">The loaded assemblies.</param>
        /// <param name="config">The configuration.</param>
        protected virtual void OnCreateContainer<T>(ContainerBuilder builder, Assembly[] loadedAssemblies, T config)
        {
           
        }
        #endregion

        #region Private Methods        

        private IEnumerable<RuntimeAssembly> GetAssemblies()
            => DependencyContext.Default.RuntimeLibraries.Select(lib => lib.Assemblies);
        /// <summary>
        /// Gets the loaded assemblies.
        /// </summary>
        /// <returns></returns>
        RuntimeAssembly[] GetLoadedAssemblies()
        {
            var asm = GetAssemblies().Select(lib => lib.Assemblies);
            return asm.Where(AssemblyPrefixName);
        }

        /// <summary>
        /// Loads the assemblies.
        /// </summary>
        void LoadAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                LoadReferencedAssembly(assembly);
            }
        }

        /// <summary>
        /// Loads the referenced assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        void LoadReferencedAssembly(Assembly assembly)
        {
            foreach (var name in assembly.GetReferencedAssemblies().Where(FilterDomainAssembly))
            {
                if (AppDomain.CurrentDomain.GetAssemblies().All(a => a.FullName != name.FullName))
                {
                    LoadReferencedAssembly(Assembly.Load(name));
                }
            }
        }
        /// <summary>
        /// Filters the domain assembly.
        /// </summary>
        /// <param name="asm">The asm.</param>
        /// <returns></returns>
        public bool FilterDomainAssembly(AssemblyName asm)
        {
            return asm.FullName.ToLowerInvariant().Contains(AssemblyPrefixName);
        }
        /// <summary>
        /// Filters the domain assembly.
        /// </summary>
        /// <param name="asm">The asm.</param>
        /// <returns></returns>
        static bool FilterDomainAssembly(Assembly asm)
        {
            return asm.FullName.ToLowerInvariant().Contains(AssemblyPrefixName);
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
        #endregion
    }
}
