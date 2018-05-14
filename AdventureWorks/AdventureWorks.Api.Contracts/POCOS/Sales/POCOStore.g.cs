using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOStore
	{
		public POCOStore()
		{}

		public POCOStore(
			int businessEntityID,
			string demographics,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			Nullable<int> salesPersonID)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.Demographics = demographics;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();

			this.SalesPersonID = new ReferenceEntity<Nullable<int>>(salesPersonID,
			                                                        nameof(ApiResponse.SalesPersons));
		}

		public int BusinessEntityID { get; set; }
		public string Demographics { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public ReferenceEntity<Nullable<int>> SalesPersonID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDemographicsValue { get; set; } = true;

		public bool ShouldSerializeDemographics()
		{
			return this.ShouldSerializeDemographicsValue;
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

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesPersonIDValue { get; set; } = true;

		public bool ShouldSerializeSalesPersonID()
		{
			return this.ShouldSerializeSalesPersonIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeDemographicsValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSalesPersonIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>6a4a79f133d208d467a885b414c89b4d</Hash>
</Codenesium>*/