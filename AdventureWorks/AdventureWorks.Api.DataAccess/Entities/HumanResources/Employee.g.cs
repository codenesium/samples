using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Employee", Schema="HumanResources")]
	public partial class Employee : AbstractEntity
	{
		public Employee()
		{
		}

		public virtual void SetProperties(
			DateTime birthDate,
			int businessEntityID,
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

		[Column("BirthDate")]
		public virtual DateTime BirthDate { get; private set; }

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("CurrentFlag")]
		public virtual bool CurrentFlag { get; private set; }

		[MaxLength(1)]
		[Column("Gender")]
		public virtual string Gender { get; private set; }

		[Column("HireDate")]
		public virtual DateTime HireDate { get; private set; }

		[MaxLength(50)]
		[Column("JobTitle")]
		public virtual string JobTitle { get; private set; }

		[MaxLength(256)]
		[Column("LoginID")]
		public virtual string LoginID { get; private set; }

		[MaxLength(1)]
		[Column("MaritalStatus")]
		public virtual string MaritalStatu { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(15)]
		[Column("NationalIDNumber")]
		public virtual string NationalIDNumber { get; private set; }

		[Column("OrganizationLevel")]
		public virtual short? OrganizationLevel { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("SalariedFlag")]
		public virtual bool SalariedFlag { get; private set; }

		[Column("SickLeaveHours")]
		public virtual short SickLeaveHour { get; private set; }

		[Column("VacationHours")]
		public virtual short VacationHour { get; private set; }
	}
}

/*<Codenesium>
    <Hash>386d5c9bf977f46644b394f76bc61e0d</Hash>
</Codenesium>*/