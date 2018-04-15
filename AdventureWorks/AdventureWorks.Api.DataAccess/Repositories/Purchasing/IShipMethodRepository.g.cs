using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShipMethodRepository
	{
		int Create(ShipMethodModel model);

		void Update(int shipMethodID,
		            ShipMethodModel model);

		void Delete(int shipMethodID);

		ApiResponse GetById(int shipMethodID);

		POCOShipMethod GetByIdDirect(int shipMethodID);

		ApiResponse GetWhere(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShipMethod> GetWhereDirect(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0a0f908c2684aa7bf223a7925c44d321</Hash>
</Codenesium>*/