using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractPurchaseOrderHeaderRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPurchaseOrderHeaderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPurchaseOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPurchaseOrderHeader> Get(int purchaseOrderID)
		{
			PurchaseOrderHeader record = await this.GetById(purchaseOrderID);

			return this.Mapper.PurchaseOrderHeaderMapEFToPOCO(record);
		}

		public async virtual Task<POCOPurchaseOrderHeader> Create(
			ApiPurchaseOrderHeaderModel model)
		{
			PurchaseOrderHeader record = new PurchaseOrderHeader();

			this.Mapper.PurchaseOrderHeaderMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PurchaseOrderHeader>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PurchaseOrderHeaderMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderModel model)
		{
			PurchaseOrderHeader record = await this.GetById(purchaseOrderID);

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
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int purchaseOrderID)
		{
			PurchaseOrderHeader record = await this.GetById(purchaseOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PurchaseOrderHeader>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOPurchaseOrderHeader>> GetEmployeeID(int employeeID)
		{
			var records = await this.SearchLinqPOCO(x => x.EmployeeID == employeeID);

			return records;
		}
		public async Task<List<POCOPurchaseOrderHeader>> GetVendorID(int vendorID)
		{
			var records = await this.SearchLinqPOCO(x => x.VendorID == vendorID);

			return records;
		}

		protected async Task<List<POCOPurchaseOrderHeader>> Where(Expression<Func<PurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPurchaseOrderHeader> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPurchaseOrderHeader>> SearchLinqPOCO(Expression<Func<PurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPurchaseOrderHeader> response = new List<POCOPurchaseOrderHeader>();
			List<PurchaseOrderHeader> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PurchaseOrderHeaderMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PurchaseOrderHeader>> SearchLinqEF(Expression<Func<PurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderHeader.PurchaseOrderID)} ASC";
			}
			return await this.Context.Set<PurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PurchaseOrderHeader>();
		}

		private async Task<List<PurchaseOrderHeader>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderHeader.PurchaseOrderID)} ASC";
			}

			return await this.Context.Set<PurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PurchaseOrderHeader>();
		}

		private async Task<PurchaseOrderHeader> GetById(int purchaseOrderID)
		{
			List<PurchaseOrderHeader> records = await this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1815c24a5627480ff3a6493dbe9a9f4a</Hash>
</Codenesium>*/