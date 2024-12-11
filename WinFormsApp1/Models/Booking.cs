using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public string MovieName { get; set; } = null!;

    public string? CustomerName { get; set; }

    public int? SeatNumber { get; set; }
}
