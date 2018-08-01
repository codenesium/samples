using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBODepartment : AbstractBusinessObject
	{
		public AbstractBODepartment()
			: base()
		{
		}

		public virtual void SetProperties(short departmentID,
		                                  string groupName,
		                                  DateTime modifiedDate,
		                                  string name)
		{
			this.DepartmentID = departmentID;
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		public short DepartmentID { get; private set; }

		public string GroupName { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b99364e2245162282e07feefb543bbb8</Hash>
</Codenesium>*/