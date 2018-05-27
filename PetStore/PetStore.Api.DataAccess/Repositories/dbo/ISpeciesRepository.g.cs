using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface ISpeciesRepository
	{
		Task<DTOSpecies> Create(DTOSpecies dto);

		Task Update(int id,
		            DTOSpecies dto);

		Task Delete(int id);

		Task<DTOSpecies> Get(int id);

		Task<List<DTOSpecies>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1bec7217876ea7b5047081ba649b6e6b</Hash>
</Codenesium>*/