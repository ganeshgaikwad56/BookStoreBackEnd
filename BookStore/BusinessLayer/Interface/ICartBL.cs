﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public CartModel AddCart(CartModel cart, int userId);
        public string RemoveFromCart(int CartId);
    }
}