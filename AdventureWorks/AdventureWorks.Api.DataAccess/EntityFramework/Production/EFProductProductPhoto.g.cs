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

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }

		[ForeignKey("ProductPhotoID")]
		public virtual EFProductPhoto ProductPhoto { get; set; }
	}
}

/*<Codenesium>
    <Hash>899c097645fadbf9eab32e6fbc8f6cff</Hash>
</Codenesium>*/