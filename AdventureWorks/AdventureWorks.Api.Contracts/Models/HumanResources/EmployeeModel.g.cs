using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class EmployeeModel
	{
		public EmployeeModel()
		{}

		public EmployeeModel(
			string nationalIDNumber,
			string loginID,
			Nullable<Guid> organizationNode,
			Nullable<short> organizationLevel,
			string jobTitle,
			DateTime birthDate,
			string maritalStatus,
			string gender,
			DateTime hireDate,
			bool salariedFlag,
			short vacationHours,
			short sickLeaveHours,
			bool currentFlag,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.NationalIDNumber = nationalIDNumber;
			this.LoginID = loginID;
			this.OrganizationNode = organizationNode;
			this.OrganizationLevel = organizationLevel;
			this.JobTitle = jobTitle;
			this.BirthDate = birthDate;
			this.MaritalStatus = maritalStatus;
			this.Gender = gender;
			this.HireDate = hireDate;
			this.SalariedFlag = salariedFlag;
			this.VacationHours = vacationHours;
			this.SickLeaveHours = sickLeaveHours;
			this.CurrentFlag = currentFlag;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string nationalIDNumber;

		[Required]
		public string NationalIDNumber
		{
			get
			{
				return this.nationalIDNumber;
			}

			set
			{
				this.nationalIDNumber = value;
			}
		}

		private string loginID;

		[Required]
		public string LoginID
		{
			get
			{
				return this.loginID;
			}

			set
			{
				this.loginID = value;
			}
		}

		private Nullable<Guid> organizationNode;

		public Nullable<Guid> OrganizationNode
		{
			get
			{
				return this.organizationNode.IsEmptyOrZeroOrNull() ? null : this.organizationNode;
			}

			set
			{
				this.organizationNode = value;
			}
		}

		private Nullable<short> organizationLevel;

		public Nullable<short> OrganizationLevel
		{
			get
			{
				return this.organizationLevel.IsEmptyOrZeroOrNull() ? null : this.organizationLevel;
			}

			set
			{
				this.organizationLevel = value;
			}
		}

		private string jobTitle;

		[Required]
		public string JobTitle
		{
			get
			{
				return this.jobTitle;
			}

			set
			{
				this.jobTitle = value;
			}
		}

		private DateTime birthDate;

		[Required]
		public DateTime BirthDate
		{
			get
			{
				return this.birthDate;
			}

			set
			{
				this.birthDate = value;
			}
		}

		private string maritalStatus;

		[Required]
		public string MaritalStatus
		{
			get
			{
				return this.maritalStatus;
			}

			set
			{
				this.maritalStatus = value;
			}
		}

		private string gender;

		[Required]
		public string Gender
		{
			get
			{
				return this.gender;
			}

			set
			{
				this.gender = value;
			}
		}

		private DateTime hireDate;

		[Required]
		public DateTime HireDate
		{
			get
			{
				return this.hireDate;
			}

			set
			{
				this.hireDate = value;
			}
		}

		private bool salariedFlag;

		[Required]
		public bool SalariedFlag
		{
			get
			{
				return this.salariedFlag;
			}

			set
			{
				this.salariedFlag = value;
			}
		}

		private short vacationHours;

		[Required]
		public short VacationHours
		{
			get
			{
				return this.vacationHours;
			}

			set
			{
				this.vacationHours = value;
			}
		}

		private short sickLeaveHours;

		[Required]
		public short SickLeaveHours
		{
			get
			{
				return this.sickLeaveHours;
			}

			set
			{
				this.sickLeaveHours = value;
			}
		}

		private bool currentFlag;

		[Required]
		public bool CurrentFlag
		{
			get
			{
				return this.currentFlag;
			}

			set
			{
				this.currentFlag = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
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
    <Hash>02dacbf4277438d3c7b488b8bb257eda</Hash>
</Codenesium>*/