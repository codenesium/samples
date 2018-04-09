using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductDocument", Schema="Production")]
	public partial class EFProductDocument
	{
		public EFProductDocument()
		{}

		public void SetProperties(int productID,
		                          Guid documentNode,
		                          DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.DocumentNode = documentNode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("DocumentNode", TypeName="hierarchyid(892)")]
		public Guid DocumentNode {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFProduct Product { get; set; }

		public virtual EFDocument Document { get; set; }
	}
}

/*<Codenesium>
    <Hash>0ee187b187b28c3c9bd425263fd91c4f</Hash>
</Codenesium>*/