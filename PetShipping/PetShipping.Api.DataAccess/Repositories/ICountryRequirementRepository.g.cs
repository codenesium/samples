using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>293207eaca36f44f37dbb3e3e171670c</Hash>
</Codenesium>*/