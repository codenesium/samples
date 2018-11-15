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

		Task<Document> ByRowguid(Guid rowguid);

		Task<List<Document>> ByFileNameRevision(string fileName, string revision, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d0004bb9bacec2b43c7129ade5e60fd8</Hash>
</Codenesium>*/