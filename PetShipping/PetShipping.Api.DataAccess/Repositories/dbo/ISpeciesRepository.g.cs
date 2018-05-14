using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>b40490b59306b72fc9dab3ca86405c28</Hash>
</Codenesium>*/