using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonService
    {
        bool CheckPersonIsValid(Person person);
        bool CheckPersonHasMaskLastOneWeek(Person person);

        bool GiveMaskToPerson(Person person);
    }
}
