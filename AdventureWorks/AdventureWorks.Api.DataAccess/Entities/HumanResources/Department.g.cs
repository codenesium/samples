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
		public short DepartmentID { get; private set; }

		[MaxLength(50)]
		[Column("GroupName")]
		public string GroupName { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>31ec622c1fbabb4019b0c02518cd0826</Hash>
</Codenesium>*/