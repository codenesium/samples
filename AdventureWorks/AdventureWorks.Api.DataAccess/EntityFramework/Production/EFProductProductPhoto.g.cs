using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductProductPhoto", Schema="Production")]
	public partial class EFProductProductPhoto
	{
		public EFProductProductPhoto()
		{}

		public void SetProperties(
			int productID,
			int productPhotoID,
			bool primary,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.ProductPhotoID = productPhotoID.ToInt();
			this.Primary = primary.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("ProductPhotoID", TypeName="int")]
		public int ProductPhotoID { get; set; }

		[Column("Primary", TypeName="bit")]
		public bool Primary { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }

		[ForeignKey("ProductPhotoID")]
		public virtual EFProductPhoto ProductPhoto { get; set; }
	}
}

/*<Codenesium>
    <Hash>e0824100bac017da4d7d527bb0790e3f</Hash>
</Codenesium>*/