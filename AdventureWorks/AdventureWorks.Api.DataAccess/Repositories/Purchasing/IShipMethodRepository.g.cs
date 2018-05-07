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

		POCOShipMethod Get(int shipMethodID);

		List<POCOShipMethod> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b89e9707433905bb306e7b56e9fc4976</Hash>
</Codenesium>*/