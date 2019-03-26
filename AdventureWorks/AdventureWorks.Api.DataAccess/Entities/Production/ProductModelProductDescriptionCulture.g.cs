using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelProductDescriptionCulture", Schema="Production")]
	public partial class ProductModelProductDescriptionCulture : AbstractEntity
	{
		public ProductModelProductDescriptionCulture()
		{
		}

		public virtual void SetProperties(
			int productModelID,
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID)
		{
			this.ProductModelID = productModelID;
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate;
			this.ProductDescriptionID = productDescriptionID;
		}

		[Key]
		[MaxLength(6)]
		[Column("CultureID")]
		public virtual string CultureID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductDescriptionID")]
		public virtual int ProductDescriptionID { get; private set; }

		[Key]
		[Column("ProductModelID")]
		public virtual int ProductModelID { get; private set; }

		[ForeignKey("CultureID")]
		public virtual Culture CultureIDNavigation { get; private set; }

		public void SetCultureIDNavigation(Culture item)
		{
			this.CultureIDNavigation = item;
		}

		[ForeignKey("ProductDescriptionID")]
		public virtual ProductDescription ProductDescriptionIDNavigation { get; private set; }

		public void SetProductDescriptionIDNavigation(ProductDescription item)
		{
			this.ProductDescriptionIDNavigation = item;
		}

		[ForeignKey("ProductModelID")]
		public virtual ProductModel ProductModelIDNavigation { get; private set; }

		public void SetProductModelIDNavigation(ProductModel item)
		{
			this.ProductModelIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>8ca6ca26dd72470c95a37e012c885227</Hash>
</Codenesium>*/