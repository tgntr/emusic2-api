﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Models.View;

namespace SimpleMusicStore.Api.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orders;

        public OrderController(IOrderService orders)
            : base()
        {
            _orders = orders;
        }

        public async Task AddToCart(int id)
        {
            await _orders.AddToCart(id);
        }

        public async Task RemoveFromCart(int id)
        {
            await _orders.RemoveFromCart(id);
        }

        public async Task IncreaseQuantity(int id)
        {
            await _orders.IncreaseQuantity(id);
        }

        public async Task DecreaseQuantity(int id)
        {
            await _orders.DecreaseQuantity(id);
        }

        public async Task EmptyCart()
        {
            await _orders.EmptyCart();
        }

        public async Task Complete(int addressId)
        {
            await _orders.Complete(addressId);
        }

        public async Task<OrderView> Details(int id)
        {
            return await _orders.Find(id);
        }
    }
}