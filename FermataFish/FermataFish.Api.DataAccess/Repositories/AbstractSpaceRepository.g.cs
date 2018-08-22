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
	public abstract class AbstractSpaceRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSpaceRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Space>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async Task<List<Space>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.StudioId == studioId, limit, offset);

			return records;
		}

		public async virtual Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SpaceXSpaceFeature>().Where(x => x.SpaceId == spaceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceXSpaceFeature>();
		}

		public async virtual Task<Studio> GetStudio(int studioId)
		{
			return await this.Context.Set<Studio>().SingleOrDefaultAsync(x => x.Id == studioId);
		}

		protected async Task<List<Space>> Where(
			Expression<Func<Space, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Space, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Space>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Space>();
			}
			else
			{
				return await this.Context.Set<Space>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Space>();
			}
		}

		private async Task<Space> GetById(int id)
		{
			List<Space> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0f2d502de75d8f0d9b387d9d88dfbab2</Hash>
</Codenesium>*/