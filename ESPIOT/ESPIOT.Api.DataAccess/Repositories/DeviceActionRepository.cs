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

namespace ESPIOTNS.Api.DataAccess
{
	public class DeviceActionRepository : AbstractRepository, IDeviceActionRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public DeviceActionRepository(
			ILogger<IDeviceActionRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DeviceAction>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Action == null?false : x.Action.StartsWith(query)) ||
				                  (x.DeviceIdNavigation == null || x.DeviceIdNavigation.Name == null?false : x.DeviceIdNavigation.Name.StartsWith(query)) ||
				                  (x.Name == null?false : x.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
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

		// Non-unique constraint IX_DeviceAction_DeviceId.
		public async virtual Task<List<DeviceAction>> ByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.DeviceId == deviceId, limit, offset);
		}

		// Foreign key reference to table Device via deviceId.
		public async virtual Task<Device> DeviceByDeviceId(int deviceId)
		{
			return await this.Context.Set<Device>()
			       .SingleOrDefaultAsync(x => x.Id == deviceId);
		}

		protected async Task<List<DeviceAction>> Where(
			Expression<Func<DeviceAction, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<DeviceAction, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<DeviceAction>()
			       .Include(x => x.DeviceIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<DeviceAction>();
		}

		private async Task<DeviceAction> GetById(int id)
		{
			List<DeviceAction> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d85f8f3d27ccf001f719983882a3da18</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/