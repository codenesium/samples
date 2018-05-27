using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALTransactionHistoryArchiveMapper
	{
		void MapDTOToEF(
			int transactionID,
			DTOTransactionHistoryArchive dto,
			TransactionHistoryArchive efTransactionHistoryArchive);

		DTOTransactionHistoryArchive MapEFToDTO(
			TransactionHistoryArchive efTransactionHistoryArchive);
	}
}

/*<Codenesium>
    <Hash>febee2479dd884ce493739dcfb86a936</Hash>
</Codenesium>*/