using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>d31b73a90be6a7407d07079a8f882609</Hash>
</Codenesium>*/