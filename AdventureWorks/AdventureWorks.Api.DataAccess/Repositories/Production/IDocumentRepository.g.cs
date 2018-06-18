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

                Task Delete(Guid rowguid);

                Task<Document> Get(Guid rowguid);

                Task<List<Document>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Document>> ByFileNameRevision(string fileName, string revision);
        }
}

/*<Codenesium>
    <Hash>fae9bb41712a17d554fecf55c0c3bf22</Hash>
</Codenesium>*/