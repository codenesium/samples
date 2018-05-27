using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelProductDescriptionCulture", Schema="Production")]
	public partial class ProductModelProductDescriptionCulture: AbstractEntityFrameworkDTO
	{
		public ProductModelProductDescriptionCulture()
		{}

		public void SetProperties(
			int productModelID,
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.ProductModelID = productModelID.ToInt();
		}

		[Column("CultureID", TypeName="nchar(6)")]
		public string CultureID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("ProductDescriptionID", TypeName="int")]
		public int ProductDescriptionID { get; set; }

		[Key]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; set; }
	}
}

/*<Codenesium>
    <Hash>63efd42ed7d9171fe50aad9e0711fe1d</Hash>
</Codenesium>*/