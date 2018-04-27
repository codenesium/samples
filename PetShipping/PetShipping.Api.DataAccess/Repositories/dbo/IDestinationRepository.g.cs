using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IDestinationRepository
	{
		int Create(DestinationModel model);

		void Update(int id,
		            DestinationModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCODestination GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODestination> GetWhereDirect(Expression<Func<EFDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ae8018af688c787a5a3954aaa1772055</Hash>
</Codenesium>*/