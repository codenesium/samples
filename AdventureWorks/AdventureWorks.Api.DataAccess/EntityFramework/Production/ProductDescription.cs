using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductDescription", Schema="Production")]
	public partial class ProductDescription: AbstractEntityFrameworkPOCO
	{
		public ProductDescription()
		{}

		public void SetProperties(
			int productDescriptionID,
			string description,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.Description = description.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		[Column("Description", TypeName="nvarchar(400)")]
		public string Description { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Key]
		[Column("ProductDescriptionID", TypeName="int")]
		public int ProductDescriptionID { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>a2258cf1c8da81fe4805f514a981e3d4</Hash>
</Codenesium>*/