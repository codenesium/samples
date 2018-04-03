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
		public EmployeeModel(string nationalIDNumber,
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

		private string _nationalIDNumber;
		[Required]
		public string NationalIDNumber
		{
			get
			{
				return _nationalIDNumber;
			}
			set
			{
				this._nationalIDNumber = value;
			}
		}

		private string _loginID;
		[Required]
		public string LoginID
		{
			get
			{
				return _loginID;
			}
			set
			{
				this._loginID = value;
			}
		}

		private Nullable<Guid> _organizationNode;
		public Nullable<Guid> OrganizationNode
		{
			get
			{
				return _organizationNode.IsEmptyOrZeroOrNull() ? null : _organizationNode;
			}
			set
			{
				this._organizationNode = value;
			}
		}

		private Nullable<short> _organizationLevel;
		public Nullable<short> OrganizationLevel
		{
			get
			{
				return _organizationLevel.IsEmptyOrZeroOrNull() ? null : _organizationLevel;
			}
			set
			{
				this._organizationLevel = value;
			}
		}

		private string _jobTitle;
		[Required]
		public string JobTitle
		{
			get
			{
				return _jobTitle;
			}
			set
			{
				this._jobTitle = value;
			}
		}

		private DateTime _birthDate;
		[Required]
		public DateTime BirthDate
		{
			get
			{
				return _birthDate;
			}
			set
			{
				this._birthDate = value;
			}
		}

		private string _maritalStatus;
		[Required]
		public string MaritalStatus
		{
			get
			{
				return _maritalStatus;
			}
			set
			{
				this._maritalStatus = value;
			}
		}

		private string _gender;
		[Required]
		public string Gender
		{
			get
			{
				return _gender;
			}
			set
			{
				this._gender = value;
			}
		}

		private DateTime _hireDate;
		[Required]
		public DateTime HireDate
		{
			get
			{
				return _hireDate;
			}
			set
			{
				this._hireDate = value;
			}
		}

		private bool _salariedFlag;
		[Required]
		public bool SalariedFlag
		{
			get
			{
				return _salariedFlag;
			}
			set
			{
				this._salariedFlag = value;
			}
		}

		private short _vacationHours;
		[Required]
		public short VacationHours
		{
			get
			{
				return _vacationHours;
			}
			set
			{
				this._vacationHours = value;
			}
		}

		private short _sickLeaveHours;
		[Required]
		public short SickLeaveHours
		{
			get
			{
				return _sickLeaveHours;
			}
			set
			{
				this._sickLeaveHours = value;
			}
		}

		private bool _currentFlag;
		[Required]
		public bool CurrentFlag
		{
			get
			{
				return _currentFlag;
			}
			set
			{
				this._currentFlag = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>54d0abd1aae2cf8bb67603f248a7edb3</Hash>
</Codenesium>*/