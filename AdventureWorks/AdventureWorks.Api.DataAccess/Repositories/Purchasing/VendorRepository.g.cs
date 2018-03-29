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
	public abstract class AbstractVendorRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractVendorRepository(ILogger logger,
		                                ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string accountNumber,
		                          string name,
		                          int creditRating,
		                          bool preferredVendorStatus,
		                          bool activeFlag,
		                          string purchasingWebServiceURL,
		                          DateTime modifiedDate)
		{
			var record = new EFVendor ();

			MapPOCOToEF(0, accountNumber,
			            name,
			            creditRating,
			            preferredVendorStatus,
			            activeFlag,
			            purchasingWebServiceURL,
			            modifiedDate, record);

			this._context.Set<EFVendor>().Add(record);
			this._context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, string accountNumber,
		                           string name,
		                           int creditRating,
		                           bool preferredVendorStatus,
		                           bool activeFlag,
		                           string purchasingWebServiceURL,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  accountNumber,
				            name,
				            creditRating,
				            preferredVendorStatus,
				            activeFlag,
				            purchasingWebServiceURL,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFVendor>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
		}

		protected virtual List<EFVendor> SearchLinqEF(Expression<Func<EFVendor, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFVendor> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFVendor, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFVendor, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFVendor> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFVendor> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, string accountNumber,
		                               string name,
		                               int creditRating,
		                               bool preferredVendorStatus,
		                               bool activeFlag,
		                               string purchasingWebServiceURL,
		                               DateTime modifiedDate, EFVendor   efVendor)
		{
			efVendor.BusinessEntityID = businessEntityID;
			efVendor.AccountNumber = accountNumber;
			efVendor.Name = name;
			efVendor.CreditRating = creditRating;
			efVendor.PreferredVendorStatus = preferredVendorStatus;
			efVendor.ActiveFlag = activeFlag;
			efVendor.PurchasingWebServiceURL = purchasingWebServiceURL;
			efVendor.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFVendor efVendor,Response response)
		{
			if(efVendor == null)
			{
				return;
			}
			response.AddVendor(new POCOVendor()
			{
				AccountNumber = efVendor.AccountNumber,
				Name = efVendor.Name,
				CreditRating = efVendor.CreditRating,
				PreferredVendorStatus = efVendor.PreferredVendorStatus,
				ActiveFlag = efVendor.ActiveFlag,
				PurchasingWebServiceURL = efVendor.PurchasingWebServiceURL,
				ModifiedDate = efVendor.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efVendor.BusinessEntityID,
				                                            "BusinessEntities"),
			});

			BusinessEntityRepository.MapEFToPOCO(efVendor.BusinessEntityRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>93ca6d906c1a08fd9b494a7643133e55</Hash>
</Codenesium>*/