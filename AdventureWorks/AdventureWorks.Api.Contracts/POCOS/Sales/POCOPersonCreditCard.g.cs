using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPersonCreditCard: AbstractPOCO
	{
		public POCOPersonCreditCard() : base()
		{}

		public POCOPersonCreditCard(
			int businessEntityID,
			int creditCardID,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.CreditCardID = new ReferenceEntity<int>(creditCardID,
			                                             nameof(ApiResponse.CreditCards));
		}

		public int BusinessEntityID { get; set; }
		public ReferenceEntity<int> CreditCardID { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardIDValue { get; set; } = true;

		public bool ShouldSerializeCreditCardID()
		{
			return this.ShouldSerializeCreditCardIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeCreditCardIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e42fe4f080e615043c01c48f81e5cb10</Hash>
</Codenesium>*/