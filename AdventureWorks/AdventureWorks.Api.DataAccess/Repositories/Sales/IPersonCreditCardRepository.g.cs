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

                Task<List<PersonCreditCard>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>2b35b2bb944e2f245419b0dcf7492493</Hash>
</Codenesium>*/