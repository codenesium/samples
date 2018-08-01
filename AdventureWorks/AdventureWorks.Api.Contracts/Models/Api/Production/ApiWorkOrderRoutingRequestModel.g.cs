using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiWorkOrderRoutingRequestModel : AbstractApiRequestModel
	{
		public ApiWorkOrderRoutingRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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

		[JsonProperty]
		public decimal? ActualCost { get; private set; }

		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; }

		[JsonProperty]
		public double? ActualResourceHr { get; private set; }

		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; }

		[Required]
		[JsonProperty]
		public short LocationID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public short OperationSequence { get; private set; }

		[Required]
		[JsonProperty]
		public decimal PlannedCost { get; private set; }

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ScheduledEndDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ScheduledStartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>544f964cdd84a2f042ed786c0b1f4f5d</Hash>
</Codenesium>*/