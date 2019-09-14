using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PointOfSaleNS.Api.DataAccess
{
	[Table("SaleProduct", Schema="dbo")]
	public partial class SaleProduct : AbstractEntity
	{
		public SaleProduct()
		{
		}

		public virtual void SetProperties(
			int productId,
			int saleId)
		{
			this.ProductId = productId;
			this.SaleId = saleId;
		}

		[Key]
		[Column("productId")]
		public virtual int ProductId { get; private set; }

		[Key]
		[Column("saleId")]
		public virtual int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>144449d1279b0e95063a7e58a2944eab</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/