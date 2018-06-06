using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOProductProductPhoto: AbstractBusinessObject
	{
		public BOProductProductPhoto() : base()
		{}

		public void SetProperties(int productID,
		                          DateTime modifiedDate,
		                          bool primary,
		                          int productPhotoID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Primary = primary.ToBoolean();
			this.ProductID = productID.ToInt();
			this.ProductPhotoID = productPhotoID.ToInt();
		}

		public DateTime ModifiedDate { get; private set; }
		public bool Primary { get; private set; }
		public int ProductID { get; private set; }
		public int ProductPhotoID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a8c242052306f04d8dd72064d37af390</Hash>
</Codenesium>*/