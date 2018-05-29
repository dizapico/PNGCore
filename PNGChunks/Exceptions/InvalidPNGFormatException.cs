using System;
using System.Collections.Generic;
using System.Text;

namespace PNGChunks.Exceptions
{
    [Serializable()]
    public class InvalidPNGFormatException : System.Exception
    {
        public InvalidPNGFormatException() : base(){ }
        public InvalidPNGFormatException(String message) : base (message) { }
        public InvalidPNGFormatException(String message, System.Exception inner) :base(message, inner) { }

        protected InvalidPNGFormatException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }

    }
}
