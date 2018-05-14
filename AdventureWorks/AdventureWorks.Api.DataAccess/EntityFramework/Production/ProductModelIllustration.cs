using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelIllustration", Schema="Production")]
	public partial class ProductModelIllustration: AbstractEntityFrameworkPOCO
	{
		public ProductModelIllustration()
		{}

		public void SetProperties(
			int productModelID,
			int illustrationID,
			DateTime modifiedDate)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductModelID = productModelID.ToInt();
		}

		[Column("IllustrationID", TypeName="int")]
		public int IllustrationID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Key]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; set; }
	}
}

/*<Codenesium>
    <Hash>d2a47d42cf3929c40e0323f37834e111</Hash>
</Codenesium>*/