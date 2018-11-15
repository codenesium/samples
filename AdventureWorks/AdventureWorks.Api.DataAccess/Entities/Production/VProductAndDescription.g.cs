using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vProductAndDescription", Schema="Production")]
	public partial class VProductAndDescription : AbstractEntity
	{
		public VProductAndDescription()
		{
		}

		public virtual void SetProperties(
			string cultureID,
			string description,
			string name,
			int productID,
			string productModel)
		{
			this.CultureID = cultureID;
			this.Description = description;
			this.Name = name;
			this.ProductID = productID;
			this.ProductModel = productModel;
		}

		[Key]
		[MaxLength(6)]
		[Column("CultureID")]
		public virtual string CultureID { get; private set; }

		[MaxLength(400)]
		[Column("Description")]
		public virtual string Description { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Key]
		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[MaxLength(50)]
		[Column("ProductModel")]
		public virtual string ProductModel { get; private set; }
	}
}

/*<Codenesium>
    <Hash>709a925cc45c89d3ee5d1e9d55469458</Hash>
</Codenesium>*/