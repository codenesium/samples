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
			string name,
			string groupName,
			DateTime modifiedDate)
		{
			this.DepartmentID = departmentID;
			this.Name = name.ToString();
			this.GroupName = groupName.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public short DepartmentID { get; set; }
		public string Name { get; set; }
		public string GroupName { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDepartmentIDValue { get; set; } = true;

		public bool ShouldSerializeDepartmentID()
		{
			return this.ShouldSerializeDepartmentIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
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

		public void DisableAllFields()
		{
			this.ShouldSerializeDepartmentIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeGroupNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e7c91e478e09d5854f53b8492b2a1fe4</Hash>
</Codenesium>*/