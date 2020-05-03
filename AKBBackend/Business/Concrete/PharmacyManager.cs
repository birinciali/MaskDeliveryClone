using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PharmacyManager : IDeliveryService
    {
        private IApplicantService _applicantService;
        public PharmacyManager(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        public void GiveMask(Person person) //kişi valitse, haftalık maskesini ver ve db'ye işlet
        {
            if (_applicantService.CheckPersonIsValid(person))
            {
                if (_applicantService.CheckPersonIsExcist(person))
                {
                    if (!_applicantService.CheckPersonHasMaskLastOneWeek(person))
                    {
                        _applicantService.GiveMaskToPerson(person);
                    }
                    else
                    {
                        Console.WriteLine("You cant take mask for now");
                    }
                }
                else
                {
                    _applicantService.AddPersonToDb(person);
                    _applicantService.GiveMaskToPerson(person);
                }
            }
        }
    }
}
