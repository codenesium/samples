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
        public abstract class AbstractChannelRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractChannelRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Channel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Channel> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Channel> Create(Channel item)
                {
                        this.Context.Set<Channel>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Channel item)
                {
                        var entity = this.Context.Set<Channel>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Channel>().Attach(item);
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
                        Channel record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Channel>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Channel> GetNameProjectId(string name, string projectId)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name && x.ProjectId == projectId);

                        return records.FirstOrDefault();
                }
                public async Task<List<Channel>> GetDataVersion(byte[] dataVersion)
                {
                        var records = await this.SearchLinqEF(x => x.DataVersion == dataVersion);

                        return records;
                }
                public async Task<List<Channel>> GetProjectId(string projectId)
                {
                        var records = await this.SearchLinqEF(x => x.ProjectId == projectId);

                        return records;
                }

                protected async Task<List<Channel>> Where(Expression<Func<Channel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Channel> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Channel>> SearchLinqEF(Expression<Func<Channel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Channel.Id)} ASC";
                        }

                        return await this.Context.Set<Channel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Channel>();
                }

                private async Task<List<Channel>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Channel.Id)} ASC";
                        }

                        return await this.Context.Set<Channel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Channel>();
                }

                private async Task<Channel> GetById(string id)
                {
                        List<Channel> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>97703d1b7731c30c88a0378bda065b00</Hash>
</Codenesium>*/