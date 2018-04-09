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

		public virtual EFProductModel ProductModel { get; set; }

		public virtual EFProductDescription ProductDescription { get; set; }

		public virtual EFCulture Culture { get; set; }
	}
}

/*<Codenesium>
    <Hash>90eb52b8bc95aa735ac2e15a696960c7</Hash>
</Codenesium>*/