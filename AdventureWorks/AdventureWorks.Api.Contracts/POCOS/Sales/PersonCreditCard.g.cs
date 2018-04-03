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
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditCardID = creditCardID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID {get; set;}
		public int CreditCardID {get; set;}
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
    <Hash>47f250543b4a42cda1df0977160c7e53</Hash>
</Codenesium>*/