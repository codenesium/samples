using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDocumentRepository
	{
		Task<Document> Create(Document item);

		Task Update(Document item);

		Task Delete(Guid documentNode);

		Task<Document> Get(Guid documentNode);

		Task<List<Document>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<Document> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode);
		Task<List<Document>> GetFileNameRevision(string fileName,string revision);
	}
}

/*<Codenesium>
    <Hash>2b8e47594f6be4c87f3c1af9eb621ad7</Hash>
</Codenesium>*/