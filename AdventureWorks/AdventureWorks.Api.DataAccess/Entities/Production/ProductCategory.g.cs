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
			DateTime modifiedDate,
			string name,
			int productCategoryID,
			Guid rowguid)
		{
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

		[Key]
		[Column("ProductCategoryID")]
		public virtual int ProductCategoryID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3f0f8dd6a8c4d8c2d293cd87f7174220</Hash>
</Codenesium>*/