﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Lab9API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\keyul\Desktop\Lab Week 9\Lab Week 4\App_Data");
        }
    }
}
