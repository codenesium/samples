using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vEmployeeDepartment", Schema="HumanResources")]
	public partial class VEmployeeDepartment : AbstractEntity
	{
		public VEmployeeDepartment()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			string department,
			string firstName,
			string groupName,
			string jobTitle,
			string lastName,
			string middleName,
			DateTime startDate,
			string suffix,
			string title)
		{
			this.BusinessEntityID = businessEntityID;
			this.Department = department;
			this.FirstName = firstName;
			this.GroupName = groupName;
			this.JobTitle = jobTitle;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.StartDate = startDate;
			this.Suffix = suffix;
			this.Title = title;
		}

		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[MaxLength(50)]
		[Column("Department")]
		public virtual string Department { get; private set; }

		[MaxLength(50)]
		[Column("FirstName")]
		public virtual string FirstName { get; private set; }

		[MaxLength(50)]
		[Column("GroupName")]
		public virtual string GroupName { get; private set; }

		[MaxLength(50)]
		[Column("JobTitle")]
		public virtual string JobTitle { get; private set; }

		[MaxLength(50)]
		[Column("LastName")]
		public virtual string LastName { get; private set; }

		[MaxLength(50)]
		[Column("MiddleName")]
		public virtual string MiddleName { get; private set; }

		[Column("StartDate")]
		public virtual DateTime StartDate { get; private set; }

		[MaxLength(10)]
		[Column("Suffix")]
		public virtual string Suffix { get; private set; }

		[MaxLength(8)]
		[Column("Title")]
		public virtual string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ad8ff90350db448039dd4c46fe505e3a</Hash>
</Codenesium>*/