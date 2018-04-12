using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShipMethodRepository
	{
		int Create(
			string name,
			decimal shipBase,
			decimal shipRate,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int shipMethodID,
		            string name,
		            decimal shipBase,
		            decimal shipRate,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int shipMethodID);

		Response GetById(int shipMethodID);

		POCOShipMethod GetByIdDirect(int shipMethodID);

		Response GetWhere(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShipMethod> GetWhereDirect(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6afb719455c7e331a57811b74b59a0f0</Hash>
</Codenesium>*/