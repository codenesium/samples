using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALTransactionHistoryArchiveMapper
	{
		public virtual void MapDTOToEF(
			int transactionID,
			DTOTransactionHistoryArchive dto,
			TransactionHistoryArchive efTransactionHistoryArchive)
		{
			efTransactionHistoryArchive.SetProperties(
				transactionID,
				dto.ActualCost,
				dto.ModifiedDate,
				dto.ProductID,
				dto.Quantity,
				dto.ReferenceOrderID,
				dto.ReferenceOrderLineID,
				dto.TransactionDate,
				dto.TransactionType);
		}

		public virtual DTOTransactionHistoryArchive MapEFToDTO(
			TransactionHistoryArchive ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOTransactionHistoryArchive();

			dto.SetProperties(
				ef.TransactionID,
				ef.ActualCost,
				ef.ModifiedDate,
				ef.ProductID,
				ef.Quantity,
				ef.ReferenceOrderID,
				ef.ReferenceOrderLineID,
				ef.TransactionDate,
				ef.TransactionType);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>aa71aa8b6a1ff9371d2e9126cd4c79d4</Hash>
</Codenesium>*/