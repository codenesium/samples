using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOBusinessEntityContact
	{
		public POCOBusinessEntityContact()
		{}

		public POCOBusinessEntityContact(int businessEntityID,
		                                 int personID,
		                                 int contactTypeID,
		                                 Guid rowguid,
		                                 DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.PersonID = personID.ToInt();
			this.ContactTypeID = contactTypeID.ToInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID {get; set;}
		public int PersonID {get; set;}
		public int ContactTypeID {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePersonIDValue {get; set;} = true;

		public bool ShouldSerializePersonID()
		{
			return ShouldSerializePersonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeContactTypeIDValue {get; set;} = true;

		public bool ShouldSerializeContactTypeID()
		{
			return ShouldSerializeContactTypeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializePersonIDValue = false;
			this.ShouldSerializeContactTypeIDValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>23c622dab220b18e403dc53624395bca</Hash>
</Codenesium>*/