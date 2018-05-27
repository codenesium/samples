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
	public abstract class AbstractSalesOrderHeaderSalesReasonRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALSalesOrderHeaderSalesReasonMapper Mapper { get; }

		public AbstractSalesOrderHeaderSalesReasonRepository(
			IDALSalesOrderHeaderSalesReasonMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOSalesOrderHeaderSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOSalesOrderHeaderSalesReason> Get(int salesOrderID)
		{
			SalesOrderHeaderSalesReason record = await this.GetById(salesOrderID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOSalesOrderHeaderSalesReason> Create(
			DTOSalesOrderHeaderSalesReason dto)
		{
			SalesOrderHeaderSalesReason record = new SalesOrderHeaderSalesReason();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<SalesOrderHeaderSalesReason>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int salesOrderID,
			DTOSalesOrderHeaderSalesReason dto)
		{
			SalesOrderHeaderSalesReason record = await this.GetById(salesOrderID);

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
			SalesOrderHeaderSalesReason record = await this.GetById(salesOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderHeaderSalesReason>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOSalesOrderHeaderSalesReason>> Where(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesOrderHeaderSalesReason> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOSalesOrderHeaderSalesReason>> SearchLinqDTO(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesOrderHeaderSalesReason> response = new List<DTOSalesOrderHeaderSalesReason>();
			List<SalesOrderHeaderSalesReason> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<SalesOrderHeaderSalesReason>> SearchLinqEF(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeaderSalesReason.SalesOrderID)} ASC";
			}
			return await this.Context.Set<SalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeaderSalesReason>();
		}

		private async Task<List<SalesOrderHeaderSalesReason>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeaderSalesReason.SalesOrderID)} ASC";
			}

			return await this.Context.Set<SalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeaderSalesReason>();
		}

		private async Task<SalesOrderHeaderSalesReason> GetById(int salesOrderID)
		{
			List<SalesOrderHeaderSalesReason> records = await this.SearchLinqEF(x => x.SalesOrderID == salesOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0a752c3b00aa78462505cf5cf6cbd2bc</Hash>
</Codenesium>*/