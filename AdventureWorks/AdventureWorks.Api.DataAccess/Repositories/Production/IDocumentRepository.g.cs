using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDocumentRepository
	{
		Task<POCODocument> Create(ApiDocumentModel model);

		Task Update(Guid documentNode,
		            ApiDocumentModel model);

		Task Delete(Guid documentNode);

		Task<POCODocument> Get(Guid documentNode);

		Task<List<POCODocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCODocument> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode);
		Task<List<POCODocument>> GetFileNameRevision(string fileName,string revision);
	}
}

/*<Codenesium>
    <Hash>8f468c5a2a76a95b524f407d7d39797c</Hash>
</Codenesium>*/