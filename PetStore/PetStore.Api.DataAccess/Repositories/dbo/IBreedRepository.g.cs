using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IBreedRepository
	{
		int Create(BreedModel model);

		void Update(int id,
		            BreedModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOBreed GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFBreed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBreed> GetWhereDirect(Expression<Func<EFBreed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cf0514bab9b00dd855063f032e96d240</Hash>
</Codenesium>*/