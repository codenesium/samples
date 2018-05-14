using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface ISpeciesRepository
	{
		POCOSpecies Create(ApiSpeciesModel model);

		void Update(int id,
		            ApiSpeciesModel model);

		void Delete(int id);

		POCOSpecies Get(int id);

		List<POCOSpecies> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8926f384ebee38dc25d09a5db7995e24</Hash>
</Codenesium>*/