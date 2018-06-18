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

                Task<List<Province>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Province>> GetCountryId(int countryId);

                Task<List<City>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0);
                Task<List<Venue>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0);

                Task<Country> GetCountry(int countryId);
        }
}

/*<Codenesium>
    <Hash>4f2bfa075d6142db1677e5f3a2ab5cc6</Hash>
</Codenesium>*/