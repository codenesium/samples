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
	public abstract class AbstractWorkOrderRoutingRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractWorkOrderRoutingRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOWorkOrderRouting>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOWorkOrderRouting> Get(int workOrderID)
		{
			WorkOrderRouting record = await this.GetById(workOrderID);

			return this.Mapper.WorkOrderRoutingMapEFToPOCO(record);
		}

		public async virtual Task<POCOWorkOrderRouting> Create(
			ApiWorkOrderRoutingModel model)
		{
			WorkOrderRouting record = new WorkOrderRouting();

			this.Mapper.WorkOrderRoutingMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<WorkOrderRouting>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.WorkOrderRoutingMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int workOrderID,
			ApiWorkOrderRoutingModel model)
		{
			WorkOrderRouting record = await this.GetById(workOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{workOrderID}");
			}
			else
			{
				this.Mapper.WorkOrderRoutingMapModelToEF(
					workOrderID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int workOrderID)
		{
			WorkOrderRouting record = await this.GetById(workOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<WorkOrderRouting>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOWorkOrderRouting>> GetProductID(int productID)
		{
			var records = await this.SearchLinqPOCO(x => x.ProductID == productID);

			return records;
		}

		protected async Task<List<POCOWorkOrderRouting>> Where(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOWorkOrderRouting> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOWorkOrderRouting>> SearchLinqPOCO(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOWorkOrderRouting> response = new List<POCOWorkOrderRouting>();
			List<WorkOrderRouting> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.WorkOrderRoutingMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<WorkOrderRouting>> SearchLinqEF(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrderRouting.WorkOrderID)} ASC";
			}
			return await this.Context.Set<WorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<WorkOrderRouting>();
		}

		private async Task<List<WorkOrderRouting>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrderRouting.WorkOrderID)} ASC";
			}

			return await this.Context.Set<WorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<WorkOrderRouting>();
		}

		private async Task<WorkOrderRouting> GetById(int workOrderID)
		{
			List<WorkOrderRouting> records = await this.SearchLinqEF(x => x.WorkOrderID == workOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>95dd1898ad870bee475d182b66501678</Hash>
</Codenesium>*/