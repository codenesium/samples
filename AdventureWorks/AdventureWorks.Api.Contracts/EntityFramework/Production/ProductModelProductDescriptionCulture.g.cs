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
		public int productModelID {get; set;}
		public int productDescriptionID {get; set;}
		public string cultureID {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>dfd1345416e709730fe919c0d0cc373e</Hash>
</Codenesium>*/