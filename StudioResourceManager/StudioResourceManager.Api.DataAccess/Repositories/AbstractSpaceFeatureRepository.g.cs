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

namespace StudioResourceManagerNS.Api.DataAccess
{
	public abstract class AbstractSpaceFeatureRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSpaceFeatureRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SpaceFeature>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SpaceFeature> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<SpaceFeature> Create(SpaceFeature item)
		{
			this.Context.Set<SpaceFeature>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SpaceFeature item)
		{
			var entity = this.Context.Set<SpaceFeature>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<SpaceFeature>().Attach(item);
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
			SpaceFeature record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpaceFeature>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<SpaceFeature>> BySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.SpaceSpaceFeatures
			              join spaceFeatures in this.Context.SpaceFeatures on
			              refTable.SpaceFeatureId equals spaceFeatures.Id
			              where refTable.SpaceId == spaceId
			              select spaceFeatures).Skip(offset).Take(limit).ToListAsync();
		}

		public async virtual Task<SpaceSpaceFeature> CreateSpaceSpaceFeature(SpaceSpaceFeature item)
		{
			this.Context.Set<SpaceSpaceFeature>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task DeleteSpaceSpaceFeature(SpaceSpaceFeature item)
		{
			this.Context.Set<SpaceSpaceFeature>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		protected async Task<List<SpaceFeature>> Where(
			Expression<Func<SpaceFeature, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SpaceFeature, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<SpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SpaceFeature>();
		}

		private async Task<SpaceFeature> GetById(int id)
		{
			List<SpaceFeature> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>480de7a56f17ac3f3e0e4d8a7c990988</Hash>
</Codenesium>*/