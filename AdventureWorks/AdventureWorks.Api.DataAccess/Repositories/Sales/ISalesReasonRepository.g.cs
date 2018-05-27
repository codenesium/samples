using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesReasonRepository
	{
		Task<DTOSalesReason> Create(DTOSalesReason dto);

		Task Update(int salesReasonID,
		            DTOSalesReason dto);

		Task Delete(int salesReasonID);

		Task<DTOSalesReason> Get(int salesReasonID);

		Task<List<DTOSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>99f7f04355f5f9b061417915eaed7f06</Hash>
</Codenesium>*/