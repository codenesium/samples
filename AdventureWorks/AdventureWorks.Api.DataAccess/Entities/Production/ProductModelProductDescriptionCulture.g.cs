using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelProductDescriptionCulture", Schema="Production")]
	public partial class ProductModelProductDescriptionCulture : AbstractEntity
	{
		public ProductModelProductDescriptionCulture()
		{
		}

		public virtual void SetProperties(
			string cultureID,
			DateTime modifiedDate,
			int productDescriptionID,
			int productModelID)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate;
			this.ProductDescriptionID = productDescriptionID;
			this.ProductModelID = productModelID;
		}

		[Key]
		[MaxLength(6)]
		[Column("CultureID")]
		public virtual string CultureID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductDescriptionID")]
		public virtual int ProductDescriptionID { get; private set; }

		[Key]
		[Column("ProductModelID")]
		public virtual int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5f7a9904ca3a576dbf9521740ca51da4</Hash>
</Codenesium>*/