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
	public abstract class AbstractOfficerCapabilityRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractOfficerCapabilityRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<OfficerCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<OfficerCapability> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<OfficerCapability> Create(OfficerCapability item)
		{
			this.Context.Set<OfficerCapability>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(OfficerCapability item)
		{
			var entity = this.Context.Set<OfficerCapability>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<OfficerCapability>().Attach(item);
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
			OfficerCapability record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<OfficerCapability>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table OfficerRefCapability via capabilityId.
		public async virtual Task<List<OfficerRefCapability>> OfficerRefCapabilitiesByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<OfficerRefCapability>()
			       .Include(x => x.CapabilityIdNavigation)
			       .Where(x => x.CapabilityId == capabilityId).AsQueryable().Skip(offset).Take(limit).ToListAsync<OfficerRefCapability>();
		}

		protected async Task<List<OfficerCapability>> Where(
			Expression<Func<OfficerCapability, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<OfficerCapability, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<OfficerCapability>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<OfficerCapability>();
		}

		private async Task<OfficerCapability> GetById(int id)
		{
			List<OfficerCapability> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6867b499f32d57b247504f0699ab1aa9</Hash>
</Codenesium>*/