﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Application.Exception
{
    internal class InvalidEmployeeIdException : ApplicationException
    {
        public InvalidEmployeeIdException(string? message) : base(message) { }
    }
}

