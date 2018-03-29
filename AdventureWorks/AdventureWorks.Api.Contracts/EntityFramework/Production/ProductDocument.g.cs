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
		public int ProductID {get; set;}
		public Guid DocumentNode {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
		[ForeignKey("DocumentNode")]
		public virtual EFDocument DocumentRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>af7e1e8e5740f4406af72d8c372efbea</Hash>
</Codenesium>*/