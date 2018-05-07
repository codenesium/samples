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
		Task<CreateResponse<int>> Create(
			PasswordModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            PasswordModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOPassword Get(int businessEntityID);

		List<POCOPassword> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1d76d2f05b9d7451ebbd3010aed96b3c</Hash>
</Codenesium>*/