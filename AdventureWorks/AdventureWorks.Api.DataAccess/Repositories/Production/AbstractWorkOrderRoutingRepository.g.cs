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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractWorkOrderRoutingRepository(ILogger logger,
		                                          ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int productID,
		                          short operationSequence,
		                          short locationID,
		                          DateTime scheduledStartDate,
		                          DateTime scheduledEndDate,
		                          Nullable<DateTime> actualStartDate,
		                          Nullable<DateTime> actualEndDate,
		                          Nullable<decimal> actualResourceHrs,
		                          decimal plannedCost,
		                          Nullable<decimal> actualCost,
		                          DateTime modifiedDate)
		{
			var record = new EFWorkOrderRouting ();

			MapPOCOToEF(0, productID,
			            operationSequence,
			            locationID,
			            scheduledStartDate,
			            scheduledEndDate,
			            actualStartDate,
			            actualEndDate,
			            actualResourceHrs,
			            plannedCost,
			            actualCost,
			            modifiedDate, record);

			this.context.Set<EFWorkOrderRouting>().Add(record);
			this.context.SaveChanges();
			return record.WorkOrderID;
		}

		public virtual void Update(int workOrderID, int productID,
		                           short operationSequence,
		                           short locationID,
		                           DateTime scheduledStartDate,
		                           DateTime scheduledEndDate,
		                           Nullable<DateTime> actualStartDate,
		                           Nullable<DateTime> actualEndDate,
		                           Nullable<decimal> actualResourceHrs,
		                           decimal plannedCost,
		                           Nullable<decimal> actualCost,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",workOrderID);
			}
			else
			{
				MapPOCOToEF(workOrderID,  productID,
				            operationSequence,
				            locationID,
				            scheduledStartDate,
				            scheduledEndDate,
				            actualStartDate,
				            actualEndDate,
				            actualResourceHrs,
				            plannedCost,
				            actualCost,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int workOrderID)
		{
			var record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFWorkOrderRouting>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int workOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID,response);
		}

		protected virtual List<EFWorkOrderRouting> SearchLinqEF(Expression<Func<EFWorkOrderRouting, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFWorkOrderRouting> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFWorkOrderRouting, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOWorkOrderRouting > GetWhereDirect(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.WorkOrderRoutings;
		}
		public virtual POCOWorkOrderRouting GetByIdDirect(int workOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID,response);
			return response.WorkOrderRoutings.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFWorkOrderRouting, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFWorkOrderRouting> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFWorkOrderRouting> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int workOrderID, int productID,
		                               short operationSequence,
		                               short locationID,
		                               DateTime scheduledStartDate,
		                               DateTime scheduledEndDate,
		                               Nullable<DateTime> actualStartDate,
		                               Nullable<DateTime> actualEndDate,
		                               Nullable<decimal> actualResourceHrs,
		                               decimal plannedCost,
		                               Nullable<decimal> actualCost,
		                               DateTime modifiedDate, EFWorkOrderRouting   efWorkOrderRouting)
		{
			efWorkOrderRouting.WorkOrderID = workOrderID;
			efWorkOrderRouting.ProductID = productID;
			efWorkOrderRouting.OperationSequence = operationSequence;
			efWorkOrderRouting.LocationID = locationID;
			efWorkOrderRouting.ScheduledStartDate = scheduledStartDate;
			efWorkOrderRouting.ScheduledEndDate = scheduledEndDate;
			efWorkOrderRouting.ActualStartDate = actualStartDate;
			efWorkOrderRouting.ActualEndDate = actualEndDate;
			efWorkOrderRouting.ActualResourceHrs = actualResourceHrs;
			efWorkOrderRouting.PlannedCost = plannedCost;
			efWorkOrderRouting.ActualCost = actualCost;
			efWorkOrderRouting.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFWorkOrderRouting efWorkOrderRouting,Response response)
		{
			if(efWorkOrderRouting == null)
			{
				return;
			}
			response.AddWorkOrderRouting(new POCOWorkOrderRouting()
			{
				ProductID = efWorkOrderRouting.ProductID.ToInt(),
				OperationSequence = efWorkOrderRouting.OperationSequence,
				ScheduledStartDate = efWorkOrderRouting.ScheduledStartDate.ToDateTime(),
				ScheduledEndDate = efWorkOrderRouting.ScheduledEndDate.ToDateTime(),
				ActualStartDate = efWorkOrderRouting.ActualStartDate.ToNullableDateTime(),
				ActualEndDate = efWorkOrderRouting.ActualEndDate.ToNullableDateTime(),
				ActualResourceHrs = efWorkOrderRouting.ActualResourceHrs.ToNullableDecimal(),
				PlannedCost = efWorkOrderRouting.PlannedCost,
				ActualCost = efWorkOrderRouting.ActualCost,
				ModifiedDate = efWorkOrderRouting.ModifiedDate.ToDateTime(),

				WorkOrderID = new ReferenceEntity<int>(efWorkOrderRouting.WorkOrderID,
				                                       "WorkOrders"),
				LocationID = new ReferenceEntity<short>(efWorkOrderRouting.LocationID,
				                                        "Locations"),
			});

			WorkOrderRepository.MapEFToPOCO(efWorkOrderRouting.WorkOrder, response);

			LocationRepository.MapEFToPOCO(efWorkOrderRouting.Location, response);
		}
	}
}

/*<Codenesium>
    <Hash>1ff0746b970a1c3ecb987193827df8b9</Hash>
</Codenesium>*/