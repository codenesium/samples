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
	public abstract class AbstractLessonRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLessonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOLesson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOLesson> Get(int id)
		{
			Lesson record = await this.GetById(id);

			return this.Mapper.LessonMapEFToPOCO(record);
		}

		public async virtual Task<POCOLesson> Create(
			ApiLessonModel model)
		{
			Lesson record = new Lesson();

			this.Mapper.LessonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Lesson>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.LessonMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiLessonModel model)
		{
			Lesson record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LessonMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOLesson>> Where(Expression<Func<Lesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLesson> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOLesson>> SearchLinqPOCO(Expression<Func<Lesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLesson> response = new List<POCOLesson>();
			List<Lesson> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.LessonMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Lesson>> SearchLinqEF(Expression<Func<Lesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Lesson.Id)} ASC";
			}
			return await this.Context.Set<Lesson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Lesson>();
		}

		private async Task<List<Lesson>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Lesson.Id)} ASC";
			}

			return await this.Context.Set<Lesson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Lesson>();
		}

		private async Task<Lesson> GetById(int id)
		{
			List<Lesson> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>183f007ca822e559f6ed566cf521cbf3</Hash>
</Codenesium>*/