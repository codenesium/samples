using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALTransactionHistoryMapper
	{
		void MapDTOToEF(
			int transactionID,
			DTOTransactionHistory dto,
			TransactionHistory efTransactionHistory);

		DTOTransactionHistory MapEFToDTO(
			TransactionHistory efTransactionHistory);
	}
}

/*<Codenesium>
    <Hash>d45b3159fa3302e23fb6251d31b60f6b</Hash>
</Codenesium>*/