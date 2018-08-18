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
    <Hash>79c32260564de8fbdb52a9128a3c8fb9</Hash>
</Codenesium>*/