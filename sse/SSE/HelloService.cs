using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.Messaging;

namespace SSE
{

    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello
    {
        public string Name { get; set; }
    }
    public class HelloResponse
    {
        public string Result { get; set; }
    }
    public class HelloService : Service
    {
        private static int counter = 0;
        public IServerEvents ServerEvents { get; set; }

        public object Get(Hello request)
        {
           return new HelloResponse { Result = "Hello, " + request.Name};
        }
        public void Post(Hello request)
        {
            var ssid = this.Request.Cookies["ss-id"];
            this.ServerEvents.NotifySession(ssid.Value, "cmd.myselector", counter++, "autoupdate");
        }
    }
}