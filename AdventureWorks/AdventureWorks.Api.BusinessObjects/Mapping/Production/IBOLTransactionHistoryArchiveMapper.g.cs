using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLTransactionHistoryArchiveMapper
	{
		DTOTransactionHistoryArchive MapModelToDTO(
			int transactionID,
			ApiTransactionHistoryArchiveRequestModel model);

		ApiTransactionHistoryArchiveResponseModel MapDTOToModel(
			DTOTransactionHistoryArchive dtoTransactionHistoryArchive);

		List<ApiTransactionHistoryArchiveResponseModel> MapDTOToModel(
			List<DTOTransactionHistoryArchive> dtos);
	}
}

/*<Codenesium>
    <Hash>c9a7f7078b9b98bbe10ff2ee615ef1e6</Hash>
</Codenesium>*/