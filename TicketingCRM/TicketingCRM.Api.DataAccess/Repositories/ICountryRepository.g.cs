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

                Task<List<Country>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Province>> Provinces(int countryId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>19ce743508ae640c4df4b3ea00894d9a</Hash>
</Codenesium>*/