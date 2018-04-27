using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ISpeciesRepository
	{
		int Create(SpeciesModel model);

		void Update(int id,
		            SpeciesModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOSpecies GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFSpecies, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSpecies> GetWhereDirect(Expression<Func<EFSpecies, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b19c34619e4f0d43020b2710d792c392</Hash>
</Codenesium>*/