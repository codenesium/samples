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
		public virtual EFProduct ProductRef { get; set; }
		[ForeignKey("DocumentNode")]
		public virtual EFDocument DocumentRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>2037fbb096c26bd0cb6e955f474d53cb</Hash>
</Codenesium>*/