using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModel", Schema="Production")]
	public partial class ProductModel : AbstractEntity
	{
		public ProductModel()
		{
		}

		public virtual void SetProperties(
			string catalogDescription,
			string instruction,
			DateTime modifiedDate,
			string name,
			int productModelID,
			Guid rowguid)
		{
			this.CatalogDescription = catalogDescription;
			this.Instruction = instruction;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ProductModelID = productModelID;
			this.Rowguid = rowguid;
		}

		[Column("CatalogDescription")]
		public virtual string CatalogDescription { get; private set; }

		[Column("Instructions")]
		public virtual string Instruction { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Key]
		[Column("ProductModelID")]
		public virtual int ProductModelID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1a438a53e767b220b074598e4801bce0</Hash>
</Codenesium>*/