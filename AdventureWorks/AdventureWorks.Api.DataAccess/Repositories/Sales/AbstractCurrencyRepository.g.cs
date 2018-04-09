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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractCurrencyRepository(ILogger logger,
		                                  ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(string name,
		                             DateTime modifiedDate)
		{
			var record = new EFCurrency ();

			MapPOCOToEF(String.Empty, name,
			            modifiedDate, record);

			this.context.Set<EFCurrency>().Add(record);
			this.context.SaveChanges();
			return record.CurrencyCode;
		}

		public virtual void Update(string currencyCode, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.CurrencyCode == currencyCode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{currencyCode}");
			}
			else
			{
				MapPOCOToEF(currencyCode,  name,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(string currencyCode)
		{
			var record = this.SearchLinqEF(x => x.CurrencyCode == currencyCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFCurrency>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(string currencyCode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CurrencyCode == currencyCode,response);
			return response;
		}

		public virtual POCOCurrency GetByIdDirect(string currencyCode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CurrencyCode == currencyCode,response);
			return response.Currencies.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOCurrency> GetWhereDirect(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Currencies;
		}

		private void SearchLinqPOCO(Expression<Func<EFCurrency, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCurrency> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCurrency> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFCurrency> SearchLinqEF(Expression<Func<EFCurrency, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCurrency> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(string currencyCode, string name,
		                               DateTime modifiedDate, EFCurrency   efCurrency)
		{
			efCurrency.SetProperties(currencyCode,name,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFCurrency efCurrency,Response response)
		{
			if(efCurrency == null)
			{
				return;
			}
			response.AddCurrency(new POCOCurrency(efCurrency.CurrencyCode,efCurrency.Name,efCurrency.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>9d164376e25629c31af9341e4a4cd13a</Hash>
</Codenesium>*/