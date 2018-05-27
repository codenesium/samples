using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSpecialOfferProduct: AbstractDTO
	{
		public DTOSpecialOfferProduct() : base()
		{}

		public void SetProperties(int specialOfferID,
		                          DateTime modifiedDate,
		                          int productID,
		                          Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.SpecialOfferID = specialOfferID.ToInt();
		}

		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public Guid Rowguid { get; set; }
		public int SpecialOfferID { get; set; }
	}
}

/*<Codenesium>
    <Hash>e0ad5e39ee22b4b231b9dce437a1bb76</Hash>
</Codenesium>*/