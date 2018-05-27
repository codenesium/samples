using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductDocument", Schema="Production")]
	public partial class ProductDocument: AbstractEntityFrameworkDTO
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

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
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
    <Hash>8c730ba51e08be33a899e62ba168b328</Hash>
</Codenesium>*/