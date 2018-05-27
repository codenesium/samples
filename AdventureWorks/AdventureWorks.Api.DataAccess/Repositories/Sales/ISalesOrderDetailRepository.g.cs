using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderDetailRepository
	{
		Task<DTOSalesOrderDetail> Create(DTOSalesOrderDetail dto);

		Task Update(int salesOrderID,
		            DTOSalesOrderDetail dto);

		Task Delete(int salesOrderID);

		Task<DTOSalesOrderDetail> Get(int salesOrderID);

		Task<List<DTOSalesOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOSalesOrderDetail>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>cf62ac67ac15d3f354edce671c107d72</Hash>
</Codenesium>*/