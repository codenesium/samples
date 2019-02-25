using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductSubcategory", Schema="Production")]
	public partial class ProductSubcategory : AbstractEntity
	{
		public ProductSubcategory()
		{
		}

		public virtual void SetProperties(
			int productSubcategoryID,
			DateTime modifiedDate,
			string name,
			int productCategoryID,
			Guid rowguid)
		{
			this.ProductSubcategoryID = productSubcategoryID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ProductCategoryID = productCategoryID;
			this.Rowguid = rowguid;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("ProductCategoryID")]
		public virtual int ProductCategoryID { get; private set; }

		[Key]
		[Column("ProductSubcategoryID")]
		public virtual int ProductSubcategoryID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[ForeignKey("ProductCategoryID")]
		public virtual ProductCategory ProductCategoryIDNavigation { get; private set; }

		public void SetProductCategoryIDNavigation(ProductCategory item)
		{
			this.ProductCategoryIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>4cf5701d754c32f702f0fd1f634ea0d1</Hash>
</Codenesium>*/