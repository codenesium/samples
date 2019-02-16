using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Sale", Schema="dbo")]
	public partial class Sale : AbstractEntity
	{
		public Sale()
		{
		}

		public virtual void SetProperties(
			int id,
			decimal amount,
			int cutomerId,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Id = id;
			this.Amount = amount;
			this.CutomerId = cutomerId;
			this.Note = note;
			this.PetId = petId;
			this.SaleDate = saleDate;
			this.SalesPersonId = salesPersonId;
		}

		[Column("amount")]
		public virtual decimal Amount { get; private set; }

		[Column("cutomerId")]
		public virtual int CutomerId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(2147483647)]
		[Column("note")]
		public virtual string Note { get; private set; }

		[Column("petId")]
		public virtual int PetId { get; private set; }

		[Column("saleDate")]
		public virtual DateTime SaleDate { get; private set; }

		[Column("salesPersonId")]
		public virtual int SalesPersonId { get; private set; }

		[ForeignKey("PetId")]
		public virtual Pet PetIdNavigation { get; private set; }

		public void SetPetIdNavigation(Pet item)
		{
			this.PetIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>c61f9335e819777a218d66625a5e2fd4</Hash>
</Codenesium>*/