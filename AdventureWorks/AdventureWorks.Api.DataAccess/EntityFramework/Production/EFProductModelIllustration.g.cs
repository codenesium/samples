using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelIllustration", Schema="Production")]
	public partial class EFProductModelIllustration: AbstractEntityFrameworkPOCO
	{
		public EFProductModelIllustration()
		{}

		public void SetProperties(
			int productModelID,
			int illustrationID,
			DateTime modifiedDate)
		{
			this.ProductModelID = productModelID.ToInt();
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; set; }

		[Column("IllustrationID", TypeName="int")]
		public int IllustrationID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductModelID")]
		public virtual EFProductModel ProductModel { get; set; }

		[ForeignKey("IllustrationID")]
		public virtual EFIllustration Illustration { get; set; }
	}
}

/*<Codenesium>
    <Hash>02ad524b2560088efad688e2c55af2b5</Hash>
</Codenesium>*/