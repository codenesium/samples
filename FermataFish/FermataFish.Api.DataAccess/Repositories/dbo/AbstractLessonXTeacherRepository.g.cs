using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractLessonXTeacherRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLessonXTeacherRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOLessonXTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOLessonXTeacher> Get(int id)
		{
			LessonXTeacher record = await this.GetById(id);

			return this.Mapper.LessonXTeacherMapEFToPOCO(record);
		}

		public async virtual Task<POCOLessonXTeacher> Create(
			ApiLessonXTeacherModel model)
		{
			LessonXTeacher record = new LessonXTeacher();

			this.Mapper.LessonXTeacherMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LessonXTeacher>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.LessonXTeacherMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiLessonXTeacherModel model)
		{
			LessonXTeacher record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LessonXTeacherMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOLessonXTeacher>> Where(Expression<Func<LessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLessonXTeacher> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOLessonXTeacher>> SearchLinqPOCO(Expression<Func<LessonXTeacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLessonXTeacher> response = new List<POCOLessonXTeacher>();
			List<LessonXTeacher> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.LessonXTeacherMapEFToPOCO(x)));
			return response;
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
    <Hash>6c7837619472d3829fff6f483ec46705</Hash>
</Codenesium>*/