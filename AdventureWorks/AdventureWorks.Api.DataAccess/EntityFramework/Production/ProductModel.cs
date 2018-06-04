using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModel", Schema="Production")]
	public partial class ProductModel: AbstractEntity
	{
		public ProductModel()
		{}

		public void SetProperties(
			string catalogDescription,
			string instructions,
			DateTime modifiedDate,
			string name,
			int productModelID,
			Guid rowguid)
		{
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductModelID = productModelID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		[Column("CatalogDescription", TypeName="xml(-1)")]
		public string CatalogDescription { get; private set; }

		[Column("Instructions", TypeName="xml(-1)")]
		public string Instructions { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; private set; }

		[Key]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1efe6e128405a14401a1d9ad680a1fa4</Hash>
</Codenesium>*/