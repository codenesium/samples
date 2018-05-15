using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCODepartment
	{
		public POCODepartment()
		{}

		public POCODepartment(
			short departmentID,
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

		[JsonIgnore]
		public bool ShouldSerializeDepartmentIDValue { get; set; } = true;

		public bool ShouldSerializeDepartmentID()
		{
			return this.ShouldSerializeDepartmentIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeGroupNameValue { get; set; } = true;

		public bool ShouldSerializeGroupName()
		{
			return this.ShouldSerializeGroupNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDepartmentIDValue = false;
			this.ShouldSerializeGroupNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>98db9a78bf4ac78016f9859d11904992</Hash>
</Codenesium>*/