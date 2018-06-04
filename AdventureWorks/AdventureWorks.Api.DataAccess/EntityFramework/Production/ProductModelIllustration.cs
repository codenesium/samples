using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelIllustration", Schema="Production")]
	public partial class ProductModelIllustration: AbstractEntity
	{
		public ProductModelIllustration()
		{}

		public void SetProperties(
			int illustrationID,
			DateTime modifiedDate,
			int productModelID)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductModelID = productModelID.ToInt();
		}

		[Column("IllustrationID", TypeName="int")]
		public int IllustrationID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9252f5a306968bb588d8d8ca125626e6</Hash>
</Codenesium>*/