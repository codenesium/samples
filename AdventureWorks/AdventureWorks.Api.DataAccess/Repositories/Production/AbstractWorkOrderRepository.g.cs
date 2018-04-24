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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractWorkOrderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			WorkOrderModel model)
		{
			EFWorkOrder record = new EFWorkOrder();

			this.Mapper.WorkOrderMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFWorkOrder>().Add(record);
			this.Context.SaveChanges();
			return record.WorkOrderID;
		}

		public virtual void Update(
			int workOrderID,
			WorkOrderModel model)
		{
			EFWorkOrder record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{workOrderID}");
			}
			else
			{
				this.Mapper.WorkOrderMapModelToEF(
					workOrderID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int workOrderID)
		{
			EFWorkOrder record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFWorkOrder>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int workOrderID)
		{
			return this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID);
		}

		public virtual POCOWorkOrder GetByIdDirect(int workOrderID)
		{
			return this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID).WorkOrders.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOWorkOrder> GetWhereDirect(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).WorkOrders;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFWorkOrder> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.WorkOrderMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFWorkOrder> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.WorkOrderMapEFToPOCO(x, response));
			return response;
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
    <Hash>c710ffe82e0a12be7733d54b4492adc7</Hash>
</Codenesium>*/