using System;
using QuotationSystem.Domain.Entities;

namespace QuotationSystem.Application.DTOs;

public class QuoteItemDto
{
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }

}
