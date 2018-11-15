using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vEmployeeDepartmentHistory", Schema="HumanResources")]
	public partial class VEmployeeDepartmentHistory : AbstractEntity
	{
		public VEmployeeDepartmentHistory()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			string department,
			DateTime? endDate,
			string firstName,
			string groupName,
			string lastName,
			string middleName,
			string shift,
			DateTime startDate,
			string suffix,
			string title)
		{
			this.BusinessEntityID = businessEntityID;
			this.Department = department;
			this.EndDate = endDate;
			this.FirstName = firstName;
			this.GroupName = groupName;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.Shift = shift;
			this.StartDate = startDate;
			this.Suffix = suffix;
			this.Title = title;
		}

		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[MaxLength(50)]
		[Column("Department")]
		public virtual string Department { get; private set; }

		[Column("EndDate")]
		public virtual DateTime? EndDate { get; private set; }

		[MaxLength(50)]
		[Column("FirstName")]
		public virtual string FirstName { get; private set; }

		[MaxLength(50)]
		[Column("GroupName")]
		public virtual string GroupName { get; private set; }

		[MaxLength(50)]
		[Column("LastName")]
		public virtual string LastName { get; private set; }

		[MaxLength(50)]
		[Column("MiddleName")]
		public virtual string MiddleName { get; private set; }

		[MaxLength(50)]
		[Column("Shift")]
		public virtual string Shift { get; private set; }

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
    <Hash>9c4aca43a537a14540bedebc7e80daf5</Hash>
</Codenesium>*/