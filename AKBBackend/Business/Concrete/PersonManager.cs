using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonWhoHasTcNumberDal _personWhoHasTcNumberDal;
        private IPersonWhoHasNotTcNumberDal _personWhoHasNotTcNumberDal;
        private IMaskDelivery _efMaskDeliveryDal;
        public PersonManager(IPersonWhoHasTcNumberDal personWhoHasTcNumberDal,
                            IMaskDelivery efMaskDeliveryDal,
                            IPersonWhoHasNotTcNumberDal personWhoHasNotTcNumberDal)
        {
            _personWhoHasTcNumberDal = personWhoHasTcNumberDal;
            _efMaskDeliveryDal = efMaskDeliveryDal;
            _personWhoHasNotTcNumberDal = personWhoHasNotTcNumberDal;
        }

        public bool CheckPersonHasMaskLastOneWeek(Person person)
        {
            //ikisi de true, ilerlemek için, geliştir!
            var result = _personWhoHasTcNumberDal.Get(p => p.IdentityNumber == person.Number);
            if (result == null)
            {
                return true;
            }
            else
                return true;
        }

        public bool CheckPersonIsValid(Person person)
        {
            if (person.Number.Length == 11)
            {
                KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

                long identityNumberLongType = long.Parse(person.Number);
                int birthYearIntType = int.Parse(person.BirthYear);

                return client.TCKimlikNoDogrulaAsync
                    (new TCKimlikNoDogrulaRequest
                    (new TCKimlikNoDogrulaRequestBody(identityNumberLongType, person.Name, person.Surname,birthYearIntType)))
                    .Result.Body.TCKimlikNoDogrulaResult;
            }
            else
                return true;
        }

        public bool GiveMaskToPerson(Person person)
        {
            MaskDelivery maskDelivery = new MaskDelivery()
            {
                PersonId = person.Id,
                Count = 5,
                DeliveryDate = DateTime.Now
            };

            if (person.Number.Length == 11)
            {
                PersonWhoHasTcNumber personWhoHasTcNumber = new PersonWhoHasTcNumber()
                {
                    IdentityNumber = person.Number,
                    Name = person.Name,
                    Surname = person.Surname
                };

                _personWhoHasTcNumberDal.Add(personWhoHasTcNumber);
            }

            else
            {
                PersonWhoHasNotTcNumber personWhoHasNotTcNumber = new PersonWhoHasNotTcNumber()
                {
                    PassoportNumber = person.Number,
                    Name = person.Name,
                    Surname = person.Surname
                };
                _personWhoHasNotTcNumberDal.Add(personWhoHasNotTcNumber);
            }

            _efMaskDeliveryDal.Add(maskDelivery);
            return true;
        }
    }
}
