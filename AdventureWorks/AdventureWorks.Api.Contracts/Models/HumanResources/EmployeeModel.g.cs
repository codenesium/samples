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
			DateTime birthDate,
			bool currentFlag,
			string gender,
			DateTime hireDate,
			string jobTitle,
			string loginID,
			string maritalStatus,
			DateTime modifiedDate,
			string nationalIDNumber,
			Nullable<short> organizationLevel,
			Nullable<Guid> organizationNode,
			Guid rowguid,
			bool salariedFlag,
			short sickLeaveHours,
			short vacationHours)
		{
			this.BirthDate = birthDate.ToDateTime();
			this.CurrentFlag = currentFlag.ToBoolean();
			this.Gender = gender.ToString();
			this.HireDate = hireDate.ToDateTime();
			this.JobTitle = jobTitle.ToString();
			this.LoginID = loginID.ToString();
			this.MaritalStatus = maritalStatus.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.NationalIDNumber = nationalIDNumber.ToString();
			this.OrganizationLevel = organizationLevel;
			this.OrganizationNode = organizationNode;
			this.Rowguid = rowguid.ToGuid();
			this.SalariedFlag = salariedFlag.ToBoolean();
			this.SickLeaveHours = sickLeaveHours;
			this.VacationHours = vacationHours;
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
	}
}

/*<Codenesium>
    <Hash>d29f8dfde9055dd3fad0ed023260bf28</Hash>
</Codenesium>*/