using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmployeeDepartmentHistoryModel
	{
		public ApiEmployeeDepartmentHistoryModel()
		{}

		public ApiEmployeeDepartmentHistoryModel(
			short departmentID,
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			int shiftID,
			DateTime startDate)
		{
			this.DepartmentID = departmentID;
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ShiftID = shiftID.ToInt();
			this.StartDate = startDate.ToDateTime();
		}

		private short departmentID;

		[Required]
		public short DepartmentID
		{
			get
			{
				return this.departmentID;
			}

			set
			{
				this.departmentID = value;
			}
		}

		private Nullable<DateTime> endDate;

		public Nullable<DateTime> EndDate
		{
			get
			{
				return this.endDate.IsEmptyOrZeroOrNull() ? null : this.endDate;
			}

			set
			{
				this.endDate = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private int shiftID;

		[Required]
		public int ShiftID
		{
			get
			{
				return this.shiftID;
			}

			set
			{
				this.shiftID = value;
			}
		}

		private DateTime startDate;

		[Required]
		public DateTime StartDate
		{
			get
			{
				return this.startDate;
			}

			set
			{
				this.startDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>62f406803200bd27372e997e89b0bba5</Hash>
</Codenesium>*/