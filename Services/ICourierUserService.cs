﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Application.Services
{
    internal interface ICourierUserService
    {
        void PlaceOrder();
        void GetOrderStatus();
        void CancelOrder();
        void GetAssignedOrder();
    }
}
