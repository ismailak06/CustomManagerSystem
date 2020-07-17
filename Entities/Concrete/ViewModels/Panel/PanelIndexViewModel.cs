using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.ViewModels.Panel
{
    public class PanelIndexViewModel
    {
        public IList<Customer> Customers { get; set; }
        public Company Company { get; set; }
        public Customer Customer { get; set; }
    }
}
