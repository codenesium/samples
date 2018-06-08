using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ICreditCardRepository
        {
                Task<CreditCard> Create(CreditCard item);

                Task Update(CreditCard item);

                Task Delete(int creditCardID);

                Task<CreditCard> Get(int creditCardID);

                Task<List<CreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<CreditCard> GetCardNumber(string cardNumber);
        }
}

/*<Codenesium>
    <Hash>9edd91482b15e20d0b8be91e8ca35600</Hash>
</Codenesium>*/