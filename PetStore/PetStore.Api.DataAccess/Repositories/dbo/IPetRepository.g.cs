using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPetRepository
	{
		int Create(PetModel model);

		void Update(int id,
		            PetModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOPet GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPet, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPet> GetWhereDirect(Expression<Func<EFPet, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>12c3be8dc44015ff03df56bae0de0b41</Hash>
</Codenesium>*/