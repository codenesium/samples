using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractScrapReasonRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractScrapReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOScrapReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOScrapReason> Get(short scrapReasonID)
		{
			ScrapReason record = await this.GetById(scrapReasonID);

			return this.Mapper.ScrapReasonMapEFToPOCO(record);
		}

		public async virtual Task<POCOScrapReason> Create(
			ApiScrapReasonModel model)
		{
			ScrapReason record = new ScrapReason();

			this.Mapper.ScrapReasonMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<ScrapReason>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ScrapReasonMapEFToPOCO(record);
		}

		public async virtual Task Update(
			short scrapReasonID,
			ApiScrapReasonModel model)
		{
			ScrapReason record = await this.GetById(scrapReasonID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{scrapReasonID}");
			}
			else
			{
				this.Mapper.ScrapReasonMapModelToEF(
					scrapReasonID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			short scrapReasonID)
		{
			ScrapReason record = await this.GetById(scrapReasonID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ScrapReason>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOScrapReason> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOScrapReason>> Where(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOScrapReason> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOScrapReason>> SearchLinqPOCO(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOScrapReason> response = new List<POCOScrapReason>();
			List<ScrapReason> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ScrapReasonMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ScrapReason>> SearchLinqEF(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
			}
			return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ScrapReason>();
		}

		private async Task<List<ScrapReason>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
			}

			return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ScrapReason>();
		}

		private async Task<ScrapReason> GetById(short scrapReasonID)
		{
			List<ScrapReason> records = await this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f4cd8e217df151bd7d45003d74067bc9</Hash>
</Codenesium>*/