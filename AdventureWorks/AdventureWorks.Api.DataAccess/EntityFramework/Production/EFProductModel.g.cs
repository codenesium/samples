using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModel", Schema="Production")]
	public partial class EFProductModel: AbstractEntityFrameworkPOCO
	{
		public EFProductModel()
		{}

		public void SetProperties(
			int productModelID,
			string name,
			string catalogDescription,
			string instructions,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.ProductModelID = productModelID.ToInt();
			this.Name = name.ToString();
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("CatalogDescription", TypeName="xml(-1)")]
		public string CatalogDescription { get; set; }

		[Column("Instructions", TypeName="xml(-1)")]
		public string Instructions { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>bb64dfbb86c865667d1960a62e8f1c61</Hash>
</Codenesium>*/