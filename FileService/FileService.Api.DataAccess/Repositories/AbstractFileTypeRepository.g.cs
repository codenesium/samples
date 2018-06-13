using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public abstract class AbstractFileTypeRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractFileTypeRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<FileType>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<FileType> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<FileType> Create(FileType item)
                {
                        this.Context.Set<FileType>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(FileType item)
                {
                        var entity = this.Context.Set<FileType>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<FileType>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int id)
                {
                        FileType record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<FileType>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<FileType>> Where(Expression<Func<FileType, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<FileType> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<FileType>> SearchLinqEF(Expression<Func<FileType, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(FileType.Id)} ASC";
                        }

                        return await this.Context.Set<FileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<FileType>();
                }

                private async Task<List<FileType>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(FileType.Id)} ASC";
                        }

                        return await this.Context.Set<FileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<FileType>();
                }

                private async Task<FileType> GetById(int id)
                {
                        List<FileType> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<File>> Files(int fileTypeId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<File>().Where(x => x.FileTypeId == fileTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<File>();
                }
        }
}

/*<Codenesium>
    <Hash>1f5433bcdf1e4fcb98393afbbcb530fb</Hash>
</Codenesium>*/