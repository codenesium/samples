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
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID)
		{
			this.CultureID = cultureID.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.ProductModelID = productModelID.ToInt();
		}

		[Column("CultureID", TypeName="nchar(6)")]
		public string CultureID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("ProductDescriptionID", TypeName="int")]
		public int ProductDescriptionID { get; set; }

		[Key]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; set; }

		[ForeignKey("CultureID")]
		public virtual EFCulture Culture { get; set; }

		[ForeignKey("ProductDescriptionID")]
		public virtual EFProductDescription ProductDescription { get; set; }

		[ForeignKey("ProductModelID")]
		public virtual EFProductModel ProductModel { get; set; }
	}
}

/*<Codenesium>
    <Hash>a4286961b09968d201354dd9ce8fca0e</Hash>
</Codenesium>*/