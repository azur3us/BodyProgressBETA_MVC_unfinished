﻿using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Models
{
    public class Exercise : IEntity
    {  
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
