using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductDocument", Schema="Production")]
	public partial class ProductDocument : AbstractEntity
	{
		public ProductDocument()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			int productID)
		{
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[ForeignKey("ProductID")]
		public virtual Product ProductIDNavigation { get; private set; }

		public void SetProductIDNavigation(Product item)
		{
			this.ProductIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>caf5980e0f4cb3e066dc29e68b6aa3c1</Hash>
</Codenesium>*/