using System;
using System.Runtime.Serialization;

namespace DXApplication5
{
    [Serializable]
    internal class MaxLengthExceededException : Exception
    {
        public MaxLengthExceededException()
        {
        }

        public MaxLengthExceededException(string message) : base(message)
        {
        }

        public MaxLengthExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MaxLengthExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}