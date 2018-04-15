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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractPurchaseOrderDetailRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			PurchaseOrderDetailModel model)
		{
			var record = new EFPurchaseOrderDetail();

			this.mapper.PurchaseOrderDetailMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFPurchaseOrderDetail>().Add(record);
			this.context.SaveChanges();
			return record.PurchaseOrderID;
		}

		public virtual void Update(
			int purchaseOrderID,
			PurchaseOrderDetailModel model)
		{
			var record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{purchaseOrderID}");
			}
			else
			{
				this.mapper.PurchaseOrderDetailMapModelToEF(
					purchaseOrderID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int purchaseOrderID)
		{
			var record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFPurchaseOrderDetail>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int purchaseOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID, response);
			return response;
		}

		public virtual POCOPurchaseOrderDetail GetByIdDirect(int purchaseOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID, response);
			return response.PurchaseOrderDetails.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOPurchaseOrderDetail> GetWhereDirect(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PurchaseOrderDetails;
		}

		private void SearchLinqPOCO(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPurchaseOrderDetail> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.PurchaseOrderDetailMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPurchaseOrderDetail> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.PurchaseOrderDetailMapEFToPOCO(x, response));
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
    <Hash>992ddc833c69f1afb0581dbd50047278</Hash>
</Codenesium>*/