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
		protected IDALPurchaseOrderHeaderMapper Mapper { get; }

		public AbstractPurchaseOrderHeaderRepository(
			IDALPurchaseOrderHeaderMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOPurchaseOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOPurchaseOrderHeader> Get(int purchaseOrderID)
		{
			PurchaseOrderHeader record = await this.GetById(purchaseOrderID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOPurchaseOrderHeader> Create(
			DTOPurchaseOrderHeader dto)
		{
			PurchaseOrderHeader record = new PurchaseOrderHeader();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<PurchaseOrderHeader>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int purchaseOrderID,
			DTOPurchaseOrderHeader dto)
		{
			PurchaseOrderHeader record = await this.GetById(purchaseOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{purchaseOrderID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					purchaseOrderID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<List<DTOPurchaseOrderHeader>> GetEmployeeID(int employeeID)
		{
			var records = await this.SearchLinqDTO(x => x.EmployeeID == employeeID);

			return records;
		}
		public async Task<List<DTOPurchaseOrderHeader>> GetVendorID(int vendorID)
		{
			var records = await this.SearchLinqDTO(x => x.VendorID == vendorID);

			return records;
		}

		protected async Task<List<DTOPurchaseOrderHeader>> Where(Expression<Func<PurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPurchaseOrderHeader> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOPurchaseOrderHeader>> SearchLinqDTO(Expression<Func<PurchaseOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPurchaseOrderHeader> response = new List<DTOPurchaseOrderHeader>();
			List<PurchaseOrderHeader> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>173c8af6ac9d8f9bbecbda86737d5616</Hash>
</Codenesium>*/