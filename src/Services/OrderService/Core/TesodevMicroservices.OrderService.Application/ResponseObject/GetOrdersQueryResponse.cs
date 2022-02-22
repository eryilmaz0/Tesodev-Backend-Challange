﻿using System.Collections;
using System.Collections.Generic;
using TesodevMicroservices.OrderService.Application.ViewModel;

namespace TesodevMicroservices.OrderService.Application.ResponseObject
{
    public class GetOrdersQueryResponse
    {
        public ICollection<ListOrdersViewModel> Orders { get; set; }
    }
}