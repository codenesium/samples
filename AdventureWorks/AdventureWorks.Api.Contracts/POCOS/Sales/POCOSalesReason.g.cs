using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesReason: AbstractPOCO
	{
		public POCOSalesReason() : base()
		{}

		public POCOSalesReason(
			DateTime modifiedDate,
			string name,
			string reasonType,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ReasonType = reasonType;
			this.SalesReasonID = salesReasonID.ToInt();
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public string ReasonType { get; set; }
		public int SalesReasonID { get; set; }

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
		public bool ShouldSerializeReasonTypeValue { get; set; } = true;

		public bool ShouldSerializeReasonType()
		{
			return this.ShouldSerializeReasonTypeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesReasonIDValue { get; set; } = true;

		public bool ShouldSerializeSalesReasonID()
		{
			return this.ShouldSerializeSalesReasonIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeReasonTypeValue = false;
			this.ShouldSerializeSalesReasonIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>604053c3d99dce6bafa2abaf3550658b</Hash>
</Codenesium>*/