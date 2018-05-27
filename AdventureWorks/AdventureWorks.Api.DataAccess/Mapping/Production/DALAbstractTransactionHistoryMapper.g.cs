using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALTransactionHistoryMapper
	{
		public virtual void MapDTOToEF(
			int transactionID,
			DTOTransactionHistory dto,
			TransactionHistory efTransactionHistory)
		{
			efTransactionHistory.SetProperties(
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

		public virtual DTOTransactionHistory MapEFToDTO(
			TransactionHistory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOTransactionHistory();

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
    <Hash>153743bb9ec4e5a5e37214913f198074</Hash>
</Codenesium>*/