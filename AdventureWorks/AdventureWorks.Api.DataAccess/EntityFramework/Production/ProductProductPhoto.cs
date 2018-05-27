using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductProductPhoto", Schema="Production")]
	public partial class ProductProductPhoto: AbstractEntityFrameworkDTO
	{
		public ProductProductPhoto()
		{}

		public void SetProperties(
			int productID,
			DateTime modifiedDate,
			bool primary,
			int productPhotoID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Primary = primary.ToBoolean();
			this.ProductID = productID.ToInt();
			this.ProductPhotoID = productPhotoID.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Primary", TypeName="bit")]
		public bool Primary { get; set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("ProductPhotoID", TypeName="int")]
		public int ProductPhotoID { get; set; }
	}
}

/*<Codenesium>
    <Hash>9b510020f99345d2ec8fcf49b0b1c28e</Hash>
</Codenesium>*/