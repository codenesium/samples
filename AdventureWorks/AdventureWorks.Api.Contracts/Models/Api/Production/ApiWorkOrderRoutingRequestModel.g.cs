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
		public decimal? ActualCost { get; private set; } = default(decimal);

		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public double? ActualResourceHr { get; private set; } = default(double);

		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public short LocationID { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public short OperationSequence { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public decimal PlannedCost { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ScheduledEndDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime ScheduledStartDate { get; private set; } = default(DateTime);
	}
}

/*<Codenesium>
    <Hash>5a3e16afb90fe3d4e2162cd9d6b2009a</Hash>
</Codenesium>*/