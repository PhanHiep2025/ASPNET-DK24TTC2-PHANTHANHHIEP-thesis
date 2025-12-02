using System;
using System.Collections.Generic;

namespace ShoesStore.Models;

public partial class Tinh
{
    public int Matinh { get; set; }

    public string Tentinh { get; set; } = null!;

    public virtual ICollection<Phuong> Phuongs { get; set; } = new List<Phuong>();
}
