using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface IProvinceRepository
        {
                Task<Province> Create(Province item);

                Task Update(Province item);

                Task Delete(int id);

                Task<Province> Get(int id);

                Task<List<Province>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Province>> GetCountryId(int countryId);

                Task<List<City>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0);
                Task<List<Venue>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c26c04910d32b8ad051af0297d3337e8</Hash>
</Codenesium>*/