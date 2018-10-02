using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
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
    <Hash>3a71c25710c6a2dfe4c182075095f673</Hash>
</Codenesium>*/