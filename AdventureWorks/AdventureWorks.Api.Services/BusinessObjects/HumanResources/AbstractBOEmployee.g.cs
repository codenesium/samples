using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOEmployee : AbstractBusinessObject
	{
		public AbstractBOEmployee()
			: base()
		{
		}

		public virtual void SetProperties(int businessEntityID,
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
			this.BusinessEntityID = businessEntityID;
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

		public DateTime BirthDate { get; private set; }

		public int BusinessEntityID { get; private set; }

		public bool CurrentFlag { get; private set; }

		public string Gender { get; private set; }

		public DateTime HireDate { get; private set; }

		public string JobTitle { get; private set; }

		public string LoginID { get; private set; }

		public string MaritalStatu { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string NationalIDNumber { get; private set; }

		public short? OrganizationLevel { get; private set; }

		public Guid Rowguid { get; private set; }

		public bool SalariedFlag { get; private set; }

		public short SickLeaveHour { get; private set; }

		public short VacationHour { get; private set; }
	}
}

/*<Codenesium>
    <Hash>00d328272e4f9943eb4942f1ddc5e13c</Hash>
</Codenesium>*/