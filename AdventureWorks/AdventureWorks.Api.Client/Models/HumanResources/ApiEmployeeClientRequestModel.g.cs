using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiEmployeeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiEmployeeClientRequestModel()
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

		[JsonProperty]
		public DateTime BirthDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public bool CurrentFlag { get; private set; } = default(bool);

		[JsonProperty]
		public string Gender { get; private set; } = default(string);

		[JsonProperty]
		public DateTime HireDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string JobTitle { get; private set; } = default(string);

		[JsonProperty]
		public string LoginID { get; private set; } = default(string);

		[JsonProperty]
		public string MaritalStatu { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string NationalIDNumber { get; private set; } = default(string);

		[JsonProperty]
		public short? OrganizationLevel { get; private set; } = default(short);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public bool SalariedFlag { get; private set; } = default(bool);

		[JsonProperty]
		public short SickLeaveHour { get; private set; } = default(short);

		[JsonProperty]
		public short VacationHour { get; private set; } = default(short);
	}
}

/*<Codenesium>
    <Hash>ecb835515afff929c4ea9304c4fcc781</Hash>
</Codenesium>*/