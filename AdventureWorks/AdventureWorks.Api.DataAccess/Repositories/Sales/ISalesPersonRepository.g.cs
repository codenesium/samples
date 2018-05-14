using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonRepository
	{
		POCOSalesPerson Create(ApiSalesPersonModel model);

		void Update(int businessEntityID,
		            ApiSalesPersonModel model);

		void Delete(int businessEntityID);

		POCOSalesPerson Get(int businessEntityID);

		List<POCOSalesPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>76aa0730e5033d4f6cc84997eab75c86</Hash>
</Codenesium>*/