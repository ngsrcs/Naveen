using System;
using Microsoft.VisualBasic.Logging;

namespace NaveenWPFApp.Utils.Exception
{
    [Serializable()]
    public class RenderExceptions : System.Exception
    {
        private static Log log = new Log();

        public RenderExceptions() : base() { }
        public RenderExceptions(string message) : base(message)
        {
            //Log Message
            log.WriteEntry(message);
        }

        public RenderExceptions(string message, System.Exception inner) : base(message, inner)
        {
            //Log Message & Expcetion
            log.WriteEntry(message);
            log.WriteException(inner);
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected RenderExceptions(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
