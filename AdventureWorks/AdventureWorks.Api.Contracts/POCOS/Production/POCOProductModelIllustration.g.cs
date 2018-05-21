using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductModelIllustration: AbstractPOCO
	{
		public POCOProductModelIllustration() : base()
		{}

		public POCOProductModelIllustration(
			int illustrationID,
			DateTime modifiedDate,
			int productModelID)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductModelID = productModelID.ToInt();
		}

		public int IllustrationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductModelID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIllustrationIDValue { get; set; } = true;

		public bool ShouldSerializeIllustrationID()
		{
			return this.ShouldSerializeIllustrationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductModelIDValue { get; set; } = true;

		public bool ShouldSerializeProductModelID()
		{
			return this.ShouldSerializeProductModelIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIllustrationIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductModelIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>bf4e9497088b498becdf0de29fe2b6e4</Hash>
</Codenesium>*/