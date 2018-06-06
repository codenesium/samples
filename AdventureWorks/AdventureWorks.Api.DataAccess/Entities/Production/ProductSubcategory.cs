using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductSubcategory", Schema="Production")]
	public partial class ProductSubcategory: AbstractEntity
	{
		public ProductSubcategory()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			string name,
			int productCategoryID,
			int productSubcategoryID,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductCategoryID = productCategoryID.ToInt();
			this.ProductSubcategoryID = productSubcategoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; private set; }

		[Column("ProductCategoryID", TypeName="int")]
		public int ProductCategoryID { get; private set; }

		[Key]
		[Column("ProductSubcategoryID", TypeName="int")]
		public int ProductSubcategoryID { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>633945472ea5738e4fa7c3772a615f75</Hash>
</Codenesium>*/