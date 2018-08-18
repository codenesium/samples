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
	public abstract class AbstractLessonRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLessonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Lesson>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Lesson> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Lesson> Create(Lesson item)
		{
			this.Context.Set<Lesson>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Lesson item)
		{
			var entity = this.Context.Set<Lesson>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Lesson>().Attach(item);
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
			Lesson record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Lesson>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<LessonXStudent>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<LessonXStudent>().Where(x => x.LessonId == lessonId).AsQueryable().Skip(offset).Take(limit).ToListAsync<LessonXStudent>();
		}

		public async virtual Task<List<LessonXTeacher>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<LessonXTeacher>().Where(x => x.LessonId == lessonId).AsQueryable().Skip(offset).Take(limit).ToListAsync<LessonXTeacher>();
		}

		public async virtual Task<LessonStatus> GetLessonStatus(int lessonStatusId)
		{
			return await this.Context.Set<LessonStatus>().SingleOrDefaultAsync(x => x.Id == lessonStatusId);
		}

		public async virtual Task<Studio> GetStudio(int studioId)
		{
			return await this.Context.Set<Studio>().SingleOrDefaultAsync(x => x.Id == studioId);
		}

		protected async Task<List<Lesson>> Where(
			Expression<Func<Lesson, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Lesson, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Lesson>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Lesson>();
			}
			else
			{
				return await this.Context.Set<Lesson>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Lesson>();
			}
		}

		private async Task<Lesson> GetById(int id)
		{
			List<Lesson> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5278755b712e048f5dac332104ebbad3</Hash>
</Codenesium>*/