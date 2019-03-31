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
	public abstract class AbstractDeviceRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDeviceRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Device>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.DateOfLastPing == query.ToDateTime() ||
				                  x.IsActive == query.ToBoolean() ||
				                  x.Name.StartsWith(query) ||
				                  x.PublicId == query.ToGuid(),
				                  limit,
				                  offset);
			}
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

		// unique constraint IX_Device.
		public async virtual Task<Device> ByPublicId(Guid publicId)
		{
			return await this.Context.Set<Device>()

			       .FirstOrDefaultAsync(x => x.PublicId == publicId);
		}

		// Foreign key reference to this table DeviceAction via deviceId.
		public async virtual Task<List<DeviceAction>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<DeviceAction>()
			       .Include(x => x.DeviceIdNavigation)

			       .Where(x => x.DeviceId == deviceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<DeviceAction>();
		}

		protected async Task<List<Device>> Where(
			Expression<Func<Device, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Device, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Device>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Device>();
		}

		private async Task<Device> GetById(int id)
		{
			List<Device> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d922635bd6e5620a7b2c5fd9e9c06ab3</Hash>
</Codenesium>*/