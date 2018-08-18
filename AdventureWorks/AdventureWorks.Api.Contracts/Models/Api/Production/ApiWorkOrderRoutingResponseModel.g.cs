using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiWorkOrderRoutingResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int workOrderID,
			decimal? actualCost,
			DateTime? actualEndDate,
			double? actualResourceHr,
			DateTime? actualStartDate,
			short locationID,
			DateTime modifiedDate,
			short operationSequence,
			decimal plannedCost,
			int productID,
			DateTime scheduledEndDate,
			DateTime scheduledStartDate)
		{
			this.WorkOrderID = workOrderID;
			this.ActualCost = actualCost;
			this.ActualEndDate = actualEndDate;
			this.ActualResourceHr = actualResourceHr;
			this.ActualStartDate = actualStartDate;
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate;
			this.OperationSequence = operationSequence;
			this.PlannedCost = plannedCost;
			this.ProductID = productID;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
		}

		[Required]
		[JsonProperty]
		public decimal? ActualCost { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; }

		[Required]
		[JsonProperty]
		public double? ActualResourceHr { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; }

		[JsonProperty]
		public short LocationID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public short OperationSequence { get; private set; }

		[JsonProperty]
		public decimal PlannedCost { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public DateTime ScheduledEndDate { get; private set; }

		[JsonProperty]
		public DateTime ScheduledStartDate { get; private set; }

		[JsonProperty]
		public int WorkOrderID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bc7f9b49c0f28e3cf00a0ba9e7b70794</Hash>
</Codenesium>*/