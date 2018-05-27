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
	public abstract class AbstractPurchaseOrderDetailRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALPurchaseOrderDetailMapper Mapper { get; }

		public AbstractPurchaseOrderDetailRepository(
			IDALPurchaseOrderDetailMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOPurchaseOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOPurchaseOrderDetail> Get(int purchaseOrderID)
		{
			PurchaseOrderDetail record = await this.GetById(purchaseOrderID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOPurchaseOrderDetail> Create(
			DTOPurchaseOrderDetail dto)
		{
			PurchaseOrderDetail record = new PurchaseOrderDetail();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<PurchaseOrderDetail>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int purchaseOrderID,
			DTOPurchaseOrderDetail dto)
		{
			PurchaseOrderDetail record = await this.GetById(purchaseOrderID);

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
			PurchaseOrderDetail record = await this.GetById(purchaseOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PurchaseOrderDetail>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOPurchaseOrderDetail>> GetProductID(int productID)
		{
			var records = await this.SearchLinqDTO(x => x.ProductID == productID);

			return records;
		}

		protected async Task<List<DTOPurchaseOrderDetail>> Where(Expression<Func<PurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPurchaseOrderDetail> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOPurchaseOrderDetail>> SearchLinqDTO(Expression<Func<PurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPurchaseOrderDetail> response = new List<DTOPurchaseOrderDetail>();
			List<PurchaseOrderDetail> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<PurchaseOrderDetail>> SearchLinqEF(Expression<Func<PurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderDetail.PurchaseOrderID)} ASC";
			}
			return await this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PurchaseOrderDetail>();
		}

		private async Task<List<PurchaseOrderDetail>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PurchaseOrderDetail.PurchaseOrderID)} ASC";
			}

			return await this.Context.Set<PurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PurchaseOrderDetail>();
		}

		private async Task<PurchaseOrderDetail> GetById(int purchaseOrderID)
		{
			List<PurchaseOrderDetail> records = await this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b7245d82244b5fba72f4744557d36138</Hash>
</Codenesium>*/