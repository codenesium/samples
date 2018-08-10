using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IDocumentRepository
	{
		Task<Document> Create(Document item);

		Task Update(Document item);

		Task Delete(Guid rowguid);

		Task<Document> Get(Guid rowguid);

		Task<List<Document>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Document>> ByFileNameRevision(string fileName, string revision);
	}
}

/*<Codenesium>
    <Hash>ceacb7a2773dd4e5593843595d74f882</Hash>
</Codenesium>*/