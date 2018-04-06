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
		public virtual EFProductModel ProductModelRef { get; set; }
		[ForeignKey("ProductDescriptionID")]
		public virtual EFProductDescription ProductDescriptionRef { get; set; }
		[ForeignKey("CultureID")]
		public virtual EFCulture CultureRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>cfc27c7b14f3b2cc7e8290c7d9aaec34</Hash>
</Codenesium>*/