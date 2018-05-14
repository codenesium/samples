using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractWorkOrderRoutingRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractWorkOrderRoutingRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOWorkOrderRouting> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOWorkOrderRouting Get(int workOrderID)
		{
			return this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID).FirstOrDefault();
		}

		public virtual POCOWorkOrderRouting Create(
			ApiWorkOrderRoutingModel model)
		{
			WorkOrderRouting record = new WorkOrderRouting();

			this.Mapper.WorkOrderRoutingMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<WorkOrderRouting>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.WorkOrderRoutingMapEFToPOCO(record);
		}

		public virtual void Update(
			int workOrderID,
			ApiWorkOrderRoutingModel model)
		{
			WorkOrderRouting record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int workOrderID)
		{
			WorkOrderRouting record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<WorkOrderRouting>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOWorkOrderRouting> GetProductID(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}

		protected List<POCOWorkOrderRouting> Where(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOWorkOrderRouting> SearchLinqPOCO(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOWorkOrderRouting> response = new List<POCOWorkOrderRouting>();
			List<WorkOrderRouting> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.WorkOrderRoutingMapEFToPOCO(x)));
			return response;
		}

		private List<WorkOrderRouting> SearchLinqEF(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrderRouting.WorkOrderID)} ASC";
			}
			return this.Context.Set<WorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<WorkOrderRouting>();
		}

		private List<WorkOrderRouting> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrderRouting.WorkOrderID)} ASC";
			}

			return this.Context.Set<WorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<WorkOrderRouting>();
		}
	}
}

/*<Codenesium>
    <Hash>e3185615642118eb6d2280ae80fbd6ac</Hash>
</Codenesium>*/