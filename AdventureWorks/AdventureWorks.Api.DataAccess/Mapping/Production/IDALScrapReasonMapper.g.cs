using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALScrapReasonMapper
	{
		void MapDTOToEF(
			short scrapReasonID,
			DTOScrapReason dto,
			ScrapReason efScrapReason);

		DTOScrapReason MapEFToDTO(
			ScrapReason efScrapReason);
	}
}

/*<Codenesium>
    <Hash>0cbec6169295fb79eea5fa3971394797</Hash>
</Codenesium>*/