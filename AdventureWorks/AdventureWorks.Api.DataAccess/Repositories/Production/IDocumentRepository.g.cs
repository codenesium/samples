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

		Task<List<Document>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>79c923334f7aad78595d0e5eea849b97</Hash>
</Codenesium>*/