using Autofac;
using Autofac.Integration.Mvc;
using MonumentPlay.Data;
using MonumentPlay.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MonumentPlay.App_Start
{
    public class IoCConfiguration
    {
        public static void RegistrarDependencias() 
        {
            //Constructor de contenedor
            ContainerBuilder builder = new ContainerBuilder();

            //Registramos los controladores
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Tipo de interfaz
            builder.RegisterType<RepositoryMonumentPlayMYSQL>().As<IRepositoryMonument>().InstancePerRequest();
            builder.RegisterType<ContextoMonumentMYSQL>().As<IContextoMonument>();

            //Creamos el container con el builder()
            IContainer container = builder.Build();

            //Indicamos el entorno MVC qué contenedor IoCC va a utilizar
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}