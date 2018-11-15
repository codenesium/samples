using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractTransactionMapper
	{
		public virtual Transaction MapBOToEF(
			BOTransaction bo)
		{
			Transaction efTransaction = new Transaction();
			efTransaction.SetProperties(
				bo.Amount,
				bo.GatewayConfirmationNumber,
				bo.Id,
				bo.TransactionStatusId);
			return efTransaction;
		}

		public virtual BOTransaction MapEFToBO(
			Transaction ef)
		{
			var bo = new BOTransaction();

			bo.SetProperties(
				ef.Id,
				ef.Amount,
				ef.GatewayConfirmationNumber,
				ef.TransactionStatusId);
			return bo;
		}

		public virtual List<BOTransaction> MapEFToBO(
			List<Transaction> records)
		{
			List<BOTransaction> response = new List<BOTransaction>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>51e25ab867e627c56405fcc4a71de5aa</Hash>
</Codenesium>*/