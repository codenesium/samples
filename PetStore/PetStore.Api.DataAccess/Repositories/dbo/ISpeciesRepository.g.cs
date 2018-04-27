using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>473e9c9ca3d9260743fe25d1c18348a8</Hash>
</Codenesium>*/