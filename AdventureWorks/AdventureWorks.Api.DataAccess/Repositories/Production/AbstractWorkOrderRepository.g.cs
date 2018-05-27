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
	public abstract class AbstractWorkOrderRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALWorkOrderMapper Mapper { get; }

		public AbstractWorkOrderRepository(
			IDALWorkOrderMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOWorkOrder>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOWorkOrder> Get(int workOrderID)
		{
			WorkOrder record = await this.GetById(workOrderID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOWorkOrder> Create(
			DTOWorkOrder dto)
		{
			WorkOrder record = new WorkOrder();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<WorkOrder>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int workOrderID,
			DTOWorkOrder dto)
		{
			WorkOrder record = await this.GetById(workOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{workOrderID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					workOrderID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int workOrderID)
		{
			WorkOrder record = await this.GetById(workOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<WorkOrder>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOWorkOrder>> GetProductID(int productID)
		{
			var records = await this.SearchLinqDTO(x => x.ProductID == productID);

			return records;
		}
		public async Task<List<DTOWorkOrder>> GetScrapReasonID(Nullable<short> scrapReasonID)
		{
			var records = await this.SearchLinqDTO(x => x.ScrapReasonID == scrapReasonID);

			return records;
		}

		protected async Task<List<DTOWorkOrder>> Where(Expression<Func<WorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOWorkOrder> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOWorkOrder>> SearchLinqDTO(Expression<Func<WorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOWorkOrder> response = new List<DTOWorkOrder>();
			List<WorkOrder> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<WorkOrder>> SearchLinqEF(Expression<Func<WorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrder.WorkOrderID)} ASC";
			}
			return await this.Context.Set<WorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<WorkOrder>();
		}

		private async Task<List<WorkOrder>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrder.WorkOrderID)} ASC";
			}

			return await this.Context.Set<WorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<WorkOrder>();
		}

		private async Task<WorkOrder> GetById(int workOrderID)
		{
			List<WorkOrder> records = await this.SearchLinqEF(x => x.WorkOrderID == workOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7363c5545fd05cfc7f09140212f8059e</Hash>
</Codenesium>*/