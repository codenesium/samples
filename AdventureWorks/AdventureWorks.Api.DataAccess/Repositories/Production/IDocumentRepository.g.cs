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

		Task<List<Document>> ByFileNameRevision(string fileName, string revision, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6bf6a24f922908b4f8bcd0606b3f7b35</Hash>
</Codenesium>*/