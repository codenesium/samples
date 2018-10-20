using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmployeeDepartmentHistoryRequestModel : AbstractApiRequestModel
	{
		public ApiEmployeeDepartmentHistoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			short departmentID,
			DateTime? endDate,
			DateTime modifiedDate,
			int shiftID,
			DateTime startDate)
		{
			this.DepartmentID = departmentID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.ShiftID = shiftID;
			this.StartDate = startDate;
		}

		[Required]
		[JsonProperty]
		public short DepartmentID { get; private set; } = default(short);

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int ShiftID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; } = default(DateTime);
	}
}

/*<Codenesium>
    <Hash>8b402194c1ea155d0af4ed2f8caede60</Hash>
</Codenesium>*/