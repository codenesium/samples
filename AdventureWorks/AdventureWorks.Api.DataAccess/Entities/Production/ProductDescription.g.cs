using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductDescription", Schema="Production")]
	public partial class ProductDescription : AbstractEntity
	{
		public ProductDescription()
		{
		}

		public virtual void SetProperties(
			int productDescriptionID,
			string description,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.ProductDescriptionID = productDescriptionID;
			this.Description = description;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[MaxLength(400)]
		[Column("Description")]
		public virtual string Description { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductDescriptionID")]
		public virtual int ProductDescriptionID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f01a68602486bd477385df2c9a3f1cd8</Hash>
</Codenesium>*/