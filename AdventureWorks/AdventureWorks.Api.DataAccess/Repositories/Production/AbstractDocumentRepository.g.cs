using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractDocumentRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDocumentRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Document>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Document> Get(Guid documentNode)
                {
                        return await this.GetById(documentNode);
                }

                public async virtual Task<Document> Create(Document item)
                {
                        this.Context.Set<Document>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Document item)
                {
                        var entity = this.Context.Set<Document>().Local.FirstOrDefault(x => x.DocumentNode == item.DocumentNode);
                        if (entity == null)
                        {
                                this.Context.Set<Document>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        Guid documentNode)
                {
                        Document record = await this.GetById(documentNode);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Document>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Document> GetDocumentLevelDocumentNode(Nullable<short> documentLevel, Guid documentNode)
                {
                        var records = await this.SearchLinqEF(x => x.DocumentLevel == documentLevel && x.DocumentNode == documentNode);

                        return records.FirstOrDefault();
                }
                public async Task<List<Document>> GetFileNameRevision(string fileName, string revision)
                {
                        var records = await this.SearchLinqEF(x => x.FileName == fileName && x.Revision == revision);

                        return records;
                }

                protected async Task<List<Document>> Where(Expression<Func<Document, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Document> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Document>> SearchLinqEF(Expression<Func<Document, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Document.DocumentNode)} ASC";
                        }

                        return await this.Context.Set<Document>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Document>();
                }

                private async Task<List<Document>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Document.DocumentNode)} ASC";
                        }

                        return await this.Context.Set<Document>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Document>();
                }

                private async Task<Document> GetById(Guid documentNode)
                {
                        List<Document> records = await this.SearchLinqEF(x => x.DocumentNode == documentNode);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<ProductDocument>> ProductDocuments(Guid documentNode, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductDocument>().Where(x => x.DocumentNode == documentNode).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductDocument>();
                }
        }
}

/*<Codenesium>
    <Hash>859e3f2ee74952b86774118294973262</Hash>
</Codenesium>*/