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
		protected IDALCurrencyRateMapper Mapper { get; }

		public AbstractCurrencyRateRepository(
			IDALCurrencyRateMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOCurrencyRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOCurrencyRate> Get(int currencyRateID)
		{
			CurrencyRate record = await this.GetById(currencyRateID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOCurrencyRate> Create(
			DTOCurrencyRate dto)
		{
			CurrencyRate record = new CurrencyRate();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<CurrencyRate>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int currencyRateID,
			DTOCurrencyRate dto)
		{
			CurrencyRate record = await this.GetById(currencyRateID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{currencyRateID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					currencyRateID,
					dto,
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

		public async Task<DTOCurrencyRate> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode)
		{
			var records = await this.SearchLinqDTO(x => x.CurrencyRateDate == currencyRateDate && x.FromCurrencyCode == fromCurrencyCode && x.ToCurrencyCode == toCurrencyCode);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOCurrencyRate>> Where(Expression<Func<CurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCurrencyRate> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOCurrencyRate>> SearchLinqDTO(Expression<Func<CurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCurrencyRate> response = new List<DTOCurrencyRate>();
			List<CurrencyRate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>56d8c83ecfbda217c210569ed89ad853</Hash>
</Codenesium>*/