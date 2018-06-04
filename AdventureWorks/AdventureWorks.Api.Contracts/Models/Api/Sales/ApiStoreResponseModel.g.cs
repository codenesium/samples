using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiStoreResponseModel: AbstractApiResponseModel
	{
		public ApiStoreResponseModel() : base()
		{}

		public void SetProperties(
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
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.SalesPersonID = salesPersonID.ToNullableInt();

			this.SalesPersonIDEntity = nameof(ApiResponse.SalesPersons);
		}

		public int BusinessEntityID { get; private set; }
		public string Demographics { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public Guid Rowguid { get; private set; }
		public Nullable<int> SalesPersonID { get; private set; }
		public string SalesPersonIDEntity { get; set; }

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
    <Hash>94fbf6973e573f1cdaf0aa7a2af216f9</Hash>
</Codenesium>*/