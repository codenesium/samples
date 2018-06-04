using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IDocumentService
	{
		Task<CreateResponse<ApiDocumentResponseModel>> Create(
			ApiDocumentRequestModel model);

		Task<ActionResponse> Update(Guid documentNode,
		                            ApiDocumentRequestModel model);

		Task<ActionResponse> Delete(Guid documentNode);

		Task<ApiDocumentResponseModel> Get(Guid documentNode);

		Task<List<ApiDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiDocumentResponseModel> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode);
		Task<List<ApiDocumentResponseModel>> GetFileNameRevision(string fileName,string revision);
	}
}

/*<Codenesium>
    <Hash>1eb8b689fe93891f935a3ad913a5e894</Hash>
</Codenesium>*/