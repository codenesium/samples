using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRoutingRepository
	{
		Task<DTOWorkOrderRouting> Create(DTOWorkOrderRouting dto);

		Task Update(int workOrderID,
		            DTOWorkOrderRouting dto);

		Task Delete(int workOrderID);

		Task<DTOWorkOrderRouting> Get(int workOrderID);

		Task<List<DTOWorkOrderRouting>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOWorkOrderRouting>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>a90f613af67913ff0d970f28af934050</Hash>
</Codenesium>*/