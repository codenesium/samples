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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractVendorRepository(ILogger logger,
		                                ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFVendor>().Add(record);
			this.context.SaveChanges();
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
				this.logger.LogError("Unable to find id:{0}",businessEntityID);
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
				this.context.SaveChanges();
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
				this.context.Set<EFVendor>().Remove(record);
				this.context.SaveChanges();
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

		public virtual List<POCOVendor > GetWhereDirect(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Vendors;
		}
		public virtual POCOVendor GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.Vendors.FirstOrDefault();
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

			BusinessEntityRepository.MapEFToPOCO(efVendor.BusinessEntity, response);
		}
	}
}

/*<Codenesium>
    <Hash>f0e7653165d7ed3591a8b15c8d4820ca</Hash>
</Codenesium>*/