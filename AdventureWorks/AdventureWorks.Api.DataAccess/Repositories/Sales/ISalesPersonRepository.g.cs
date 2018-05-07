using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonRepository
	{
		int Create(SalesPersonModel model);

		void Update(int businessEntityID,
		            SalesPersonModel model);

		void Delete(int businessEntityID);

		POCOSalesPerson Get(int businessEntityID);

		List<POCOSalesPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ac36524c248acb979dc2cc0f4055a4d9</Hash>
</Codenesium>*/