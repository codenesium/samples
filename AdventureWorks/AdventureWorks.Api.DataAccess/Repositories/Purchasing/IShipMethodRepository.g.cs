using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShipMethodRepository
	{
		POCOShipMethod Create(ApiShipMethodModel model);

		void Update(int shipMethodID,
		            ApiShipMethodModel model);

		void Delete(int shipMethodID);

		POCOShipMethod Get(int shipMethodID);

		List<POCOShipMethod> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOShipMethod GetName(string name);
	}
}

/*<Codenesium>
    <Hash>cad769837d16de72aa3de08d4f773f1f</Hash>
</Codenesium>*/