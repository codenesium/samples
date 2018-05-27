using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IWorkOrderRepository
	{
		Task<DTOWorkOrder> Create(DTOWorkOrder dto);

		Task Update(int workOrderID,
		            DTOWorkOrder dto);

		Task Delete(int workOrderID);

		Task<DTOWorkOrder> Get(int workOrderID);

		Task<List<DTOWorkOrder>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOWorkOrder>> GetProductID(int productID);
		Task<List<DTOWorkOrder>> GetScrapReasonID(Nullable<short> scrapReasonID);
	}
}

/*<Codenesium>
    <Hash>988769c296a7aeba9eef0832b92daf5d</Hash>
</Codenesium>*/