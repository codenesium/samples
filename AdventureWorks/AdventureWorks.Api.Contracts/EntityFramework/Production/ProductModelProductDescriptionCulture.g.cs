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
		public int ProductModelID {get; set;}
		public int ProductDescriptionID {get; set;}
		public string CultureID {get; set;}
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
    <Hash>a6c2cc4922a9f39be05b5cb3fb9a69e8</Hash>
</Codenesium>*/