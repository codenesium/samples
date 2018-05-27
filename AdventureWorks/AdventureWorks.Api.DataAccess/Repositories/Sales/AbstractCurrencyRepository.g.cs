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
	public abstract class AbstractCurrencyRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALCurrencyMapper Mapper { get; }

		public AbstractCurrencyRepository(
			IDALCurrencyMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOCurrency> Get(string currencyCode)
		{
			Currency record = await this.GetById(currencyCode);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOCurrency> Create(
			DTOCurrency dto)
		{
			Currency record = new Currency();

			this.Mapper.MapDTOToEF(
				default (string),
				dto,
				record);

			this.Context.Set<Currency>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			string currencyCode,
			DTOCurrency dto)
		{
			Currency record = await this.GetById(currencyCode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{currencyCode}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					currencyCode,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			string currencyCode)
		{
			Currency record = await this.GetById(currencyCode);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Currency>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOCurrency> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOCurrency>> Where(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCurrency> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOCurrency>> SearchLinqDTO(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCurrency> response = new List<DTOCurrency>();
			List<Currency> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<Currency>> SearchLinqEF(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Currency.CurrencyCode)} ASC";
			}
			return await this.Context.Set<Currency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Currency>();
		}

		private async Task<List<Currency>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Currency.CurrencyCode)} ASC";
			}

			return await this.Context.Set<Currency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Currency>();
		}

		private async Task<Currency> GetById(string currencyCode)
		{
			List<Currency> records = await this.SearchLinqEF(x => x.CurrencyCode == currencyCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0b5925f428576f2625ec4dcf26e9b01b</Hash>
</Codenesium>*/