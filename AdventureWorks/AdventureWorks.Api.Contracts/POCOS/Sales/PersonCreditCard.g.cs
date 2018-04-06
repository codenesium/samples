using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPersonCreditCard
	{
		public POCOPersonCreditCard()
		{}

		public POCOPersonCreditCard(int businessEntityID,
		                            int creditCardID,
		                            DateTime modifiedDate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "Person");
			CreditCardID = new ReferenceEntity<int>(creditCardID,
			                                        "CreditCard");
		}

		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public ReferenceEntity<int>CreditCardID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditCardIDValue {get; set;} = true;

		public bool ShouldSerializeCreditCardID()
		{
			return ShouldSerializeCreditCardIDValue;
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
			this.ShouldSerializeCreditCardIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>b2721dbeb0767beee6b25223f9e75cac</Hash>
</Codenesium>*/