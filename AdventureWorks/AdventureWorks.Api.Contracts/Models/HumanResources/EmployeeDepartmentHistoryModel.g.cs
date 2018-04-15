using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class EmployeeDepartmentHistoryModel
	{
		public EmployeeDepartmentHistoryModel()
		{}

		public EmployeeDepartmentHistoryModel(
			short departmentID,
			int shiftID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime modifiedDate)
		{
			this.DepartmentID = departmentID;
			this.ShiftID = shiftID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>d715ae952f33e3b416ecd6c9efbe2d7c</Hash>
</Codenesium>*/