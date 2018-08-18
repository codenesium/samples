using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractTransactionHistoryArchiveMapper
	{
		public virtual TransactionHistoryArchive MapBOToEF(
			BOTransactionHistoryArchive bo)
		{
			TransactionHistoryArchive efTransactionHistoryArchive = new TransactionHistoryArchive();
			efTransactionHistoryArchive.SetProperties(
				bo.ActualCost,
				bo.ModifiedDate,
				bo.ProductID,
				bo.Quantity,
				bo.ReferenceOrderID,
				bo.ReferenceOrderLineID,
				bo.TransactionDate,
				bo.TransactionID,
				bo.TransactionType);
			return efTransactionHistoryArchive;
		}

		public virtual BOTransactionHistoryArchive MapEFToBO(
			TransactionHistoryArchive ef)
		{
			var bo = new BOTransactionHistoryArchive();

			bo.SetProperties(
				ef.TransactionID,
				ef.ActualCost,
				ef.ModifiedDate,
				ef.ProductID,
				ef.Quantity,
				ef.ReferenceOrderID,
				ef.ReferenceOrderLineID,
				ef.TransactionDate,
				ef.TransactionType);
			return bo;
		}

		public virtual List<BOTransactionHistoryArchive> MapEFToBO(
			List<TransactionHistoryArchive> records)
		{
			List<BOTransactionHistoryArchive> response = new List<BOTransactionHistoryArchive>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>25f442ce2d8c0b6749ced80299b5a189</Hash>
</Codenesium>*/