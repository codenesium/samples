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
	public abstract class AbstractLessonStatusRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLessonStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOLessonStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOLessonStatus> Get(int id)
		{
			LessonStatus record = await this.GetById(id);

			return this.Mapper.LessonStatusMapEFToPOCO(record);
		}

		public async virtual Task<POCOLessonStatus> Create(
			ApiLessonStatusModel model)
		{
			LessonStatus record = new LessonStatus();

			this.Mapper.LessonStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LessonStatus>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.LessonStatusMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiLessonStatusModel model)
		{
			LessonStatus record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LessonStatusMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOLessonStatus>> Where(Expression<Func<LessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLessonStatus> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOLessonStatus>> SearchLinqPOCO(Expression<Func<LessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLessonStatus> response = new List<POCOLessonStatus>();
			List<LessonStatus> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.LessonStatusMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<LessonStatus>> SearchLinqEF(Expression<Func<LessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonStatus.Id)} ASC";
			}
			return await this.Context.Set<LessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LessonStatus>();
		}

		private async Task<List<LessonStatus>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonStatus.Id)} ASC";
			}

			return await this.Context.Set<LessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<LessonStatus>();
		}

		private async Task<LessonStatus> GetById(int id)
		{
			List<LessonStatus> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>be79d6202408379a80028727c003e4cd</Hash>
</Codenesium>*/