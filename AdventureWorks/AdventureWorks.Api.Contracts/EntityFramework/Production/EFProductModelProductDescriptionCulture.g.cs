using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductModelProductDescriptionCulture", Schema="Production")]
	public partial class EFProductModelProductDescriptionCulture
	{
		public EFProductModelProductDescriptionCulture()
		{}

		public void SetProperties(int productModelID,
		                          int productDescriptionID,
		                          string cultureID,
		                          DateTime modifiedDate)
		{
			this.ProductModelID = productModelID.ToInt();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID {get; set;}

		[Column("ProductDescriptionID", TypeName="int")]
		public int ProductDescriptionID {get; set;}

		[Column("CultureID", TypeName="nchar(6)")]
		public string CultureID {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFProductModel ProductModel { get; set; }

		public virtual EFProductDescription ProductDescription { get; set; }

		public virtual EFCulture Culture { get; set; }
	}
}

/*<Codenesium>
    <Hash>567d70d0cd79bff36879ee0bcb9b0e15</Hash>
</Codenesium>*/