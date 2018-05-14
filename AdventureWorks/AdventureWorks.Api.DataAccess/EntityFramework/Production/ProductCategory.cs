using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductCategory", Schema="Production")]
	public partial class ProductCategory: AbstractEntityFrameworkPOCO
	{
		public ProductCategory()
		{}

		public void SetProperties(
			int productCategoryID,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ProductCategoryID = productCategoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Key]
		[Column("ProductCategoryID", TypeName="int")]
		public int ProductCategoryID { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>6875bbdde11f2254c80847746eeadaa2</Hash>
</Codenesium>*/