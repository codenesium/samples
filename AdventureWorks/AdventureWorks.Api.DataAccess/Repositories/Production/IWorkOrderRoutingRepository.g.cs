using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRoutingRepository
	{
		Task<POCOWorkOrderRouting> Create(ApiWorkOrderRoutingModel model);

		Task Update(int workOrderID,
		            ApiWorkOrderRoutingModel model);

		Task Delete(int workOrderID);

		Task<POCOWorkOrderRouting> Get(int workOrderID);

		Task<List<POCOWorkOrderRouting>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOWorkOrderRouting>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>4bac393c3e8e75b5eb39963b023e7f5d</Hash>
</Codenesium>*/