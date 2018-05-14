using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractCurrencyRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCurrencyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOCurrency Get(string currencyCode)
		{
			return this.SearchLinqPOCO(x => x.CurrencyCode == currencyCode).FirstOrDefault();
		}

		public virtual POCOCurrency Create(
			ApiCurrencyModel model)
		{
			Currency record = new Currency();

			this.Mapper.CurrencyMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<Currency>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.CurrencyMapEFToPOCO(record);
		}

		public virtual void Update(
			string currencyCode,
			ApiCurrencyModel model)
		{
			Currency record = this.SearchLinqEF(x => x.CurrencyCode == currencyCode).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{currencyCode}");
			}
			else
			{
				this.Mapper.CurrencyMapModelToEF(
					currencyCode,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			string currencyCode)
		{
			Currency record = this.SearchLinqEF(x => x.CurrencyCode == currencyCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Currency>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOCurrency GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOCurrency> Where(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCurrency> SearchLinqPOCO(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCurrency> response = new List<POCOCurrency>();
			List<Currency> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CurrencyMapEFToPOCO(x)));
			return response;
		}

		private List<Currency> SearchLinqEF(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Currency.CurrencyCode)} ASC";
			}
			return this.Context.Set<Currency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Currency>();
		}

		private List<Currency> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Currency.CurrencyCode)} ASC";
			}

			return this.Context.Set<Currency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Currency>();
		}
	}
}

/*<Codenesium>
    <Hash>911e64a3fc145234e8af4b3df67ca3e9</Hash>
</Codenesium>*/