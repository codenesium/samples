using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShipMethodRepository
	{
		Task<POCOShipMethod> Create(ApiShipMethodModel model);

		Task Update(int shipMethodID,
		            ApiShipMethodModel model);

		Task Delete(int shipMethodID);

		Task<POCOShipMethod> Get(int shipMethodID);

		Task<List<POCOShipMethod>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOShipMethod> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>a9188371107b15a8997adeac605b911b</Hash>
</Codenesium>*/