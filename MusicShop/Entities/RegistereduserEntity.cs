﻿using System;
using System.Collections.Generic;

namespace MusicShop.Entities;

public partial class RegistereduserEntity
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }
}
