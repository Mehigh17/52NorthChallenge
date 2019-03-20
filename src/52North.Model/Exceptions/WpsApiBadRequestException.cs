using System;

namespace _52North.Model.Exceptions
{
    public class WpsApiBadRequestException : Exception
    {

        public WpsApiBadRequestException(string message) : base(message)
        { }

    }
}
