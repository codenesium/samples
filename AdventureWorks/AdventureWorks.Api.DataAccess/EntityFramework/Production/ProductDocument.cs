using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductDocument", Schema="Production")]
	public partial class ProductDocument: AbstractEntityFrameworkPOCO
	{
		public ProductDocument()
		{}

		public void SetProperties(
			int productID,
			Guid documentNode,
			DateTime modifiedDate)
		{
			this.DocumentNode = documentNode.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
		}

		[Column("DocumentNode", TypeName="hierarchyid(892)")]
		public Guid DocumentNode { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }
	}
}

/*<Codenesium>
    <Hash>d3f6634fe997975361662dff4796051a</Hash>
</Codenesium>*/