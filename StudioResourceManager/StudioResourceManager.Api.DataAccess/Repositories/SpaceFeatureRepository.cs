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
	public class SpaceFeatureRepository : AbstractRepository, ISpaceFeatureRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public SpaceFeatureRepository(
			ILogger<ISpaceFeatureRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SpaceFeature>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Name == null?false : x.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
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

		// Foreign key reference to this table SpaceSpaceFeature via spaceFeatureId.
		public async virtual Task<List<SpaceSpaceFeature>> SpaceSpaceFeaturesBySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SpaceSpaceFeature>()
			       .Include(x => x.SpaceFeatureIdNavigation)
			       .Include(x => x.SpaceIdNavigation)

			       .Where(x => x.SpaceFeatureId == spaceFeatureId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceSpaceFeature>();
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

			return await this.Context.Set<SpaceFeature>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SpaceFeature>();
		}

		private async Task<SpaceFeature> GetById(int id)
		{
			List<SpaceFeature> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>752f6182f79748374b89f95482fed60d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/