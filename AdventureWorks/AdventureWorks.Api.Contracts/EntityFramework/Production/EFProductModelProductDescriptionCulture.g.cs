using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductModelProductDescriptionCulture", Schema="Production")]
	public partial class EFProductModelProductDescriptionCulture
	{
		public EFProductModelProductDescriptionCulture()
		{}

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

		[ForeignKey("ProductModelID")]
		public virtual EFProductModel ProductModel { get; set; }
		[ForeignKey("ProductDescriptionID")]
		public virtual EFProductDescription ProductDescription { get; set; }
		[ForeignKey("CultureID")]
		public virtual EFCulture Culture { get; set; }
	}
}

/*<Codenesium>
    <Hash>a9e9d2de00a6f14ae5acb4613735b892</Hash>
</Codenesium>*/