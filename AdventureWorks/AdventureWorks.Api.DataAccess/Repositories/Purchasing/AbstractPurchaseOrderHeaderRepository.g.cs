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
	public abstract class AbstractPurchaseOrderHeaderRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractPurchaseOrderHeaderRepository(ILogger logger,
		                                             ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int revisionNumber,
		                          int status,
		                          int employeeID,
		                          int vendorID,
		                          int shipMethodID,
		                          DateTime orderDate,
		                          Nullable<DateTime> shipDate,
		                          decimal subTotal,
		                          decimal taxAmt,
		                          decimal freight,
		                          decimal totalDue,
		                          DateTime modifiedDate)
		{
			var record = new EFPurchaseOrderHeader ();

			MapPOCOToEF(0, revisionNumber,
			            status,
			            employeeID,
			            vendorID,
			            shipMethodID,
			            orderDate,
			            shipDate,
			            subTotal,
			            taxAmt,
			            freight,
			            totalDue,
			            modifiedDate, record);

			this.context.Set<EFPurchaseOrderHeader>().Add(record);
			this.context.SaveChanges();
			return record.PurchaseOrderID;
		}

		public virtual void Update(int purchaseOrderID, int revisionNumber,
		                           int status,
		                           int employeeID,
		                           int vendorID,
		                           int shipMethodID,
		                           DateTime orderDate,
		                           Nullable<DateTime> shipDate,
		                           decimal subTotal,
		                           decimal taxAmt,
		                           decimal freight,
		                           decimal totalDue,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{purchaseOrderID}");
			}
			else
			{
				MapPOCOToEF(purchaseOrderID,  revisionNumber,
				            status,
				            employeeID,
				            vendorID,
				            shipMethodID,
				            orderDate,
				            shipDate,
				            subTotal,
				            taxAmt,
				            freight,
				            totalDue,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int purchaseOrderID)
		{
			var record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFPurchaseOrderHeader>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int purchaseOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID,response);
			return response;
		}

		public virtual POCOPurchaseOrderHeader GetByIdDirect(int purchaseOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID,response);
			return response.PurchaseOrderHeaders.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOPurchaseOrderHeader> GetWhereDirect(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PurchaseOrderHeaders;
		}

		private void SearchLinqPOCO(Expression<Func<EFPurchaseOrderHeader, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPurchaseOrderHeader> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPurchaseOrderHeader> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFPurchaseOrderHeader> SearchLinqEF(Expression<Func<EFPurchaseOrderHeader, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPurchaseOrderHeader> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int purchaseOrderID, int revisionNumber,
		                               int status,
		                               int employeeID,
		                               int vendorID,
		                               int shipMethodID,
		                               DateTime orderDate,
		                               Nullable<DateTime> shipDate,
		                               decimal subTotal,
		                               decimal taxAmt,
		                               decimal freight,
		                               decimal totalDue,
		                               DateTime modifiedDate, EFPurchaseOrderHeader   efPurchaseOrderHeader)
		{
			efPurchaseOrderHeader.SetProperties(purchaseOrderID.ToInt(),revisionNumber,status,employeeID.ToInt(),vendorID.ToInt(),shipMethodID.ToInt(),orderDate.ToDateTime(),shipDate.ToNullableDateTime(),subTotal,taxAmt,freight,totalDue,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFPurchaseOrderHeader efPurchaseOrderHeader,Response response)
		{
			if(efPurchaseOrderHeader == null)
			{
				return;
			}
			response.AddPurchaseOrderHeader(new POCOPurchaseOrderHeader(efPurchaseOrderHeader.PurchaseOrderID.ToInt(),efPurchaseOrderHeader.RevisionNumber,efPurchaseOrderHeader.Status,efPurchaseOrderHeader.EmployeeID.ToInt(),efPurchaseOrderHeader.VendorID.ToInt(),efPurchaseOrderHeader.ShipMethodID.ToInt(),efPurchaseOrderHeader.OrderDate.ToDateTime(),efPurchaseOrderHeader.ShipDate.ToNullableDateTime(),efPurchaseOrderHeader.SubTotal,efPurchaseOrderHeader.TaxAmt,efPurchaseOrderHeader.Freight,efPurchaseOrderHeader.TotalDue,efPurchaseOrderHeader.ModifiedDate.ToDateTime()));

			EmployeeRepository.MapEFToPOCO(efPurchaseOrderHeader.Employee, response);

			VendorRepository.MapEFToPOCO(efPurchaseOrderHeader.Vendor, response);

			ShipMethodRepository.MapEFToPOCO(efPurchaseOrderHeader.ShipMethod, response);
		}
	}
}

/*<Codenesium>
    <Hash>3687063935aa3dc8cfaf2778f0ff9d45</Hash>
</Codenesium>*/