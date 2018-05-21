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
	public abstract class AbstractSalesReasonRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSalesReason> Get(int salesReasonID)
		{
			SalesReason record = await this.GetById(salesReasonID);

			return this.Mapper.SalesReasonMapEFToPOCO(record);
		}

		public async virtual Task<POCOSalesReason> Create(
			ApiSalesReasonModel model)
		{
			SalesReason record = new SalesReason();

			this.Mapper.SalesReasonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesReason>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SalesReasonMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int salesReasonID,
			ApiSalesReasonModel model)
		{
			SalesReason record = await this.GetById(salesReasonID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesReasonID}");
			}
			else
			{
				this.Mapper.SalesReasonMapModelToEF(
					salesReasonID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int salesReasonID)
		{
			SalesReason record = await this.GetById(salesReasonID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesReason>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOSalesReason>> Where(Expression<Func<SalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesReason> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSalesReason>> SearchLinqPOCO(Expression<Func<SalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesReason> response = new List<POCOSalesReason>();
			List<SalesReason> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SalesReasonMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SalesReason>> SearchLinqEF(Expression<Func<SalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesReason.SalesReasonID)} ASC";
			}
			return await this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesReason>();
		}

		private async Task<List<SalesReason>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesReason.SalesReasonID)} ASC";
			}

			return await this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesReason>();
		}

		private async Task<SalesReason> GetById(int salesReasonID)
		{
			List<SalesReason> records = await this.SearchLinqEF(x => x.SalesReasonID == salesReasonID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fa81ce4daf571799645864bcddc6bf79</Hash>
</Codenesium>*/