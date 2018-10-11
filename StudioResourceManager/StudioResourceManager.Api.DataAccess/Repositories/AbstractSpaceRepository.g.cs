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

		public async virtual Task<List<SpaceSpaceFeature>> SpaceSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SpaceSpaceFeature>().Where(x => x.SpaceId == spaceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceSpaceFeature>();
		}

		// Reference foreign key. Reference Table=SpaceSpaceFeature. First table=spaces. Second table=spaceFeatures
		public async virtual Task<List<Space>> BySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.SpaceSpaceFeatures
			              join spaces in this.Context.Spaces on
			              refTable.SpaceId equals spaces.Id
			              where refTable.SpaceFeatureId == spaceFeatureId
			              select spaces).Skip(offset).Take(limit).ToListAsync();
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
    <Hash>80ae601a2b9079cd5bb529c6d4e76ea5</Hash>
</Codenesium>*/