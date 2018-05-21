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
	public abstract class AbstractCurrencyRateRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCurrencyRateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOCurrencyRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOCurrencyRate> Get(int currencyRateID)
		{
			CurrencyRate record = await this.GetById(currencyRateID);

			return this.Mapper.CurrencyRateMapEFToPOCO(record);
		}

		public async virtual Task<POCOCurrencyRate> Create(
			ApiCurrencyRateModel model)
		{
			CurrencyRate record = new CurrencyRate();

			this.Mapper.CurrencyRateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<CurrencyRate>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.CurrencyRateMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int currencyRateID,
			ApiCurrencyRateModel model)
		{
			CurrencyRate record = await this.GetById(currencyRateID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{currencyRateID}");
			}
			else
			{
				this.Mapper.CurrencyRateMapModelToEF(
					currencyRateID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int currencyRateID)
		{
			CurrencyRate record = await this.GetById(currencyRateID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CurrencyRate>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOCurrencyRate> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode)
		{
			var records = await this.SearchLinqPOCO(x => x.CurrencyRateDate == currencyRateDate && x.FromCurrencyCode == fromCurrencyCode && x.ToCurrencyCode == toCurrencyCode);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOCurrencyRate>> Where(Expression<Func<CurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCurrencyRate> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOCurrencyRate>> SearchLinqPOCO(Expression<Func<CurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCurrencyRate> response = new List<POCOCurrencyRate>();
			List<CurrencyRate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.CurrencyRateMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<CurrencyRate>> SearchLinqEF(Expression<Func<CurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CurrencyRate.CurrencyRateID)} ASC";
			}
			return await this.Context.Set<CurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CurrencyRate>();
		}

		private async Task<List<CurrencyRate>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CurrencyRate.CurrencyRateID)} ASC";
			}

			return await this.Context.Set<CurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CurrencyRate>();
		}

		private async Task<CurrencyRate> GetById(int currencyRateID)
		{
			List<CurrencyRate> records = await this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8671a03846c047b82a2abe4cfdc96aa4</Hash>
</Codenesium>*/