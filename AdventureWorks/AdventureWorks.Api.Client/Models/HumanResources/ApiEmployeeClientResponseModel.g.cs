using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiEmployeeClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int businessEntityID,
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
			this.BusinessEntityID = businessEntityID;
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

		[JsonProperty]
		public DateTime BirthDate { get; private set; }

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public bool CurrentFlag { get; private set; }

		[JsonProperty]
		public string Gender { get; private set; }

		[JsonProperty]
		public DateTime HireDate { get; private set; }

		[JsonProperty]
		public string JobTitle { get; private set; }

		[JsonProperty]
		public string LoginID { get; private set; }

		[JsonProperty]
		public string MaritalStatu { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string NationalIDNumber { get; private set; }

		[JsonProperty]
		public short? OrganizationLevel { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public bool SalariedFlag { get; private set; }

		[JsonProperty]
		public short SickLeaveHour { get; private set; }

		[JsonProperty]
		public short VacationHour { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a94e1782af2e06a3612266bc72047d9a</Hash>
</Codenesium>*/