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
		public DateTime ModifiedDate { get; private set; }

		[Column("ProductID")]
		public int ProductID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f918ecba34e5025cf36067296ab71786</Hash>
</Codenesium>*/