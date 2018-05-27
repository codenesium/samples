using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonRepository
	{
		Task<DTOSalesPerson> Create(DTOSalesPerson dto);

		Task Update(int businessEntityID,
		            DTOSalesPerson dto);

		Task Delete(int businessEntityID);

		Task<DTOSalesPerson> Get(int businessEntityID);

		Task<List<DTOSalesPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>36be79a24903f112adf7e35fd4174b6f</Hash>
</Codenesium>*/