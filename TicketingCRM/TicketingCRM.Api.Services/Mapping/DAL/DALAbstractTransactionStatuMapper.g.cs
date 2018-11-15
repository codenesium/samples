using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractTransactionStatuMapper
	{
		public virtual TransactionStatu MapBOToEF(
			BOTransactionStatu bo)
		{
			TransactionStatu efTransactionStatu = new TransactionStatu();
			efTransactionStatu.SetProperties(
				bo.Id,
				bo.Name);
			return efTransactionStatu;
		}

		public virtual BOTransactionStatu MapEFToBO(
			TransactionStatu ef)
		{
			var bo = new BOTransactionStatu();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOTransactionStatu> MapEFToBO(
			List<TransactionStatu> records)
		{
			List<BOTransactionStatu> response = new List<BOTransactionStatu>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>13be56721ab6a2c5d8b87a79ffffdf1f</Hash>
</Codenesium>*/