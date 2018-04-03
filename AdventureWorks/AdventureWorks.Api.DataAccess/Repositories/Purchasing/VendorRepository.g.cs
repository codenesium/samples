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
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, string accountNumber,
		                           string name,
		                           int creditRating,
		                           bool preferredVendorStatus,
		                           bool activeFlag,
		                           string purchasingWebServiceURL,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();
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
			var record = this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();

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
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
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
			efVendor.businessEntityID = businessEntityID;
			efVendor.accountNumber = accountNumber;
			efVendor.name = name;
			efVendor.creditRating = creditRating;
			efVendor.preferredVendorStatus = preferredVendorStatus;
			efVendor.activeFlag = activeFlag;
			efVendor.purchasingWebServiceURL = purchasingWebServiceURL;
			efVendor.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFVendor efVendor,Response response)
		{
			if(efVendor == null)
			{
				return;
			}
			response.AddVendor(new POCOVendor()
			{
				BusinessEntityID = efVendor.businessEntityID.ToInt(),
				AccountNumber = efVendor.accountNumber,
				Name = efVendor.name,
				CreditRating = efVendor.creditRating,
				PreferredVendorStatus = efVendor.preferredVendorStatus,
				ActiveFlag = efVendor.activeFlag,
				PurchasingWebServiceURL = efVendor.purchasingWebServiceURL,
				ModifiedDate = efVendor.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>dbc7e432417e65b22e23e2aaeaa9fa3b</Hash>
</Codenesium>*/