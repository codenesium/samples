using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public abstract class AbstractLinkLogRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractLinkLogRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<LinkLog>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<LinkLog> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<LinkLog> Create(LinkLog item)
                {
                        this.Context.Set<LinkLog>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(LinkLog item)
                {
                        var entity = this.Context.Set<LinkLog>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<LinkLog>().Attach(item);
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
                        LinkLog record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<LinkLog>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<LinkLog>> Where(Expression<Func<LinkLog, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<LinkLog> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<LinkLog>> SearchLinqEF(Expression<Func<LinkLog, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LinkLog.Id)} ASC";
                        }

                        return await this.Context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LinkLog>();
                }

                private async Task<List<LinkLog>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LinkLog.Id)} ASC";
                        }

                        return await this.Context.Set<LinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LinkLog>();
                }

                private async Task<LinkLog> GetById(int id)
                {
                        List<LinkLog> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>10c0734e119604850a245d98770f9050</Hash>
</Codenesium>*/