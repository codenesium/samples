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
	public class SpaceSpaceFeatureRepository : AbstractRepository, ISpaceSpaceFeatureRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public SpaceSpaceFeatureRepository(
			ILogger<ISpaceSpaceFeatureRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SpaceSpaceFeature>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.SpaceFeatureIdNavigation == null || x.SpaceFeatureIdNavigation.Name == null?false : x.SpaceFeatureIdNavigation.Name.StartsWith(query)) ||
				                  (x.SpaceIdNavigation == null || x.SpaceIdNavigation.Name == null?false : x.SpaceIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<SpaceSpaceFeature> Get(int id)
		{
			return await this.GetById(id);
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
			var entity = this.Context.Set<SpaceSpaceFeature>().Local.FirstOrDefault(x => x.Id == item.Id);
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
			int id)
		{
			SpaceSpaceFeature record = await this.GetById(id);

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

		// Non-unique constraint IX_SpaceSpaceFeature_spaceFeatureId.
		public async virtual Task<List<SpaceSpaceFeature>> BySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.SpaceFeatureId == spaceFeatureId, limit, offset);
		}

		// Non-unique constraint IX_SpaceSpaceFeature_spaceId.
		public async virtual Task<List<SpaceSpaceFeature>> BySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.SpaceId == spaceId, limit, offset);
		}

		// Foreign key reference to table SpaceFeature via spaceFeatureId.
		public async virtual Task<SpaceFeature> SpaceFeatureBySpaceFeatureId(int spaceFeatureId)
		{
			return await this.Context.Set<SpaceFeature>()
			       .SingleOrDefaultAsync(x => x.Id == spaceFeatureId);
		}

		// Foreign key reference to table Space via spaceId.
		public async virtual Task<Space> SpaceBySpaceId(int spaceId)
		{
			return await this.Context.Set<Space>()
			       .SingleOrDefaultAsync(x => x.Id == spaceId);
		}

		protected async Task<List<SpaceSpaceFeature>> Where(
			Expression<Func<SpaceSpaceFeature, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SpaceSpaceFeature, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<SpaceSpaceFeature>()
			       .Include(x => x.SpaceFeatureIdNavigation)
			       .Include(x => x.SpaceIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SpaceSpaceFeature>();
		}

		private async Task<SpaceSpaceFeature> GetById(int id)
		{
			List<SpaceSpaceFeature> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7faec0c096af114acb919dbbba302142</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/