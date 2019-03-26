using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductCategory", Schema="Production")]
	public partial class ProductCategory : AbstractEntity
	{
		public ProductCategory()
		{
		}

		public virtual void SetProperties(
			int productCategoryID,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.ProductCategoryID = productCategoryID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Key]
		[Column("ProductCategoryID")]
		public virtual int ProductCategoryID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>aee10acca0aafedae5beb7427e6de8ad</Hash>
</Codenesium>*/