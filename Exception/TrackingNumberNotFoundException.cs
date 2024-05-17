using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Application.Exception
{
    internal class TrackingNumberNotFoundException : ApplicationException
    {
        public TrackingNumberNotFoundException(string? message) : base(message) { }
    }
}
