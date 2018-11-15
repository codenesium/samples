using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Department", Schema="HumanResources")]
	public partial class Department : AbstractEntity
	{
		public Department()
		{
		}

		public virtual void SetProperties(
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
		public virtual short DepartmentID { get; private set; }

		[MaxLength(50)]
		[Column("GroupName")]
		public virtual string GroupName { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bda38d997a1cc05deffac45055483c11</Hash>
</Codenesium>*/