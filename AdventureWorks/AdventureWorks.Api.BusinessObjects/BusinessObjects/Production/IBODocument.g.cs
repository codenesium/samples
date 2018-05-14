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
		Task<CreateResponse<POCODocument>> Create(
			ApiDocumentModel model);

		Task<ActionResponse> Update(Guid documentNode,
		                            ApiDocumentModel model);

		Task<ActionResponse> Delete(Guid documentNode);

		POCODocument Get(Guid documentNode);

		List<POCODocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCODocument GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode);

		List<POCODocument> GetFileNameRevision(string fileName,string revision);
	}
}

/*<Codenesium>
    <Hash>66c37d33b95b203b65e830c1a6c28ac7</Hash>
</Codenesium>*/