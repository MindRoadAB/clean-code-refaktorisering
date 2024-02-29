using System;

namespace Tennis
{
    public class TennisException : Exception
    {
        public TennisException(string message) :
            base(message)
        {

        }
    }
}
