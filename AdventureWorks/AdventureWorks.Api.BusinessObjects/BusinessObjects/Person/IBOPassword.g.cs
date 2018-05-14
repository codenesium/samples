using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPassword
	{
		Task<CreateResponse<POCOPassword>> Create(
			ApiPasswordModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiPasswordModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOPassword Get(int businessEntityID);

		List<POCOPassword> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5dc1c847c85cb293e04b69701384bbf8</Hash>
</Codenesium>*/