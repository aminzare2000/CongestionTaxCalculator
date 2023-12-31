﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class City
    {
        //public City()
        //{
        //    Id = Guid.NewGuid();
        //}

        //public City(Guid Id)
        //{
        //    this.Id = Id;
        //}

        //public City()
        //{
        //    this.Name  = "Gothenburg";
        //}

        //public City(string Name)
        //{
        //    this.Name = Name;
        //}
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<TariffDefinition>? TariffDefinitions { get; set; }
        
    }
}