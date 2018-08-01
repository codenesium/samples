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
		public short DepartmentID { get; private set; }

		[JsonProperty]
		public DateTime? EndDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int ShiftID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>31843ef07fca2d039c3ead7cf537b768</Hash>
</Codenesium>*/