using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductDescriptionResponseModel: AbstractApiResponseModel
	{
		public ApiProductDescriptionResponseModel() : base()
		{}

		public void SetProperties(
			string description,
			DateTime modifiedDate,
			int productDescriptionID,
			Guid rowguid)
		{
			this.Description = description;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public string Description { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductDescriptionID { get; private set; }
		public Guid Rowguid { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = true;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductDescriptionIDValue { get; set; } = true;

		public bool ShouldSerializeProductDescriptionID()
		{
			return this.ShouldSerializeProductDescriptionIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDescriptionValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductDescriptionIDValue = false;
			this.ShouldSerializeRowguidValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c24a61c22eb1b14cca5c69d29f481d92</Hash>
</Codenesium>*/