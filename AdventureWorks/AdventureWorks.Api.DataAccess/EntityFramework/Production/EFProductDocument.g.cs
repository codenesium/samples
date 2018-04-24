using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductDocument", Schema="Production")]
	public partial class EFProductDocument: AbstractEntityFrameworkPOCO
	{
		public EFProductDocument()
		{}

		public void SetProperties(
			int productID,
			Guid documentNode,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.DocumentNode = documentNode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("DocumentNode", TypeName="hierarchyid(892)")]
		public Guid DocumentNode { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }

		[ForeignKey("DocumentNode")]
		public virtual EFDocument Document { get; set; }
	}
}

/*<Codenesium>
    <Hash>0046690432808e60037f099723aa473e</Hash>
</Codenesium>*/