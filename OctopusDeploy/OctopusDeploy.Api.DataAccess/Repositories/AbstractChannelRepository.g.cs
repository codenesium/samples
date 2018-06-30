using Codenesium.DataConversionExtensions;
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
        public abstract class AbstractChannelRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractChannelRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Channel>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async Task<Channel> ByNameProjectId(string name, string projectId)
                {
                        var records = await this.Where(x => x.Name == name && x.ProjectId == projectId);

                        return records.FirstOrDefault();
                }

                public async Task<List<Channel>> ByDataVersion(byte[] dataVersion)
                {
                        var records = await this.Where(x => x.DataVersion == dataVersion);

                        return records;
                }

                public async Task<List<Channel>> ByProjectId(string projectId)
                {
                        var records = await this.Where(x => x.ProjectId == projectId);

                        return records;
                }

                protected async Task<List<Channel>> Where(
                        Expression<Func<Channel, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Channel, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Channel>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Channel>();
                        }
                        else
                        {
                                return await this.Context.Set<Channel>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Channel>();
                        }
                }

                private async Task<Channel> GetById(string id)
                {
                        List<Channel> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>7c607e1f487a1846f30237663ddaf8e8</Hash>
</Codenesium>*/