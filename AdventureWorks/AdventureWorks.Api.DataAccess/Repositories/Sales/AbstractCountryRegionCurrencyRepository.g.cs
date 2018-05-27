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
	public abstract class AbstractCountryRegionCurrencyRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALCountryRegionCurrencyMapper Mapper { get; }

		public AbstractCountryRegionCurrencyRepository(
			IDALCountryRegionCurrencyMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOCountryRegionCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOCountryRegionCurrency> Get(string countryRegionCode)
		{
			CountryRegionCurrency record = await this.GetById(countryRegionCode);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOCountryRegionCurrency> Create(
			DTOCountryRegionCurrency dto)
		{
			CountryRegionCurrency record = new CountryRegionCurrency();

			this.Mapper.MapDTOToEF(
				default (string),
				dto,
				record);

			this.Context.Set<CountryRegionCurrency>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			string countryRegionCode,
			DTOCountryRegionCurrency dto)
		{
			CountryRegionCurrency record = await this.GetById(countryRegionCode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{countryRegionCode}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					countryRegionCode,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			string countryRegionCode)
		{
			CountryRegionCurrency record = await this.GetById(countryRegionCode);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CountryRegionCurrency>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOCountryRegionCurrency>> GetCurrencyCode(string currencyCode)
		{
			var records = await this.SearchLinqDTO(x => x.CurrencyCode == currencyCode);

			return records;
		}

		protected async Task<List<DTOCountryRegionCurrency>> Where(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCountryRegionCurrency> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOCountryRegionCurrency>> SearchLinqDTO(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCountryRegionCurrency> response = new List<DTOCountryRegionCurrency>();
			List<CountryRegionCurrency> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<CountryRegionCurrency>> SearchLinqEF(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegionCurrency.CountryRegionCode)} ASC";
			}
			return await this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRegionCurrency>();
		}

		private async Task<List<CountryRegionCurrency>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegionCurrency.CountryRegionCode)} ASC";
			}

			return await this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRegionCurrency>();
		}

		private async Task<CountryRegionCurrency> GetById(string countryRegionCode)
		{
			List<CountryRegionCurrency> records = await this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4346f9d8b86fc7363c707f6c849af5e7</Hash>
</Codenesium>*/