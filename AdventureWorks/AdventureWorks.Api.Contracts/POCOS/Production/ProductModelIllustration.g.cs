using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductModelIllustration
	{
		public POCOProductModelIllustration()
		{}

		public POCOProductModelIllustration(int productModelID,
		                                    int illustrationID,
		                                    DateTime modifiedDate)
		{
			this.ProductModelID = productModelID.ToInt();
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductModelID {get; set;}
		public int IllustrationID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue {get; set;} = true;

		public bool ShouldSerializeProductModelID()
		{
			return ShouldSerializeProductModelIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIllustrationIDValue {get; set;} = true;

		public bool ShouldSerializeIllustrationID()
		{
			return ShouldSerializeIllustrationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeProductModelIDValue = false;
			this.ShouldSerializeIllustrationIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>bf33a13e5ee91c6d4329388b29319e2d</Hash>
</Codenesium>*/