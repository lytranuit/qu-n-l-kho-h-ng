using System;
using System.Runtime.Serialization;

namespace DXApplication5
{
    [Serializable]
    internal class UniqueConstraintException : Exception
    {
        public UniqueConstraintException()
        {
        }

        public UniqueConstraintException(string message) : base(message)
        {
        }

        public UniqueConstraintException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UniqueConstraintException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}