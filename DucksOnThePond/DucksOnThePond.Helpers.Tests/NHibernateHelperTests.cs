using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using System.Web;
using System.Collections.Generic;
using System;
using DucksOnThePond.Helpers;

namespace DucksOnThePond.Helpers.Tests
{
    [TestClass]
    public class NHibernateHelperTests
    {
        [TestMethod]
        public void Index()
        {
            ISession session = NHibernateHelper.OpenSession();
            
            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", session);
        }
    }
}
