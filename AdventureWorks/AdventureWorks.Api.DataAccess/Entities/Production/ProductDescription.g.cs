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
			string description,
			DateTime modifiedDate,
			int productDescriptionID,
			Guid rowguid)
		{
			this.Description = description;
			this.ModifiedDate = modifiedDate;
			this.ProductDescriptionID = productDescriptionID;
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
    <Hash>ec427000bc5047a2daf388d0d41d4664</Hash>
</Codenesium>*/