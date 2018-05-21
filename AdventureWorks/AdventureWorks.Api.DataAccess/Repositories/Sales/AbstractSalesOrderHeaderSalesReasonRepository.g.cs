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
		protected IObjectMapper Mapper { get; }

		public AbstractSalesOrderHeaderSalesReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSalesOrderHeaderSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSalesOrderHeaderSalesReason> Get(int salesOrderID)
		{
			SalesOrderHeaderSalesReason record = await this.GetById(salesOrderID);

			return this.Mapper.SalesOrderHeaderSalesReasonMapEFToPOCO(record);
		}

		public async virtual Task<POCOSalesOrderHeaderSalesReason> Create(
			ApiSalesOrderHeaderSalesReasonModel model)
		{
			SalesOrderHeaderSalesReason record = new SalesOrderHeaderSalesReason();

			this.Mapper.SalesOrderHeaderSalesReasonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesOrderHeaderSalesReason>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SalesOrderHeaderSalesReasonMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonModel model)
		{
			SalesOrderHeaderSalesReason record = await this.GetById(salesOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.Mapper.SalesOrderHeaderSalesReasonMapModelToEF(
					salesOrderID,
					model,
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

		protected async Task<List<POCOSalesOrderHeaderSalesReason>> Where(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesOrderHeaderSalesReason> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSalesOrderHeaderSalesReason>> SearchLinqPOCO(Expression<Func<SalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesOrderHeaderSalesReason> response = new List<POCOSalesOrderHeaderSalesReason>();
			List<SalesOrderHeaderSalesReason> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SalesOrderHeaderSalesReasonMapEFToPOCO(x)));
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
    <Hash>bd959b3492afecb7889f581c782206a4</Hash>
</Codenesium>*/