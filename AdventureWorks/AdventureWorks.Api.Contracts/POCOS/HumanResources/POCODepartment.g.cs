using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCODepartment
	{
		public POCODepartment()
		{}

		public POCODepartment(short departmentID,
		                      string name,
		                      string groupName,
		                      DateTime modifiedDate)
		{
			this.DepartmentID = departmentID;
			this.Name = name;
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public short DepartmentID {get; set;}
		public string Name {get; set;}
		public string GroupName {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeDepartmentIDValue {get; set;} = true;

		public bool ShouldSerializeDepartmentID()
		{
			return ShouldSerializeDepartmentIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeGroupNameValue {get; set;} = true;

		public bool ShouldSerializeGroupName()
		{
			return ShouldSerializeGroupNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>bd32c2cd16b30c9300b9b2785769720c</Hash>
</Codenesium>*/