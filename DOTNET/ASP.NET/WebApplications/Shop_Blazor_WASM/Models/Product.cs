﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop_Blazor_WASM.Models;

public partial class Product
{
    public int Id { get; set; }

    [Required]
    [MinLength(2)]
    public string Name { get; set; } = null!;

    [Range(1,123456)]
    public decimal Price { get; set; }
}
