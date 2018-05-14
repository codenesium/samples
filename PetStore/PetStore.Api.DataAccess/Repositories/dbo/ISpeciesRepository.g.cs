using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface ISpeciesRepository
	{
		POCOSpecies Create(SpeciesModel model);

		void Update(int id,
		            SpeciesModel model);

		void Delete(int id);

		POCOSpecies Get(int id);

		List<POCOSpecies> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6da1ac7e5f52d9090039f2312987d9a4</Hash>
</Codenesium>*/