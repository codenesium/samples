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
	public abstract class AbstractLessonXTeacherRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractLessonXTeacherRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<LessonXTeacher>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<LessonXTeacher> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<LessonXTeacher> Create(LessonXTeacher item)
		{
			this.Context.Set<LessonXTeacher>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(LessonXTeacher item)
		{
			var entity = this.Context.Set<LessonXTeacher>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<LessonXTeacher>().Attach(item);
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
			LessonXTeacher record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LessonXTeacher>().Remove(record);
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

		protected async Task<List<LessonXTeacher>> Where(
			Expression<Func<LessonXTeacher, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<LessonXTeacher, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<LessonXTeacher>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<LessonXTeacher>();
			}
			else
			{
				return await this.Context.Set<LessonXTeacher>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<LessonXTeacher>();
			}
		}

		private async Task<LessonXTeacher> GetById(int id)
		{
			List<LessonXTeacher> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1a32e63c940132c63dd81e1d41108623</Hash>
</Codenesium>*/