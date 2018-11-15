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
	}
}

/*<Codenesium>
    <Hash>51e924fe6777170fc35bc8c3791c180e</Hash>
</Codenesium>*/