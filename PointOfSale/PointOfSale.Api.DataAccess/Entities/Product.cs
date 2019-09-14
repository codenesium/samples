using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PointOfSaleNS.Api.DataAccess
{
	[Table("Product", Schema="dbo")]
	public partial class Product : AbstractEntity
	{
		public Product()
		{
		}

		public virtual void SetProperties(
			int id,
			bool active,
			string description,
			string name,
			decimal price,
			int quantity)
		{
			this.Id = id;
			this.Active = active;
			this.Description = description;
			this.Name = name;
			this.Price = price;
			this.Quantity = quantity;
		}

		[Column("active")]
		public virtual bool Active { get; private set; }

		[MaxLength(4096)]
		[Column("description")]
		public virtual string Description { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("price")]
		public virtual decimal Price { get; private set; }

		[Column("quantity")]
		public virtual int Quantity { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c245c353ea45af073a0b0f754e76f96c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/