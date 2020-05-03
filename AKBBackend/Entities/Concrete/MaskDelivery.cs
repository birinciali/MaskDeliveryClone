using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MaskDelivery : IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Count { get; set; }

    }
}
