using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonQuotaHistoryRepository
	{
		Task<DTOSalesPersonQuotaHistory> Create(DTOSalesPersonQuotaHistory dto);

		Task Update(int businessEntityID,
		            DTOSalesPersonQuotaHistory dto);

		Task Delete(int businessEntityID);

		Task<DTOSalesPersonQuotaHistory> Get(int businessEntityID);

		Task<List<DTOSalesPersonQuotaHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>73eb87a9481a957704fe0c94f6b237cb</Hash>
</Codenesium>*/