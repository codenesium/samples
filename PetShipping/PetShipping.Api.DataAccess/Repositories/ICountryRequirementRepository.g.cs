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

                Task<List<CountryRequirement>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>50ad4304d103ce34299fb692ce967025</Hash>
</Codenesium>*/