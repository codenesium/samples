using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("EmployeeDepartmentHistory", Schema="HumanResources")]
        public partial class EmployeeDepartmentHistory : AbstractEntity
        {
                public EmployeeDepartmentHistory()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        short departmentID,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        int shiftID,
                        DateTime startDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.DepartmentID = departmentID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.ShiftID = shiftID;
                        this.StartDate = startDate;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("DepartmentID")]
                public short DepartmentID { get; private set; }

                [Column("EndDate")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ShiftID")]
                public int ShiftID { get; private set; }

                [Column("StartDate")]
                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6901a50de30b2eae1b3aa3493c8273bb</Hash>
</Codenesium>*/