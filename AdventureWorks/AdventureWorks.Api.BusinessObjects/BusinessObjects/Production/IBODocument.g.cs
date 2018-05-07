using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBODocument
	{
		Task<CreateResponse<Guid>> Create(
			DocumentModel model);

		Task<ActionResponse> Update(Guid documentNode,
		                            DocumentModel model);

		Task<ActionResponse> Delete(Guid documentNode);

		POCODocument Get(Guid documentNode);

		List<POCODocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>942acb458ad09955480dcfd76fa821e8</Hash>
</Codenesium>*/