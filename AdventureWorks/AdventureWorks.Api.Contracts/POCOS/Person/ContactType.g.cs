using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOContactType
	{
		public POCOContactType()
		{}

		public POCOContactType(int contactTypeID,
		                       string name,
		                       DateTime modifiedDate)
		{
			this.ContactTypeID = contactTypeID.ToInt();
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ContactTypeID {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeContactTypeIDValue {get; set;} = true;

		public bool ShouldSerializeContactTypeID()
		{
			return ShouldSerializeContactTypeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeContactTypeIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>f73485b4ab2c8f35221aa00e608bc213</Hash>
</Codenesium>*/