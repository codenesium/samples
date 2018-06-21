using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface ICountryRequirementRepository
        {
                Task<CountryRequirement> Create(CountryRequirement item);

                Task Update(CountryRequirement item);

                Task Delete(int id);

                Task<CountryRequirement> Get(int id);

                Task<List<CountryRequirement>> All(int limit = int.MaxValue, int offset = 0);

                Task<Country> GetCountry(int countryId);
        }
}

/*<Codenesium>
    <Hash>9f2d2a51934dc165e25acd8e9ea8c7d3</Hash>
</Codenesium>*/