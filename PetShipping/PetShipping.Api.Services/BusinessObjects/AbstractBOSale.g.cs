using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOSale : AbstractBusinessObject
	{
		public AbstractBOSale()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  decimal amount,
		                                  int cutomerId,
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

		public decimal Amount { get; private set; }

		public int CutomerId { get; private set; }

		public int Id { get; private set; }

		public string Note { get; private set; }

		public int PetId { get; private set; }

		public DateTime SaleDate { get; private set; }

		public int SalesPersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>97577803fb7dd01718a2e249282ad9ab</Hash>
</Codenesium>*/