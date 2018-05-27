using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductModelIllustration: AbstractDTO
	{
		public DTOProductModelIllustration() : base()
		{}

		public void SetProperties(int productModelID,
		                          int illustrationID,
		                          DateTime modifiedDate)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductModelID = productModelID.ToInt();
		}

		public int IllustrationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductModelID { get; set; }
	}
}

/*<Codenesium>
    <Hash>5f304670087de96522ed43b93e4c53fe</Hash>
</Codenesium>*/