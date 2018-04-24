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
	public abstract class AbstractPurchaseOrderDetailRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPurchaseOrderDetailRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			PurchaseOrderDetailModel model)
		{
			EFPurchaseOrderDetail record = new EFPurchaseOrderDetail();

			this.Mapper.PurchaseOrderDetailMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFPurchaseOrderDetail>().Add(record);
			this.Context.SaveChanges();
			return record.PurchaseOrderID;
		}

		public virtual void Update(
			int purchaseOrderID,
			PurchaseOrderDetailModel model)
		{
			EFPurchaseOrderDetail record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{purchaseOrderID}");
			}
			else
			{
				this.Mapper.PurchaseOrderDetailMapModelToEF(
					purchaseOrderID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int purchaseOrderID)
		{
			EFPurchaseOrderDetail record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFPurchaseOrderDetail>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int purchaseOrderID)
		{
			return this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID);
		}

		public virtual POCOPurchaseOrderDetail GetByIdDirect(int purchaseOrderID)
		{
			return this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID).PurchaseOrderDetails.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPurchaseOrderDetail> GetWhereDirect(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).PurchaseOrderDetails;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFPurchaseOrderDetail> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.PurchaseOrderDetailMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFPurchaseOrderDetail> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.PurchaseOrderDetailMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFPurchaseOrderDetail> SearchLinqEF(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPurchaseOrderDetail> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>6c732b714d1ce3c6fa2631ee716bfb5d</Hash>
</Codenesium>*/