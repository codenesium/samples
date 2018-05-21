using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ISpeciesRepository
	{
		Task<POCOSpecies> Create(ApiSpeciesModel model);

		Task Update(int id,
		            ApiSpeciesModel model);

		Task Delete(int id);

		Task<POCOSpecies> Get(int id);

		Task<List<POCOSpecies>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>13714f1f8278ae7ba3e39aaf2e03a716</Hash>
</Codenesium>*/