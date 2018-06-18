using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface ICountryRepository
        {
                Task<Country> Create(Country item);

                Task Update(Country item);

                Task Delete(int id);

                Task<Country> Get(int id);

                Task<List<Country>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<CountryRequirement>> CountryRequirements(int countryId, int limit = int.MaxValue, int offset = 0);
                Task<List<Destination>> Destinations(int countryId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>26897613dfd1ac4abb27838d3e806a1b</Hash>
</Codenesium>*/