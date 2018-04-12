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

		public AbstractWorkOrderRoutingRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int productID,
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
			var record = new EFWorkOrderRouting();

			MapPOCOToEF(
				0,
				productID,
				operationSequence,
				locationID,
				scheduledStartDate,
				scheduledEndDate,
				actualStartDate,
				actualEndDate,
				actualResourceHrs,
				plannedCost,
				actualCost,
				modifiedDate,
				record);

			this.context.Set<EFWorkOrderRouting>().Add(record);
			this.context.SaveChanges();
			return record.WorkOrderID;
		}

		public virtual void Update(
			int workOrderID,
			int productID,
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
			var record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{workOrderID}");
			}
			else
			{
				MapPOCOToEF(
					workOrderID,
					productID,
					operationSequence,
					locationID,
					scheduledStartDate,
					scheduledEndDate,
					actualStartDate,
					actualEndDate,
					actualResourceHrs,
					plannedCost,
					actualCost,
					modifiedDate,
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
				this.context.Set<EFWorkOrderRouting>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int workOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID, response);
			return response;
		}

		public virtual POCOWorkOrderRouting GetByIdDirect(int workOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID, response);
			return response.WorkOrderRoutings.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOWorkOrderRouting> GetWhereDirect(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.WorkOrderRoutings;
		}

		private void SearchLinqPOCO(Expression<Func<EFWorkOrderRouting, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFWorkOrderRouting> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFWorkOrderRouting> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFWorkOrderRouting> SearchLinqEF(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFWorkOrderRouting> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int workOrderID,
			int productID,
			short operationSequence,
			short locationID,
			DateTime scheduledStartDate,
			DateTime scheduledEndDate,
			Nullable<DateTime> actualStartDate,
			Nullable<DateTime> actualEndDate,
			Nullable<decimal> actualResourceHrs,
			decimal plannedCost,
			Nullable<decimal> actualCost,
			DateTime modifiedDate,
			EFWorkOrderRouting efWorkOrderRouting)
		{
			efWorkOrderRouting.SetProperties(workOrderID.ToInt(), productID.ToInt(), operationSequence, locationID, scheduledStartDate.ToDateTime(), scheduledEndDate.ToDateTime(), actualStartDate.ToNullableDateTime(), actualEndDate.ToNullableDateTime(), actualResourceHrs.ToNullableDecimal(), plannedCost, actualCost, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFWorkOrderRouting efWorkOrderRouting,
			Response response)
		{
			if (efWorkOrderRouting == null)
			{
				return;
			}

			response.AddWorkOrderRouting(new POCOWorkOrderRouting(efWorkOrderRouting.WorkOrderID.ToInt(), efWorkOrderRouting.ProductID.ToInt(), efWorkOrderRouting.OperationSequence, efWorkOrderRouting.LocationID, efWorkOrderRouting.ScheduledStartDate.ToDateTime(), efWorkOrderRouting.ScheduledEndDate.ToDateTime(), efWorkOrderRouting.ActualStartDate.ToNullableDateTime(), efWorkOrderRouting.ActualEndDate.ToNullableDateTime(), efWorkOrderRouting.ActualResourceHrs.ToNullableDecimal(), efWorkOrderRouting.PlannedCost, efWorkOrderRouting.ActualCost, efWorkOrderRouting.ModifiedDate.ToDateTime()));

			WorkOrderRepository.MapEFToPOCO(efWorkOrderRouting.WorkOrder, response);

			LocationRepository.MapEFToPOCO(efWorkOrderRouting.Location, response);
		}
	}
}

/*<Codenesium>
    <Hash>1c41006bb64d122b4d16635dea93dc98</Hash>
</Codenesium>*/