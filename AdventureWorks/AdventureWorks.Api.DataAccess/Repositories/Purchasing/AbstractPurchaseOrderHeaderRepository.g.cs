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

		public virtual List<POCOPurchaseOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPurchaseOrderHeader Get(int purchaseOrderID)
		{
			return this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
		}

		public virtual POCOPurchaseOrderHeader Create(
			ApiPurchaseOrderHeaderModel model)
		{
			PurchaseOrderHeader record = new PurchaseOrderHeader();

			this.Mapper.PurchaseOrderHeaderMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PurchaseOrderHeader>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PurchaseOrderHeaderMapEFToPOCO(record);
		}

		public virtual void Update(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderModel model)
		{
			PurchaseOrderHeader record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
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
			PurchaseOrderHeader record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PurchaseOrderHeader>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOPurchaseOrderHeader> GetEmployeeID(int employeeID)
		{
			return this.SearchLinqPOCO(x => x.EmployeeID == employeeID);
		}
		public List<POCOPurchaseOrderHeader> GetVendorID(int vendorID)
		{
			return this.SearchLinqPOCO(x => x.VendorID == vendorID);
		}

		protected List<POCOPurchaseOrderHeader> Where(Expression<Func<PurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPurchaseOrderHeader> SearchLinqPOCO(Expression<Func<PurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPurchaseOrderHeader> response = new List<POCOPurchaseOrderHeader>();
			List<PurchaseOrderHeader> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PurchaseOrderHeaderMapEFToPOCO(x)));
			return response;
		}

		private List<PurchaseOrderHeader> SearchLinqEF(Expression<Func<PurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderHeader.PurchaseOrderID)} ASC";
			}
			return this.Context.Set<PurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PurchaseOrderHeader>();
		}

		private List<PurchaseOrderHeader> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderHeader.PurchaseOrderID)} ASC";
			}

			return this.Context.Set<PurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PurchaseOrderHeader>();
		}
	}
}

/*<Codenesium>
    <Hash>2fc979dc64559a3aade320e271bd63b1</Hash>
</Codenesium>*/