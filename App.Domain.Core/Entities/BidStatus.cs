using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class BidStatus
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
}
