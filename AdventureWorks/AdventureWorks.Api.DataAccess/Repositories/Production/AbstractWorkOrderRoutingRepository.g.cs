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
		protected IDALWorkOrderRoutingMapper Mapper { get; }

		public AbstractWorkOrderRoutingRepository(
			IDALWorkOrderRoutingMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOWorkOrderRouting>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOWorkOrderRouting> Get(int workOrderID)
		{
			WorkOrderRouting record = await this.GetById(workOrderID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOWorkOrderRouting> Create(
			DTOWorkOrderRouting dto)
		{
			WorkOrderRouting record = new WorkOrderRouting();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<WorkOrderRouting>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int workOrderID,
			DTOWorkOrderRouting dto)
		{
			WorkOrderRouting record = await this.GetById(workOrderID);

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

		public async Task<List<DTOWorkOrderRouting>> GetProductID(int productID)
		{
			var records = await this.SearchLinqDTO(x => x.ProductID == productID);

			return records;
		}

		protected async Task<List<DTOWorkOrderRouting>> Where(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOWorkOrderRouting> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOWorkOrderRouting>> SearchLinqDTO(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOWorkOrderRouting> response = new List<DTOWorkOrderRouting>();
			List<WorkOrderRouting> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>d5438c2995eaee5e5b882d6279495b89</Hash>
</Codenesium>*/