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
		protected IObjectMapper mapper;

		public AbstractPurchaseOrderHeaderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			PurchaseOrderHeaderModel model)
		{
			var record = new EFPurchaseOrderHeader();

			this.mapper.PurchaseOrderHeaderMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFPurchaseOrderHeader>().Add(record);
			this.context.SaveChanges();
			return record.PurchaseOrderID;
		}

		public virtual void Update(
			int purchaseOrderID,
			PurchaseOrderHeaderModel model)
		{
			var record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{purchaseOrderID}");
			}
			else
			{
				this.mapper.PurchaseOrderHeaderMapModelToEF(
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
				this.context.Set<EFPurchaseOrderHeader>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int purchaseOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID, response);
			return response;
		}

		public virtual POCOPurchaseOrderHeader GetByIdDirect(int purchaseOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID, response);
			return response.PurchaseOrderHeaders.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOPurchaseOrderHeader> GetWhereDirect(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PurchaseOrderHeaders;
		}

		private void SearchLinqPOCO(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPurchaseOrderHeader> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.PurchaseOrderHeaderMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPurchaseOrderHeader> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.PurchaseOrderHeaderMapEFToPOCO(x, response));
		}

		protected virtual List<EFPurchaseOrderHeader> SearchLinqEF(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPurchaseOrderHeader> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>1e751e316de8d849aa86a5fa6c02955a</Hash>
</Codenesium>*/