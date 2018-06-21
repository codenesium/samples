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
    <Hash>72b9a3be2f34416dc71f4a1a2b4df9d8</Hash>
</Codenesium>*/