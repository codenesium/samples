using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelProductDescriptionCulture", Schema="Production")]
	public partial class ProductModelProductDescriptionCulture: AbstractEntity
	{
		public ProductModelProductDescriptionCulture()
		{}

		public void SetProperties(
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID,
			int productModelID)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.ProductModelID = productModelID.ToInt();
		}

		[Column("CultureID", TypeName="nchar(6)")]
		public string CultureID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("ProductDescriptionID", TypeName="int")]
		public int ProductDescriptionID { get; private set; }

		[Key]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4e387752e1553e5c0f1e6edb9d49038a</Hash>
</Codenesium>*/