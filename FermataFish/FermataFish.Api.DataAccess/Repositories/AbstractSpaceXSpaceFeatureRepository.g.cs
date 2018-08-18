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

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractSpaceXSpaceFeatureRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSpaceXSpaceFeatureRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SpaceXSpaceFeature>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SpaceXSpaceFeature> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<SpaceXSpaceFeature> Create(SpaceXSpaceFeature item)
		{
			this.Context.Set<SpaceXSpaceFeature>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SpaceXSpaceFeature item)
		{
			var entity = this.Context.Set<SpaceXSpaceFeature>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<SpaceXSpaceFeature>().Attach(item);
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
			SpaceXSpaceFeature record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpaceXSpaceFeature>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<SpaceFeature> GetSpaceFeature(int spaceFeatureId)
		{
			return await this.Context.Set<SpaceFeature>().SingleOrDefaultAsync(x => x.Id == spaceFeatureId);
		}

		public async virtual Task<Space> GetSpace(int spaceId)
		{
			return await this.Context.Set<Space>().SingleOrDefaultAsync(x => x.Id == spaceId);
		}

		protected async Task<List<SpaceXSpaceFeature>> Where(
			Expression<Func<SpaceXSpaceFeature, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SpaceXSpaceFeature, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SpaceXSpaceFeature>();
			}
			else
			{
				return await this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SpaceXSpaceFeature>();
			}
		}

		private async Task<SpaceXSpaceFeature> GetById(int id)
		{
			List<SpaceXSpaceFeature> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ca3f8b7f146f38c70af3055fab957ad3</Hash>
</Codenesium>*/