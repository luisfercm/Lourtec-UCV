using System;
using System.Runtime.Serialization;

namespace DemoInterfaces
{
    [Serializable]
    internal class IdexOutRangeException : Exception
    {
        public IdexOutRangeException()
        {
        }

        public IdexOutRangeException(string message) : base(message)
        {
        }

        public IdexOutRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdexOutRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}