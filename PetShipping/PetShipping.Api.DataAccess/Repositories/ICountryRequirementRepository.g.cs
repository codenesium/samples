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

                Task<List<CountryRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>645701a73c919c7c6cbb1fb6186b3fbf</Hash>
</Codenesium>*/