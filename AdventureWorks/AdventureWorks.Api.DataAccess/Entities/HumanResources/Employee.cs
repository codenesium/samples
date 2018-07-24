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
                public DateTime BirthDate { get; private set; }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("CurrentFlag")]
                public bool CurrentFlag { get; private set; }

                [Column("Gender")]
                public string Gender { get; private set; }

                [Column("HireDate")]
                public DateTime HireDate { get; private set; }

                [Column("JobTitle")]
                public string JobTitle { get; private set; }

                [Column("LoginID")]
                public string LoginID { get; private set; }

                [Column("MaritalStatus")]
                public string MaritalStatu { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("NationalIDNumber")]
                public string NationalIDNumber { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("OrganizationLevel")]
                public short? OrganizationLevel { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("SalariedFlag")]
                public bool SalariedFlag { get; private set; }

                [Column("SickLeaveHours")]
                public short SickLeaveHour { get; private set; }

                [Column("VacationHours")]
                public short VacationHour { get; private set; }
        }
}

/*<Codenesium>
    <Hash>32dea7ff7d8ec1392e8a25b661ba16e3</Hash>
</Codenesium>*/