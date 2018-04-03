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
	public abstract class AbstractSalesTaxRateRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesTaxRateRepository(ILogger logger,
		                                      ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int stateProvinceID,
		                          int taxType,
		                          decimal taxRate,
		                          string name,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesTaxRate ();

			MapPOCOToEF(0, stateProvinceID,
			            taxType,
			            taxRate,
			            name,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSalesTaxRate>().Add(record);
			this._context.SaveChanges();
			return record.salesTaxRateID;
		}

		public virtual void Update(int salesTaxRateID, int stateProvinceID,
		                           int taxType,
		                           decimal taxRate,
		                           string name,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.salesTaxRateID == salesTaxRateID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",salesTaxRateID);
			}
			else
			{
				MapPOCOToEF(salesTaxRateID,  stateProvinceID,
				            taxType,
				            taxRate,
				            name,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int salesTaxRateID)
		{
			var record = this.SearchLinqEF(x => x.salesTaxRateID == salesTaxRateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFSalesTaxRate>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int salesTaxRateID, Response response)
		{
			this.SearchLinqPOCO(x => x.salesTaxRateID == salesTaxRateID,response);
		}

		protected virtual List<EFSalesTaxRate> SearchLinqEF(Expression<Func<EFSalesTaxRate, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesTaxRate> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesTaxRate, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesTaxRate, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesTaxRate> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesTaxRate> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int salesTaxRateID, int stateProvinceID,
		                               int taxType,
		                               decimal taxRate,
		                               string name,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesTaxRate   efSalesTaxRate)
		{
			efSalesTaxRate.salesTaxRateID = salesTaxRateID;
			efSalesTaxRate.stateProvinceID = stateProvinceID;
			efSalesTaxRate.taxType = taxType;
			efSalesTaxRate.taxRate = taxRate;
			efSalesTaxRate.name = name;
			efSalesTaxRate.rowguid = rowguid;
			efSalesTaxRate.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesTaxRate efSalesTaxRate,Response response)
		{
			if(efSalesTaxRate == null)
			{
				return;
			}
			response.AddSalesTaxRate(new POCOSalesTaxRate()
			{
				SalesTaxRateID = efSalesTaxRate.salesTaxRateID.ToInt(),
				StateProvinceID = efSalesTaxRate.stateProvinceID.ToInt(),
				TaxType = efSalesTaxRate.taxType,
				TaxRate = efSalesTaxRate.taxRate,
				Name = efSalesTaxRate.name,
				Rowguid = efSalesTaxRate.rowguid,
				ModifiedDate = efSalesTaxRate.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>7b7ed52f46a14432063f2948f8f6cd6b</Hash>
</Codenesium>*/