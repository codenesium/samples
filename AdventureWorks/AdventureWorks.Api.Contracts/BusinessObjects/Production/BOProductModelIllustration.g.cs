using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductModelIllustration: AbstractBusinessObject
	{
		public BOProductModelIllustration() : base()
		{}

		public void SetProperties(int productModelID,
		                          int illustrationID,
		                          DateTime modifiedDate)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductModelID = productModelID.ToInt();
		}

		public int IllustrationID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>87d3bdb165f604830640887af98c66bc</Hash>
</Codenesium>*/