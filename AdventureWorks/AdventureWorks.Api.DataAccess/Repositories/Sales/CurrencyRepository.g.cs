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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractCurrencyRepository(ILogger logger,
		                                  ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual string Create(string name,
		                             DateTime modifiedDate)
		{
			var record = new EFCurrency ();

			MapPOCOToEF(String.Empty, name,
			            modifiedDate, record);

			this._context.Set<EFCurrency>().Add(record);
			this._context.SaveChanges();
			return record.currencyCode;
		}

		public virtual void Update(string currencyCode, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.currencyCode == currencyCode).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",currencyCode);
			}
			else
			{
				MapPOCOToEF(currencyCode,  name,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(string currencyCode)
		{
			var record = this.SearchLinqEF(x => x.currencyCode == currencyCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFCurrency>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(string currencyCode, Response response)
		{
			this.SearchLinqPOCO(x => x.currencyCode == currencyCode,response);
		}

		protected virtual List<EFCurrency> SearchLinqEF(Expression<Func<EFCurrency, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCurrency> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFCurrency, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
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

		public static void MapPOCOToEF(string currencyCode, string name,
		                               DateTime modifiedDate, EFCurrency   efCurrency)
		{
			efCurrency.currencyCode = currencyCode;
			efCurrency.name = name;
			efCurrency.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFCurrency efCurrency,Response response)
		{
			if(efCurrency == null)
			{
				return;
			}
			response.AddCurrency(new POCOCurrency()
			{
				CurrencyCode = efCurrency.currencyCode,
				Name = efCurrency.name,
				ModifiedDate = efCurrency.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>6ca9cdda1eafe115dad0b17d05189775</Hash>
</Codenesium>*/