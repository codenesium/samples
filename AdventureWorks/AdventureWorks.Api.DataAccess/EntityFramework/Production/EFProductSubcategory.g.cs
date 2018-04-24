using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductSubcategory", Schema="Production")]
	public partial class EFProductSubcategory: AbstractEntityFrameworkPOCO
	{
		public EFProductSubcategory()
		{}

		public void SetProperties(
			int productSubcategoryID,
			int productCategoryID,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.ProductSubcategoryID = productSubcategoryID.ToInt();
			this.ProductCategoryID = productCategoryID.ToInt();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductSubcategoryID", TypeName="int")]
		public int ProductSubcategoryID { get; set; }

		[Column("ProductCategoryID", TypeName="int")]
		public int ProductCategoryID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductCategoryID")]
		public virtual EFProductCategory ProductCategory { get; set; }
	}
}

/*<Codenesium>
    <Hash>48025bd806a0a336448e02fd4a5d78d5</Hash>
</Codenesium>*/