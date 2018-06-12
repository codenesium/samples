using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractOctopusServerNodeRepository: AbstractRepository
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

                public virtual Task<List<OctopusServerNode>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<OctopusServerNode>> Where(Expression<Func<OctopusServerNode, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<OctopusServerNode> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<OctopusServerNode>> SearchLinqEF(Expression<Func<OctopusServerNode, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(OctopusServerNode.Id)} ASC";
                        }

                        return await this.Context.Set<OctopusServerNode>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<OctopusServerNode>();
                }

                private async Task<List<OctopusServerNode>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(OctopusServerNode.Id)} ASC";
                        }

                        return await this.Context.Set<OctopusServerNode>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<OctopusServerNode>();
                }

                private async Task<OctopusServerNode> GetById(string id)
                {
                        List<OctopusServerNode> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>527789ff64088c814ed15a75e2124d4e</Hash>
</Codenesium>*/