using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDocumentRepository
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
    <Hash>74a84fa7cc1b5bf16a353b56a0ce5f8c</Hash>
</Codenesium>*/