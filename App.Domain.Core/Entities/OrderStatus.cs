using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
