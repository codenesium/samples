using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IPersonCreditCardRepository
        {
                Task<PersonCreditCard> Create(PersonCreditCard item);

                Task Update(PersonCreditCard item);

                Task Delete(int businessEntityID);

                Task<PersonCreditCard> Get(int businessEntityID);

                Task<List<PersonCreditCard>> All(int limit = int.MaxValue, int offset = 0);

                Task<CreditCard> GetCreditCard(int creditCardID);
        }
}

/*<Codenesium>
    <Hash>5d2257987a5fe1c144e86bebe5cc0ce3</Hash>
</Codenesium>*/