using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALChainStatusMapper
	{
		void MapDTOToEF(
			int id,
			DTOChainStatus dto,
			ChainStatus efChainStatus);

		DTOChainStatus MapEFToDTO(
			ChainStatus efChainStatus);
	}
}

/*<Codenesium>
    <Hash>1735feae429be04bc0bed9b1159b2318</Hash>
</Codenesium>*/