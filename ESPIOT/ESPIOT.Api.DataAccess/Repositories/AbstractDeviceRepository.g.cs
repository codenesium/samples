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
        public abstract class AbstractDeviceRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDeviceRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Device>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Device> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Device> Create(Device item)
                {
                        this.Context.Set<Device>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Device item)
                {
                        var entity = this.Context.Set<Device>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Device>().Attach(item);
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
                        Device record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Device>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Device> ByPublicId(Guid publicId)
                {
                        var records = await this.SearchLinqEF(x => x.PublicId == publicId);

                        return records.FirstOrDefault();
                }

                protected async Task<List<Device>> Where(Expression<Func<Device, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Device> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Device>> SearchLinqEF(Expression<Func<Device, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Device.Id)} ASC";
                        }

                        return await this.Context.Set<Device>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Device>();
                }

                private async Task<List<Device>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Device.Id)} ASC";
                        }

                        return await this.Context.Set<Device>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Device>();
                }

                private async Task<Device> GetById(int id)
                {
                        List<Device> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<DeviceAction>> DeviceActions(int deviceId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<DeviceAction>().Where(x => x.DeviceId == deviceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<DeviceAction>();
                }
        }
}

/*<Codenesium>
    <Hash>6bb34772a09b334f8bf85b3f6ff9f808</Hash>
</Codenesium>*/