using NHibernate;
using NHibernate.Cfg;
using System.Web;
using System.Collections.Generic;
using System;

namespace DucksOnThePond.Helpers
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    IDictionary<string, string> properties = new Dictionary<string, string>();
                    properties.Add("connection.driver_class", "NHibernate.Driver.SqlServerCeDriver");
                    properties.Add("dialect", "NHibernate.Dialect.MsSqlCeDialect");
                    properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                    properties.Add("connection.connection_string", "Data Source=/Users/Derek/Documents/GitHub/Projects/DucksOnThePond/DucksOnThePond.Dal/App_Data/DucksOnThePond.sdf");

                    var NHibernateConfig = new Configuration();
                    NHibernateConfig.Properties = properties;
                    NHibernateConfig.AddDirectory(new System.IO.DirectoryInfo("/Users/Derek/Documents/GitHub/Projects/DucksOnThePond/DucksOnThePond.Dal/NHibernate/Mappings"));
                    _sessionFactory = NHibernateConfig.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}