using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
        public abstract class AbstractDeviceActionRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDeviceActionRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<DeviceAction>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<DeviceAction> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<DeviceAction> Create(DeviceAction item)
                {
                        this.Context.Set<DeviceAction>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(DeviceAction item)
                {
                        var entity = this.Context.Set<DeviceAction>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<DeviceAction>().Attach(item);
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
                        DeviceAction record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<DeviceAction>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<DeviceAction>> ByDeviceId(int deviceId)
                {
                        var records = await this.SearchLinqEF(x => x.DeviceId == deviceId);

                        return records;
                }

                protected async Task<List<DeviceAction>> Where(Expression<Func<DeviceAction, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<DeviceAction> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<DeviceAction>> SearchLinqEF(Expression<Func<DeviceAction, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DeviceAction.Id)} ASC";
                        }

                        return await this.Context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<DeviceAction>();
                }

                private async Task<List<DeviceAction>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DeviceAction.Id)} ASC";
                        }

                        return await this.Context.Set<DeviceAction>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<DeviceAction>();
                }

                private async Task<DeviceAction> GetById(int id)
                {
                        List<DeviceAction> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>83d394b32ba1a5f9239beca3ca0ade11</Hash>
</Codenesium>*/