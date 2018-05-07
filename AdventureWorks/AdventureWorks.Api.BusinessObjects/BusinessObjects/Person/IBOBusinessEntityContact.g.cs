using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntityContact
	{
		Task<CreateResponse<int>> Create(
			BusinessEntityContactModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            BusinessEntityContactModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOBusinessEntityContact Get(int businessEntityID);

		List<POCOBusinessEntityContact> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>835acdac5913d2fbef98269e23ec9eaf</Hash>
</Codenesium>*/