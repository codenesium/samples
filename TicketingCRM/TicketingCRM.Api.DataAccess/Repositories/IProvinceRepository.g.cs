using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>91eaae1b01f8e2c47ed28d3597248761</Hash>
</Codenesium>*/