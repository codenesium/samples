using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTODepartment: AbstractDTO
	{
		public DTODepartment() : base()
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

		public short DepartmentID { get; set; }
		public string GroupName { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>e0e3391609131b766f5784053918622b</Hash>
</Codenesium>*/