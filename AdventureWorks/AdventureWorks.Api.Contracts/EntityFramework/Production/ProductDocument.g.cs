using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductDocument", Schema="Production")]
	public partial class EFProductDocument
	{
		public EFProductDocument()
		{}

		[Key]
		public int productID {get; set;}
		public Guid documentNode {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>58c10b01b1c85907d5430842d0e5fb24</Hash>
</Codenesium>*/