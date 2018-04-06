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
			return record.SalesTaxRateID;
		}

		public virtual void Update(int salesTaxRateID, int stateProvinceID,
		                           int taxType,
		                           decimal taxRate,
		                           string name,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.SalesTaxRateID == salesTaxRateID).FirstOrDefault();
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
			var record = this.SearchLinqEF(x => x.SalesTaxRateID == salesTaxRateID).FirstOrDefault();

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
			this.SearchLinqPOCO(x => x.SalesTaxRateID == salesTaxRateID,response);
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
			efSalesTaxRate.SalesTaxRateID = salesTaxRateID;
			efSalesTaxRate.StateProvinceID = stateProvinceID;
			efSalesTaxRate.TaxType = taxType;
			efSalesTaxRate.TaxRate = taxRate;
			efSalesTaxRate.Name = name;
			efSalesTaxRate.Rowguid = rowguid;
			efSalesTaxRate.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesTaxRate efSalesTaxRate,Response response)
		{
			if(efSalesTaxRate == null)
			{
				return;
			}
			response.AddSalesTaxRate(new POCOSalesTaxRate()
			{
				SalesTaxRateID = efSalesTaxRate.SalesTaxRateID.ToInt(),
				TaxType = efSalesTaxRate.TaxType,
				TaxRate = efSalesTaxRate.TaxRate,
				Name = efSalesTaxRate.Name,
				Rowguid = efSalesTaxRate.Rowguid,
				ModifiedDate = efSalesTaxRate.ModifiedDate.ToDateTime(),

				StateProvinceID = new ReferenceEntity<int>(efSalesTaxRate.StateProvinceID,
				                                           "StateProvinces"),
			});

			StateProvinceRepository.MapEFToPOCO(efSalesTaxRate.StateProvinceRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>d1c9841f1a5ba0c569aba96040795241</Hash>
</Codenesium>*/