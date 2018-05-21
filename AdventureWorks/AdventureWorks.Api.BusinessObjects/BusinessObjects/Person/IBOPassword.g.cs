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

		Task<POCOPassword> Get(int businessEntityID);

		Task<List<POCOPassword>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>190ee7f9d00402c187b5ddeef8936854</Hash>
</Codenesium>*/