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
	public class SpaceRepository : AbstractRepository, ISpaceRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public SpaceRepository(
			ILogger<ISpaceRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Space>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Description == null?false : x.Description.StartsWith(query)) ||
				                  (x.Name == null?false : x.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Space> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Space> Create(Space item)
		{
			this.Context.Set<Space>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Space item)
		{
			var entity = this.Context.Set<Space>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Space>().Attach(item);
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
			Space record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Space>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table SpaceSpaceFeature via spaceId.
		public async virtual Task<List<SpaceSpaceFeature>> SpaceSpaceFeaturesBySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SpaceSpaceFeature>()
			       .Include(x => x.SpaceFeatureIdNavigation)
			       .Include(x => x.SpaceIdNavigation)

			       .Where(x => x.SpaceId == spaceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceSpaceFeature>();
		}

		protected async Task<List<Space>> Where(
			Expression<Func<Space, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Space, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Space>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Space>();
		}

		private async Task<Space> GetById(int id)
		{
			List<Space> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>36b36dfb643bfa56d4a62c15069ef604</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/