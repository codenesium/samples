using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmployeeRequestModel : AbstractApiRequestModel
	{
		public ApiEmployeeRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime birthDate,
			bool currentFlag,
			string gender,
			DateTime hireDate,
			string jobTitle,
			string loginID,
			string maritalStatu,
			DateTime modifiedDate,
			string nationalIDNumber,
			short? organizationLevel,
			Guid rowguid,
			bool salariedFlag,
			short sickLeaveHour,
			short vacationHour)
		{
			this.BirthDate = birthDate;
			this.CurrentFlag = currentFlag;
			this.Gender = gender;
			this.HireDate = hireDate;
			this.JobTitle = jobTitle;
			this.LoginID = loginID;
			this.MaritalStatu = maritalStatu;
			this.ModifiedDate = modifiedDate;
			this.NationalIDNumber = nationalIDNumber;
			this.OrganizationLevel = organizationLevel;
			this.Rowguid = rowguid;
			this.SalariedFlag = salariedFlag;
			this.SickLeaveHour = sickLeaveHour;
			this.VacationHour = vacationHour;
		}

		[Required]
		[JsonProperty]
		public DateTime BirthDate { get; private set; }

		[Required]
		[JsonProperty]
		public bool CurrentFlag { get; private set; }

		[Required]
		[JsonProperty]
		public string Gender { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime HireDate { get; private set; }

		[Required]
		[JsonProperty]
		public string JobTitle { get; private set; }

		[Required]
		[JsonProperty]
		public string LoginID { get; private set; }

		[Required]
		[JsonProperty]
		public string MaritalStatu { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string NationalIDNumber { get; private set; }

		[JsonProperty]
		public short? OrganizationLevel { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public bool SalariedFlag { get; private set; }

		[Required]
		[JsonProperty]
		public short SickLeaveHour { get; private set; }

		[Required]
		[JsonProperty]
		public short VacationHour { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f87837117b6c6df2a38dd665ff7782a5</Hash>
</Codenesium>*/