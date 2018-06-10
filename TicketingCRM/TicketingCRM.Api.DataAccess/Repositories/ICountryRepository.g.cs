using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ICountryRepository
        {
                Task<Country> Create(Country item);

                Task Update(Country item);

                Task Delete(int id);

                Task<Country> Get(int id);

                Task<List<Country>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>1639b7533d28920b02e349925425b5e4</Hash>
</Codenesium>*/