using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelIllustration", Schema="Production")]
	public partial class ProductModelIllustration: AbstractEntityFrameworkDTO
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
    <Hash>078b671bbbd2abf0209d7f29eea4121f</Hash>
</Codenesium>*/