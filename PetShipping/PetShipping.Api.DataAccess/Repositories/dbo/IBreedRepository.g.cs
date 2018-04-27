using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>4033b432b7dafe2c0f4612e60c65f77a</Hash>
</Codenesium>*/