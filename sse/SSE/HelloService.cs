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
    [Route("/send")]
    public class Message
    {
        public string Text { get; set; }
    }
    public class MessageResponse
    {
        public string Result { get; set; }
    }
    public class HelloService : Service
    {
        public object Get(Hello request)
        {
            return new HelloResponse { Result = "Hello, " + request.Name };
        }

        public object Post(Message message)
        {
            return new MessageResponse(){Result = "Ok"};
        }
    }
}