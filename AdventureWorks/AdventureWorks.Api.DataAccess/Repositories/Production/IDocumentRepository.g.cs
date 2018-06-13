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

                Task<List<Document>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Document> GetDocumentLevelDocumentNode(Nullable<short> documentLevel, Guid documentNode);
                Task<List<Document>> GetFileNameRevision(string fileName, string revision);

                Task<List<ProductDocument>> ProductDocuments(Guid documentNode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c973fb91d51f84a8a2af27c97f52d44e</Hash>
</Codenesium>*/