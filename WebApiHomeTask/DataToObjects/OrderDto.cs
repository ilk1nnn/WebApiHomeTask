﻿namespace WebApiHomeTask.DataToObjects
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
