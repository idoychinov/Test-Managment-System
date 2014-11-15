﻿namespace TestManagmentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class TestedSystem : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}