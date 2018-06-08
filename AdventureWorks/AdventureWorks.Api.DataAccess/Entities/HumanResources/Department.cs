using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Department", Schema="HumanResources")]
        public partial class Department: AbstractEntity
        {
                public Department()
                {
                }

                public void SetProperties(
                        short departmentID,
                        string groupName,
                        DateTime modifiedDate,
                        string name)
                {
                        this.DepartmentID = departmentID;
                        this.GroupName = groupName;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Key]
                [Column("DepartmentID", TypeName="smallint")]
                public short DepartmentID { get; private set; }

                [Column("GroupName", TypeName="nvarchar(50)")]
                public string GroupName { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e9bf7bb41df9b59091364cf02c594b94</Hash>
</Codenesium>*/