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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPurchaseOrderHeaderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			PurchaseOrderHeaderModel model)
		{
			EFPurchaseOrderHeader record = new EFPurchaseOrderHeader();

			this.Mapper.PurchaseOrderHeaderMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFPurchaseOrderHeader>().Add(record);
			this.Context.SaveChanges();
			return record.PurchaseOrderID;
		}

		public virtual void Update(
			int purchaseOrderID,
			PurchaseOrderHeaderModel model)
		{
			EFPurchaseOrderHeader record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{purchaseOrderID}");
			}
			else
			{
				this.Mapper.PurchaseOrderHeaderMapModelToEF(
					purchaseOrderID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int purchaseOrderID)
		{
			EFPurchaseOrderHeader record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFPurchaseOrderHeader>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int purchaseOrderID)
		{
			return this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID);
		}

		public virtual POCOPurchaseOrderHeader GetByIdDirect(int purchaseOrderID)
		{
			return this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID).PurchaseOrderHeaders.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPurchaseOrderHeader> GetWhereDirect(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).PurchaseOrderHeaders;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFPurchaseOrderHeader> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.PurchaseOrderHeaderMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFPurchaseOrderHeader> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.PurchaseOrderHeaderMapEFToPOCO(x, response));
			return response;
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
    <Hash>707a20bae380c9b1d4dbcce4a49bb5ec</Hash>
</Codenesium>*/