using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductProductPhoto", Schema="Production")]
	public partial class EFProductProductPhoto: AbstractEntityFrameworkPOCO
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
    <Hash>9e81631623fae4d182d5c449ade644e8</Hash>
</Codenesium>*/