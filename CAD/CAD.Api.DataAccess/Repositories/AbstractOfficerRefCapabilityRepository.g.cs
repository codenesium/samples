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
	public abstract class AbstractOfficerRefCapabilityRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractOfficerRefCapabilityRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<OfficerRefCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CapabilityId == query.ToInt() ||
				                  x.Id == query.ToInt() ||
				                  x.OfficerId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<OfficerRefCapability> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<OfficerRefCapability> Create(OfficerRefCapability item)
		{
			this.Context.Set<OfficerRefCapability>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(OfficerRefCapability item)
		{
			var entity = this.Context.Set<OfficerRefCapability>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<OfficerRefCapability>().Attach(item);
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
			OfficerRefCapability record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<OfficerRefCapability>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table OfficerCapability via capabilityId.
		public async virtual Task<OfficerCapability> OfficerCapabilityByCapabilityId(int capabilityId)
		{
			return await this.Context.Set<OfficerCapability>()
			       .SingleOrDefaultAsync(x => x.Id == capabilityId);
		}

		// Foreign key reference to table Officer via officerId.
		public async virtual Task<Officer> OfficerByOfficerId(int officerId)
		{
			return await this.Context.Set<Officer>()
			       .SingleOrDefaultAsync(x => x.Id == officerId);
		}

		protected async Task<List<OfficerRefCapability>> Where(
			Expression<Func<OfficerRefCapability, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<OfficerRefCapability, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<OfficerRefCapability>()
			       .Include(x => x.CapabilityIdNavigation)
			       .Include(x => x.OfficerIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<OfficerRefCapability>();
		}

		private async Task<OfficerRefCapability> GetById(int id)
		{
			List<OfficerRefCapability> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2f215a0bb63012d539d4e4551106c771</Hash>
</Codenesium>*/