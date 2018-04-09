using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShipMethodRepository
	{
		int Create(string name,
		           decimal shipBase,
		           decimal shipRate,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int shipMethodID, string name,
		            decimal shipBase,
		            decimal shipRate,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int shipMethodID);

		Response GetById(int shipMethodID);

		POCOShipMethod GetByIdDirect(int shipMethodID);

		Response GetWhere(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOShipMethod> GetWhereDirect(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9c15597ef04dd1a16f3bb08b60784f8a</Hash>
</Codenesium>*/