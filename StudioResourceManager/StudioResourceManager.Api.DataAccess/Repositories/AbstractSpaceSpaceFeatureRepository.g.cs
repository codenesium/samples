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
	public abstract class AbstractSpaceSpaceFeatureRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSpaceSpaceFeatureRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SpaceSpaceFeature>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SpaceSpaceFeature> Get(int spaceId)
		{
			return await this.GetById(spaceId);
		}

		public async virtual Task<SpaceSpaceFeature> Create(SpaceSpaceFeature item)
		{
			this.Context.Set<SpaceSpaceFeature>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SpaceSpaceFeature item)
		{
			var entity = this.Context.Set<SpaceSpaceFeature>().Local.FirstOrDefault(x => x.SpaceId == item.SpaceId);
			if (entity == null)
			{
				this.Context.Set<SpaceSpaceFeature>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int spaceId)
		{
			SpaceSpaceFeature record = await this.GetById(spaceId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpaceSpaceFeature>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<SpaceFeature> SpaceFeatureBySpaceFeatureId(int spaceFeatureId)
		{
			return await this.Context.Set<SpaceFeature>().SingleOrDefaultAsync(x => x.Id == spaceFeatureId);
		}

		public async virtual Task<Space> SpaceBySpaceId(int spaceId)
		{
			return await this.Context.Set<Space>().SingleOrDefaultAsync(x => x.Id == spaceId);
		}

		protected async Task<List<SpaceSpaceFeature>> Where(
			Expression<Func<SpaceSpaceFeature, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SpaceSpaceFeature, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.SpaceId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SpaceSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SpaceSpaceFeature>();
			}
			else
			{
				return await this.Context.Set<SpaceSpaceFeature>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SpaceSpaceFeature>();
			}
		}

		private async Task<SpaceSpaceFeature> GetById(int spaceId)
		{
			List<SpaceSpaceFeature> records = await this.Where(x => x.SpaceId == spaceId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1061ce2cb82ecad7a9c56c2c95bdfbeb</Hash>
</Codenesium>*/