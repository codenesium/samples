using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Department", Schema="HumanResources")]
        public partial class Department : AbstractEntity
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
                [Column("DepartmentID")]
                public short DepartmentID { get; private set; }

                [Column("GroupName")]
                public string GroupName { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>53eb7438edddf06b878e6d5193f0b830</Hash>
</Codenesium>*/