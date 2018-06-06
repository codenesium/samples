using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductDocument", Schema="Production")]
	public partial class ProductDocument: AbstractEntity
	{
		public ProductDocument()
		{}

		public void SetProperties(
			Guid documentNode,
			DateTime modifiedDate,
			int productID)
		{
			this.DocumentNode = documentNode.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
		}

		[Column("DocumentNode", TypeName="hierarchyid(892)")]
		public Guid DocumentNode { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>920d36cf25348e380b0f08545a42bb5e</Hash>
</Codenesium>*/