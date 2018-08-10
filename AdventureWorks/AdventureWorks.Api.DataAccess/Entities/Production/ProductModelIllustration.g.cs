using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelIllustration", Schema="Production")]
	public partial class ProductModelIllustration : AbstractEntity
	{
		public ProductModelIllustration()
		{
		}

		public virtual void SetProperties(
			int illustrationID,
			DateTime modifiedDate,
			int productModelID)
		{
			this.IllustrationID = illustrationID;
			this.ModifiedDate = modifiedDate;
			this.ProductModelID = productModelID;
		}

		[Column("IllustrationID")]
		public int IllustrationID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductModelID")]
		public int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3cf7ad95560d4aef41450309954b7be5</Hash>
</Codenesium>*/