using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>00e4a14eb6dd404a354b6212c61ab213</Hash>
</Codenesium>*/