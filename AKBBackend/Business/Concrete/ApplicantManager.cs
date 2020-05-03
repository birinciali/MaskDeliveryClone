using Business.Abstract;
using Business.Concrete;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ApplicantManager : IApplicantService
    {
        private IPersonService _personService;

        public ApplicantManager(IPersonService personService)
        {
            _personService = personService;
        }

        public bool AddPersonToDb(Person person)
        {
            return true;
        }

        public bool ApplyForMask(Person person)
        {
            if (CheckPersonIsValid(person))

                if (CheckPersonHasMaskLastOneWeek(person))
                {
                    //GiveMaskToPerson(person);
                    return GiveMaskToPerson(person);
                }
                else
                {
                    return false;
                }
            else
                return false;
        }

        public bool CheckPersonHasMaskLastOneWeek(Person person)
        {
            if (_personService.CheckPersonHasMaskLastOneWeek(person))
                return true;
            else
                return false;
        }

        public bool CheckPersonIsExcist(Person person)
        {
            return true;
        }

        public bool CheckPersonIsValid(Person person)
        {
            _personService.CheckPersonIsValid(person);
            return true;
        }


        public List<Person> GetList()
        {
            throw new NotImplementedException();
        }

        public bool GiveMaskToPerson(Person person)
        {
            _personService.GiveMaskToPerson(person);
            return true;
        }
    }
}
