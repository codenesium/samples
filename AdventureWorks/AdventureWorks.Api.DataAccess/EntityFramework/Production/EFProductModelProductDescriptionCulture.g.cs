using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelProductDescriptionCulture", Schema="Production")]
	public partial class EFProductModelProductDescriptionCulture: AbstractEntityFrameworkPOCO
	{
		public EFProductModelProductDescriptionCulture()
		{}

		public void SetProperties(
			int productModelID,
			int productDescriptionID,
			string cultureID,
			DateTime modifiedDate)
		{
			this.ProductModelID = productModelID.ToInt();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.CultureID = cultureID.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; set; }

		[Column("ProductDescriptionID", TypeName="int")]
		public int ProductDescriptionID { get; set; }

		[Column("CultureID", TypeName="nchar(6)")]
		public string CultureID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductModelID")]
		public virtual EFProductModel ProductModel { get; set; }

		[ForeignKey("ProductDescriptionID")]
		public virtual EFProductDescription ProductDescription { get; set; }

		[ForeignKey("CultureID")]
		public virtual EFCulture Culture { get; set; }
	}
}

/*<Codenesium>
    <Hash>280ef4ba6b498622b87ebbd10cd7bbe5</Hash>
</Codenesium>*/