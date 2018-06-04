using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductProductPhoto", Schema="Production")]
	public partial class ProductProductPhoto: AbstractEntity
	{
		public ProductProductPhoto()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			bool primary,
			int productID,
			int productPhotoID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Primary = primary.ToBoolean();
			this.ProductID = productID.ToInt();
			this.ProductPhotoID = productPhotoID.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Primary", TypeName="bit")]
		public bool Primary { get; private set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }

		[Column("ProductPhotoID", TypeName="int")]
		public int ProductPhotoID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7631d6b5e2b8286ef62112e0f05bcb54</Hash>
</Codenesium>*/