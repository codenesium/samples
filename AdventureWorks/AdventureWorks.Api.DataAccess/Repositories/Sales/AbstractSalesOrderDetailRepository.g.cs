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
	public abstract class AbstractSalesOrderDetailRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALSalesOrderDetailMapper Mapper { get; }

		public AbstractSalesOrderDetailRepository(
			IDALSalesOrderDetailMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOSalesOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOSalesOrderDetail> Get(int salesOrderID)
		{
			SalesOrderDetail record = await this.GetById(salesOrderID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOSalesOrderDetail> Create(
			DTOSalesOrderDetail dto)
		{
			SalesOrderDetail record = new SalesOrderDetail();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<SalesOrderDetail>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int salesOrderID,
			DTOSalesOrderDetail dto)
		{
			SalesOrderDetail record = await this.GetById(salesOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					salesOrderID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int salesOrderID)
		{
			SalesOrderDetail record = await this.GetById(salesOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderDetail>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOSalesOrderDetail>> GetProductID(int productID)
		{
			var records = await this.SearchLinqDTO(x => x.ProductID == productID);

			return records;
		}

		protected async Task<List<DTOSalesOrderDetail>> Where(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesOrderDetail> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOSalesOrderDetail>> SearchLinqDTO(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesOrderDetail> response = new List<DTOSalesOrderDetail>();
			List<SalesOrderDetail> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<SalesOrderDetail>> SearchLinqEF(Expression<Func<SalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderDetail.SalesOrderID)} ASC";
			}
			return await this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderDetail>();
		}

		private async Task<List<SalesOrderDetail>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderDetail.SalesOrderID)} ASC";
			}

			return await this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderDetail>();
		}

		private async Task<SalesOrderDetail> GetById(int salesOrderID)
		{
			List<SalesOrderDetail> records = await this.SearchLinqEF(x => x.SalesOrderID == salesOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d130fb1911f8b2a62549dc5e6156cc17</Hash>
</Codenesium>*/