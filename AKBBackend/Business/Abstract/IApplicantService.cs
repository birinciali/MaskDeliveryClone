using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IApplicantService
    {
        bool ApplyForMask(Person person);

        List<Person> GetList();

        bool CheckPersonIsValid(Person person);

        bool CheckPersonIsExcist(Person person);

        bool CheckPersonHasMaskLastOneWeek(Person person);

        bool AddPersonToDb(Person person);

        bool GiveMaskToPerson(Person person);

    }
}
