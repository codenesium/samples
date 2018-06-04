using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractLessonXTeacherRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractLessonXTeacherRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<LessonXTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		protected async Task<List<LessonXTeacher>> Where(Expression<Func<LessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<LessonXTeacher> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<LessonXTeacher>> SearchLinqEF(Expression<Func<LessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonXTeacher.Id)} ASC";
			}
			return await this.Context.Set<LessonXTeacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LessonXTeacher>();
		}

		private async Task<List<LessonXTeacher>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonXTeacher.Id)} ASC";
			}

			return await this.Context.Set<LessonXTeacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LessonXTeacher>();
		}

		private async Task<LessonXTeacher> GetById(int id)
		{
			List<LessonXTeacher> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e474a4cb44e8f6e1f6f2e4b12cbd0384</Hash>
</Codenesium>*/