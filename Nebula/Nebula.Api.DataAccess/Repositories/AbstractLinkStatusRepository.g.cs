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
        public abstract class AbstractLinkStatusRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractLinkStatusRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<LinkStatus>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<LinkStatus> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<LinkStatus> Create(LinkStatus item)
                {
                        this.Context.Set<LinkStatus>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(LinkStatus item)
                {
                        var entity = this.Context.Set<LinkStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<LinkStatus>().Attach(item);
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
                        LinkStatus record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<LinkStatus>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<LinkStatus>> Where(Expression<Func<LinkStatus, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<LinkStatus> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<LinkStatus>> SearchLinqEF(Expression<Func<LinkStatus, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LinkStatus.Id)} ASC";
                        }

                        return await this.Context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LinkStatus>();
                }

                private async Task<List<LinkStatus>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(LinkStatus.Id)} ASC";
                        }

                        return await this.Context.Set<LinkStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<LinkStatus>();
                }

                private async Task<LinkStatus> GetById(int id)
                {
                        List<LinkStatus> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<Link>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Link>().Where(x => x.LinkStatusId == linkStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Link>();
                }
        }
}

/*<Codenesium>
    <Hash>fa19ab9c5d946f41a0525fdedd00d458</Hash>
</Codenesium>*/