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

		[Key]
		[Column("IllustrationID")]
		public virtual int IllustrationID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductModelID")]
		public virtual int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1fa3e8e0744cb1d6e3e327de3db3a276</Hash>
</Codenesium>*/