using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractBOSale : AbstractBusinessObject
	{
		public AbstractBOSale()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string ipAddress,
		                                  string note,
		                                  DateTime saleDate,
		                                  int transactionId)
		{
			this.Id = id;
			this.IpAddress = ipAddress;
			this.Note = note;
			this.SaleDate = saleDate;
			this.TransactionId = transactionId;
		}

		public int Id { get; private set; }

		public string IpAddress { get; private set; }

		public string Note { get; private set; }

		public DateTime SaleDate { get; private set; }

		public int TransactionId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ef36ff39ba40d5b6103fde636c0b83a3</Hash>
</Codenesium>*/