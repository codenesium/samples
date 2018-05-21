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
	public abstract class AbstractLessonXStudentRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLessonXStudentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOLessonXStudent>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOLessonXStudent> Get(int id)
		{
			LessonXStudent record = await this.GetById(id);

			return this.Mapper.LessonXStudentMapEFToPOCO(record);
		}

		public async virtual Task<POCOLessonXStudent> Create(
			ApiLessonXStudentModel model)
		{
			LessonXStudent record = new LessonXStudent();

			this.Mapper.LessonXStudentMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LessonXStudent>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.LessonXStudentMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiLessonXStudentModel model)
		{
			LessonXStudent record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LessonXStudentMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOLessonXStudent>> Where(Expression<Func<LessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLessonXStudent> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOLessonXStudent>> SearchLinqPOCO(Expression<Func<LessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLessonXStudent> response = new List<POCOLessonXStudent>();
			List<LessonXStudent> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.LessonXStudentMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<LessonXStudent>> SearchLinqEF(Expression<Func<LessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonXStudent.Id)} ASC";
			}
			return await this.Context.Set<LessonXStudent>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LessonXStudent>();
		}

		private async Task<List<LessonXStudent>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonXStudent.Id)} ASC";
			}

			return await this.Context.Set<LessonXStudent>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LessonXStudent>();
		}

		private async Task<LessonXStudent> GetById(int id)
		{
			List<LessonXStudent> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7d0b61d89881e02e2becf6a08bc0c3e3</Hash>
</Codenesium>*/