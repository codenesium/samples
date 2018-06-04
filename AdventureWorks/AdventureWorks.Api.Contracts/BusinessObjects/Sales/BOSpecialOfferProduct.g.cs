using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOSpecialOfferProduct: AbstractBusinessObject
	{
		public BOSpecialOfferProduct() : base()
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

		public DateTime ModifiedDate { get; private set; }
		public int ProductID { get; private set; }
		public Guid Rowguid { get; private set; }
		public int SpecialOfferID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0b241e90bfa91c267f6c2c99de588ade</Hash>
</Codenesium>*/