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
			decimal amount,
			int cutomerId,
			int id,
			string note,
			int petId,
			DateTime saleDate,
			int salesPersonId)
		{
			this.Amount = amount;
			this.CutomerId = cutomerId;
			this.Id = id;
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
		public virtual Pet PetNavigation { get; private set; }

		public void SetPetNavigation(Pet item)
		{
			this.PetNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>439eab2660382a55942216fc5715bb4d</Hash>
</Codenesium>*/