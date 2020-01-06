using System;
using Microsoft.VisualBasic.Logging;

namespace DataLogicBAL.CMS.Exceptions
{
    public class ExceptionManager
    {
        private static Log log = new Log();

        [Serializable()]
        public class InvalidParsingDataException : Exception
        {
            public InvalidParsingDataException() : base() { }
            public InvalidParsingDataException(string message = "Exception") : base(message)
            {           
                //Log Message
                log.WriteEntry(message);
            }
            public InvalidParsingDataException(string message, Exception inner) : base(message, inner)
            {
                //Log Message & Expcetion
                log.WriteEntry(message);
                log.WriteException(inner);
            }

            // A constructor is needed for serialization when an
            // exception propagates from a remoting server to the client. 
            protected InvalidParsingDataException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context)
            { }
        }

        [Serializable()]
        public class FailedConnectingToDBException : Exception
        {
            public FailedConnectingToDBException() : base() { }
            public FailedConnectingToDBException(string message) : base(message)
            {
                //Log Message
                log.WriteEntry(message);
            }
            public FailedConnectingToDBException(string message, Exception inner) : base(message, inner)
            {
                //Log Message & Expcetion
                log.WriteEntry(message);
                log.WriteException(inner);
            }

            // A constructor is needed for serialization when an
            // exception propagates from a remoting server to the client. 
            protected FailedConnectingToDBException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context)
            { }
        }

        [Serializable()]
        public class FailedQueryingDataException : Exception
        {
            public FailedQueryingDataException() : base() { }
            public FailedQueryingDataException(string message) : base(message)
            {
                //Log Message
                log.WriteEntry(message);
            }
            public FailedQueryingDataException(string message, Exception inner) : base(message, inner)
            {
                //Log Message & Expcetion
                log.WriteEntry(message);
                log.WriteException(inner);
            }

            // A constructor is needed for serialization when an
            // exception propagates from a remoting server to the client. 
            protected FailedQueryingDataException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context)
            { }
        }
    }
}
