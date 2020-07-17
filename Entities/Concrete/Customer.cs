using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class Customer:  IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string CitizienNumber { get; set; }
        public int CompanyId { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}
