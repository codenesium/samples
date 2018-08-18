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
	public abstract class AbstractLessonXStudentRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLessonXStudentRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<LessonXStudent>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<LessonXStudent> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<LessonXStudent> Create(LessonXStudent item)
		{
			this.Context.Set<LessonXStudent>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(LessonXStudent item)
		{
			var entity = this.Context.Set<LessonXStudent>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<LessonXStudent>().Attach(item);
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
			LessonXStudent record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LessonXStudent>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Lesson> GetLesson(int lessonId)
		{
			return await this.Context.Set<Lesson>().SingleOrDefaultAsync(x => x.Id == lessonId);
		}

		public async virtual Task<Student> GetStudent(int studentId)
		{
			return await this.Context.Set<Student>().SingleOrDefaultAsync(x => x.Id == studentId);
		}

		protected async Task<List<LessonXStudent>> Where(
			Expression<Func<LessonXStudent, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<LessonXStudent, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<LessonXStudent>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<LessonXStudent>();
			}
			else
			{
				return await this.Context.Set<LessonXStudent>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<LessonXStudent>();
			}
		}

		private async Task<LessonXStudent> GetById(int id)
		{
			List<LessonXStudent> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8f5e7989f06aaf59918da3372489188b</Hash>
</Codenesium>*/