using System;
using System.Collections.Generic;

namespace ShoesStore.Models;

public partial class Phuong
{
    public int Maphuong{ get; set; }

    public string Tenphuong { get; set; } = null!;

    public int Matinh { get; set; }

    public virtual Tinh MatinhNavigation { get; set; } = null!;

    
}
