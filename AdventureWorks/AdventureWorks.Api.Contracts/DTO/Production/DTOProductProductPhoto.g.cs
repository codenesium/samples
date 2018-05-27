using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductProductPhoto: AbstractDTO
	{
		public DTOProductProductPhoto() : base()
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

		public DateTime ModifiedDate { get; set; }
		public bool Primary { get; set; }
		public int ProductID { get; set; }
		public int ProductPhotoID { get; set; }
	}
}

/*<Codenesium>
    <Hash>47e6c11889b5c044f272ec7b3dc89db9</Hash>
</Codenesium>*/