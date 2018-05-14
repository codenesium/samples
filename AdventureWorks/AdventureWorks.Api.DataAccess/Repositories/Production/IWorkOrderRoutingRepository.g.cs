using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRoutingRepository
	{
		POCOWorkOrderRouting Create(ApiWorkOrderRoutingModel model);

		void Update(int workOrderID,
		            ApiWorkOrderRoutingModel model);

		void Delete(int workOrderID);

		POCOWorkOrderRouting Get(int workOrderID);

		List<POCOWorkOrderRouting> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOWorkOrderRouting> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>b3f5dea0205818ff42e5874c6b670e25</Hash>
</Codenesium>*/