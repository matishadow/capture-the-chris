using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;

namespace CaptureTheChris.Web
{
    internal static class InversionOfControlConfiguration
    {
        public static void BuildContainer()
        {
            IEnumerable<Assembly> CaptureTheChrisAssemblies = GetCaptureTheChrisAssemblies();            
        
            var builder = new ContainerBuilder();

            RegisterMvcTypes(builder);
            RegisterCaptureTheChrisTypes(CaptureTheChrisAssemblies, builder);

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static IEnumerable<Assembly> GetCaptureTheChrisAssemblies()
        {
            List<Assembly> assemblies = BuildManager.GetReferencedAssemblies()
                .Cast<Assembly>()
                .Where(assembly => assembly.FullName.StartsWith("CaptureTheChris"))
                .ToList();

            return assemblies;
        }

        private static void RegisterMvcTypes(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterFilterProvider();
        }

        private static void RegisterCaptureTheChrisTypes(IEnumerable<Assembly> assemblies, ContainerBuilder builder)
        {
            foreach (Assembly assembly in assemblies)
            {
                RegisterInstanceDependenciesAsInterfaces(builder, assembly);
                RegisterInstanceDependenciesAsSelf(builder, assembly);
                RegisterLifetimeScopeAsInterfaces(builder, assembly);
                RegisterLifetimeScopeAsSelf(builder, assembly);
                RegisterInstanceRequestAsInterfaces(builder, assembly);
                RegisterInstanceRequestAsSelf(builder, assembly);
                RegisterSingleInstanceAsInterfaces(builder, assembly);
                RegisterSingleInstanceAsSelf(builder, assembly);
            }
        }

        private static void RegisterInstanceDependenciesAsInterfaces(ContainerBuilder builder, Assembly assembly)
        {
            Type[] types =
                FilterTypesByInterfaces(assembly.GetTypes(), 
                    typeof(IInstancePerDependency),
                    typeof(IAsImplementedInterfacesDependency));

            builder.RegisterTypes(types)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired();
        }

        private static void RegisterInstanceDependenciesAsSelf(ContainerBuilder builder, Assembly assembly)
        {
            Type[] types =
                FilterTypesByInterfaces(assembly.GetTypes(), 
                    typeof(IInstancePerDependency),
                    typeof(IAsSelfRegistrationDependency));

            builder.RegisterTypes(types)
                .AsSelf()
                .InstancePerDependency()
                .PropertiesAutowired();
        }

        private static void RegisterLifetimeScopeAsInterfaces(ContainerBuilder builder, Assembly assembly)
        {
            Type[] types =
                FilterTypesByInterfaces(assembly.GetTypes(), 
                    typeof(IInstancePerLifetimeScopeDependency),
                    typeof(IAsImplementedInterfacesDependency));

            builder.RegisterTypes(types)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired();
        }

        private static void RegisterLifetimeScopeAsSelf(ContainerBuilder builder, Assembly assembly)
        {
            Type[] types =
                FilterTypesByInterfaces(assembly.GetTypes(), 
                    typeof(IInstancePerLifetimeScopeDependency),
                    typeof(IAsSelfRegistrationDependency));

            builder.RegisterTypes(types)
                .AsSelf()
                .InstancePerLifetimeScope()
                .PropertiesAutowired();
        }

        private static void RegisterInstanceRequestAsInterfaces(ContainerBuilder builder, Assembly assembly)
        {
            Type[] types =
                FilterTypesByInterfaces(assembly.GetTypes(), 
                    typeof(IInstancePerRequestDependency),
                    typeof(IAsImplementedInterfacesDependency));

            builder.RegisterTypes(types)
                .AsImplementedInterfaces()
                .InstancePerRequest()
                .PropertiesAutowired();
        }

        private static void RegisterInstanceRequestAsSelf(ContainerBuilder builder, Assembly assembly)
        {
            Type[] types =
                FilterTypesByInterfaces(assembly.GetTypes(), 
                    typeof(IInstancePerRequestDependency),
                    typeof(IAsSelfRegistrationDependency));

            builder.RegisterTypes(types)
                .AsSelf()
                .InstancePerRequest()
                .PropertiesAutowired();
        }

        private static void RegisterSingleInstanceAsInterfaces(ContainerBuilder builder, Assembly assembly)
        {
            Type[] types =
                FilterTypesByInterfaces(assembly.GetTypes(), 
                    typeof(ISingleInstanceDependency),
                    typeof(IAsImplementedInterfacesDependency));

            builder.RegisterTypes(types)
                .AsImplementedInterfaces()
                .SingleInstance()
                .PropertiesAutowired();
        }

        private static void RegisterSingleInstanceAsSelf(ContainerBuilder builder, Assembly assembly)
        {
            Type[] types =
                FilterTypesByInterfaces(assembly.GetTypes(),
                    typeof(ISingleInstanceDependency),
                    typeof(IAsSelfRegistrationDependency));

            builder.RegisterTypes(types)
                .AsSelf()
                .SingleInstance()
                .PropertiesAutowired();
        }

        private static Type[] FilterTypesByInterfaces(IEnumerable<Type> types, params Type[] interfaces)
        {
            return (from type in types
                let hasAllInterfaces = interfaces.All(filteringInterface => filteringInterface.IsAssignableFrom(type))
                where hasAllInterfaces
                select type).ToArray();
        }
    }
}