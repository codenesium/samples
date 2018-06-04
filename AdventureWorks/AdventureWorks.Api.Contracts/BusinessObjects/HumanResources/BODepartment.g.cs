using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
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
    <Hash>c106d1e8a0e9b397a2952b8bf1b517f6</Hash>
</Codenesium>*/