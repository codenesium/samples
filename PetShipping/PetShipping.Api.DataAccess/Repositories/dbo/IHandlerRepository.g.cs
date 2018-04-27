using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerRepository
	{
		int Create(HandlerModel model);

		void Update(int id,
		            HandlerModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOHandler GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFHandler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOHandler> GetWhereDirect(Expression<Func<EFHandler, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9885319dc2e55df585891c79d5a04437</Hash>
</Codenesium>*/