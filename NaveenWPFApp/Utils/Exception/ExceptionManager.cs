using System;
using Microsoft.VisualBasic.Logging;

namespace NaveenWPFApp.Utils.Exception
{
    [Serializable()]
    public class ExceptionManager : System.Exception
    {
        private static Log log = new Log();

        public ExceptionManager() : base() { }
        public ExceptionManager(string message = "Exception") : base(message)
        {
            //Log Message
            log.WriteEntry(message);
        }
        public ExceptionManager(string message, System.Exception inner) : base(message, inner)
        {
            //Log Message & Expcetion
            log.WriteEntry(message);
            log.WriteException(inner);
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected ExceptionManager(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
