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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("DocumentNode", TypeName="hierarchyid(892)")]
		public Guid DocumentNode {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
		[ForeignKey("DocumentNode")]
		public virtual EFDocument Document { get; set; }
	}
}

/*<Codenesium>
    <Hash>a302bfc6d2bdb1c3fdda3a08d24fb324</Hash>
</Codenesium>*/