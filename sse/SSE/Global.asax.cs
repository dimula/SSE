using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ServiceStack;

namespace SSE
{
    public class Global : System.Web.HttpApplication
    {
        public class AppHost : AppHostBase
        {
            public AppHost() : base("Hello Web Services", typeof(HelloService).Assembly) { }

            public override void Configure(Funq.Container container)
            {
                Plugins.Add(new ServerEventsFeature()
                {
                    LimitToAuthenticatedUsers = false,
                    NotifyChannelOfSubscriptions = false,
                    //OnConnect = (arg1, arg2) =>{},
                    //OnSubscribe = obj =>{},
                    //OnUnsubscribe = obj =>{},
                });
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }
    }
}