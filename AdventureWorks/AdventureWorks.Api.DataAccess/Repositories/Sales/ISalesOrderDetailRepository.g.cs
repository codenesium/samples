using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderDetailRepository
	{
		Task<SalesOrderDetail> Create(SalesOrderDetail item);

		Task Update(SalesOrderDetail item);

		Task Delete(int salesOrderID);

		Task<SalesOrderDetail> Get(int salesOrderID);

		Task<List<SalesOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<SalesOrderDetail>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>8aafe8e656334376f77afc2c1c26f6ab</Hash>
</Codenesium>*/