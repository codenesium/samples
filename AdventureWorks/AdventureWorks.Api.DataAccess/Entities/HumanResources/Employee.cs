using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Employee", Schema="HumanResources")]
        public partial class Employee : AbstractEntity
        {
                public Employee()
                {
                }

                public void SetProperties(
                        DateTime birthDate,
                        int businessEntityID,
                        bool currentFlag,
                        string gender,
                        DateTime hireDate,
                        string jobTitle,
                        string loginID,
                        string maritalStatus,
                        DateTime modifiedDate,
                        string nationalIDNumber,
                        Nullable<short> organizationLevel,
                        Guid rowguid,
                        bool salariedFlag,
                        short sickLeaveHours,
                        short vacationHours)
                {
                        this.BirthDate = birthDate;
                        this.BusinessEntityID = businessEntityID;
                        this.CurrentFlag = currentFlag;
                        this.Gender = gender;
                        this.HireDate = hireDate;
                        this.JobTitle = jobTitle;
                        this.LoginID = loginID;
                        this.MaritalStatus = maritalStatus;
                        this.ModifiedDate = modifiedDate;
                        this.NationalIDNumber = nationalIDNumber;
                        this.OrganizationLevel = organizationLevel;
                        this.Rowguid = rowguid;
                        this.SalariedFlag = salariedFlag;
                        this.SickLeaveHours = sickLeaveHours;
                        this.VacationHours = vacationHours;
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
                public string MaritalStatus { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("NationalIDNumber")]
                public string NationalIDNumber { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("OrganizationLevel")]
                public Nullable<short> OrganizationLevel { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("SalariedFlag")]
                public bool SalariedFlag { get; private set; }

                [Column("SickLeaveHours")]
                public short SickLeaveHours { get; private set; }

                [Column("VacationHours")]
                public short VacationHours { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ca7c3ed0b85b75985ba97ffc1ff29b1e</Hash>
</Codenesium>*/