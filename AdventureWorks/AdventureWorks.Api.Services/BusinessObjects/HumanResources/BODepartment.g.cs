using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BODepartment: AbstractBusinessObject
	{
		public BODepartment() : base()
		{}

		public void SetProperties(short departmentID,
		                          string groupName,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.DepartmentID = departmentID;
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public short DepartmentID { get; private set; }
		public string GroupName { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7a64be0ec23035347dd793e86bce74af</Hash>
</Codenesium>*/