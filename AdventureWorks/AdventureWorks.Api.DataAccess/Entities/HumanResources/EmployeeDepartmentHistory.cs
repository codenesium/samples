using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("EmployeeDepartmentHistory", Schema="HumanResources")]
        public partial class EmployeeDepartmentHistory: AbstractEntity
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
                [Column("BusinessEntityID", TypeName="int")]
                public int BusinessEntityID { get; private set; }

                [Column("DepartmentID", TypeName="smallint")]
                public short DepartmentID { get; private set; }

                [Column("EndDate", TypeName="date")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ShiftID", TypeName="tinyint")]
                public int ShiftID { get; private set; }

                [Column("StartDate", TypeName="date")]
                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4432e94ffca103567f1ec50c68066d76</Hash>
</Codenesium>*/