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

                Task<List<CreditCard>> All(int limit = int.MaxValue, int offset = 0);

                Task<CreditCard> ByCardNumber(string cardNumber);

                Task<List<PersonCreditCard>> PersonCreditCards(int creditCardID, int limit = int.MaxValue, int offset = 0);
                Task<List<SalesOrderHeader>> SalesOrderHeaders(int creditCardID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8b43c8998ca2eecb980e80cd937d23f4</Hash>
</Codenesium>*/