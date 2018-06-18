using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>f6d5f70235ccbd34309cc647580202d1</Hash>
</Codenesium>*/