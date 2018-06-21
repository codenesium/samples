using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractOctopusServerNodeRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractOctopusServerNodeRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<OctopusServerNode>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<OctopusServerNode> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<OctopusServerNode> Create(OctopusServerNode item)
                {
                        this.Context.Set<OctopusServerNode>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(OctopusServerNode item)
                {
                        var entity = this.Context.Set<OctopusServerNode>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<OctopusServerNode>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string id)
                {
                        OctopusServerNode record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<OctopusServerNode>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<OctopusServerNode>> Where(
                        Expression<Func<OctopusServerNode, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<OctopusServerNode, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<OctopusServerNode>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<OctopusServerNode>();
                        }
                        else
                        {
                                return await this.Context.Set<OctopusServerNode>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<OctopusServerNode>();
                        }
                }

                private async Task<OctopusServerNode> GetById(string id)
                {
                        List<OctopusServerNode> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>87f13115b3356bc753ad784d71362ee4</Hash>
</Codenesium>*/