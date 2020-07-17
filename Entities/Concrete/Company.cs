using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class Company: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool TcIsrequired { get; set; }


    }
}
