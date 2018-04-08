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
			this.ModifiedDate = modifiedDate.ToDateTime();

			ProductModelID = new ReferenceEntity<int>(productModelID,
			                                          "ProductModel");
			IllustrationID = new ReferenceEntity<int>(illustrationID,
			                                          "Illustration");
		}

		public ReferenceEntity<int>ProductModelID {get; set;}
		public ReferenceEntity<int>IllustrationID {get; set;}
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
    <Hash>676b6cd1c237a61194dbafdbebee91c0</Hash>
</Codenesium>*/