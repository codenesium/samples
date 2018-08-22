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
	public abstract class AbstractLessonStatusRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLessonStatusRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<LessonStatus>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<LessonStatus> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<LessonStatus> Create(LessonStatus item)
		{
			this.Context.Set<LessonStatus>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(LessonStatus item)
		{
			var entity = this.Context.Set<LessonStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<LessonStatus>().Attach(item);
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
			LessonStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LessonStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<LessonStatus>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.StudioId == studioId, limit, offset);

			return records;
		}

		public async virtual Task<Studio> GetStudio(int id)
		{
			return await this.Context.Set<Studio>().SingleOrDefaultAsync(x => x.Id == id);
		}

		protected async Task<List<LessonStatus>> Where(
			Expression<Func<LessonStatus, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<LessonStatus, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<LessonStatus>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<LessonStatus>();
			}
			else
			{
				return await this.Context.Set<LessonStatus>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<LessonStatus>();
			}
		}

		private async Task<LessonStatus> GetById(int id)
		{
			List<LessonStatus> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3b2193aa6050020be8b79d8f8b6cf78d</Hash>
</Codenesium>*/