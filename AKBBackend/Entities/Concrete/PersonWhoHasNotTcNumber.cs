using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PersonWhoHasNotTcNumber : IPerson, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PassoportNumber { get; set; }

    }
}
