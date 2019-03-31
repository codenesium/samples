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

namespace CADNS.Api.DataAccess
{
	public abstract class AbstractOffCapabilityRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractOffCapabilityRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<OffCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<OffCapability> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<OffCapability> Create(OffCapability item)
		{
			this.Context.Set<OffCapability>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(OffCapability item)
		{
			var entity = this.Context.Set<OffCapability>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<OffCapability>().Attach(item);
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
			OffCapability record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<OffCapability>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table OfficerCapabilities via capabilityId.
		public async virtual Task<List<OfficerCapabilities>> OfficerCapabilitiesByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<OfficerCapabilities>()
			       .Include(x => x.CapabilityIdNavigation)
			       .Include(x => x.OfficerIdNavigation)

			       .Where(x => x.CapabilityId == capabilityId).AsQueryable().Skip(offset).Take(limit).ToListAsync<OfficerCapabilities>();
		}

		protected async Task<List<OffCapability>> Where(
			Expression<Func<OffCapability, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<OffCapability, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<OffCapability>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<OffCapability>();
		}

		private async Task<OffCapability> GetById(int id)
		{
			List<OffCapability> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e30ecf7112b058e5776cf51bc2a4fc71</Hash>
</Codenesium>*/