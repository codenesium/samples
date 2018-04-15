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
	public abstract class AbstractWorkOrderRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractWorkOrderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			WorkOrderModel model)
		{
			var record = new EFWorkOrder();

			this.mapper.WorkOrderMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFWorkOrder>().Add(record);
			this.context.SaveChanges();
			return record.WorkOrderID;
		}

		public virtual void Update(
			int workOrderID,
			WorkOrderModel model)
		{
			var record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{workOrderID}");
			}
			else
			{
				this.mapper.WorkOrderMapModelToEF(
					workOrderID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int workOrderID)
		{
			var record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFWorkOrder>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int workOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID, response);
			return response;
		}

		public virtual POCOWorkOrder GetByIdDirect(int workOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID, response);
			return response.WorkOrders.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOWorkOrder> GetWhereDirect(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.WorkOrders;
		}

		private void SearchLinqPOCO(Expression<Func<EFWorkOrder, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFWorkOrder> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.WorkOrderMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFWorkOrder> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.WorkOrderMapEFToPOCO(x, response));
		}

		protected virtual List<EFWorkOrder> SearchLinqEF(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFWorkOrder> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>91c11bf0d83277816aaf26df2e32dfed</Hash>
</Codenesium>*/