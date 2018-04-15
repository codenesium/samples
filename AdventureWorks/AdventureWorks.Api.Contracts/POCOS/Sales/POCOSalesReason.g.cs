using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesReason
	{
		public POCOSalesReason()
		{}

		public POCOSalesReason(
			int salesReasonID,
			string name,
			string reasonType,
			DateTime modifiedDate)
		{
			this.SalesReasonID = salesReasonID.ToInt();
			this.Name = name.ToString();
			this.ReasonType = reasonType.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int SalesReasonID { get; set; }
		public string Name { get; set; }
		public string ReasonType { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeSalesReasonIDValue { get; set; } = true;

		public bool ShouldSerializeSalesReasonID()
		{
			return this.ShouldSerializeSalesReasonIDValue;
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
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeSalesReasonIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeReasonTypeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c18cf8f7aadad2cd51a31cc54e15fdd7</Hash>
</Codenesium>*/