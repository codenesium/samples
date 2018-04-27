using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOBusinessEntityContact
	{
		public POCOBusinessEntityContact()
		{}

		public POCOBusinessEntityContact(
			int businessEntityID,
			int contactTypeID,
			DateTime modifiedDate,
			int personID,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.BusinessEntities));
			this.ContactTypeID = new ReferenceEntity<int>(contactTypeID,
			                                              nameof(ApiResponse.ContactTypes));
			this.PersonID = new ReferenceEntity<int>(personID,
			                                         nameof(ApiResponse.People));
		}

		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public ReferenceEntity<int> ContactTypeID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public ReferenceEntity<int> PersonID { get; set; }
		public Guid Rowguid { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeContactTypeIDValue { get; set; } = true;

		public bool ShouldSerializeContactTypeID()
		{
			return this.ShouldSerializeContactTypeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePersonIDValue { get; set; } = true;

		public bool ShouldSerializePersonID()
		{
			return this.ShouldSerializePersonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeContactTypeIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePersonIDValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8d33e8e1e0f0a73a3e8994a6b31ff1d2</Hash>
</Codenesium>*/