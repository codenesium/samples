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

                Task<List<PersonCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>40af49b9be63fd1d908821aefc2a7912</Hash>
</Codenesium>*/