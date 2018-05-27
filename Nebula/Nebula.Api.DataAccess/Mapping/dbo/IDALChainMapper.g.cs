using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALChainMapper
	{
		void MapDTOToEF(
			int id,
			DTOChain dto,
			Chain efChain);

		DTOChain MapEFToDTO(
			Chain efChain);
	}
}

/*<Codenesium>
    <Hash>2b01114857878978626684ab3579448d</Hash>
</Codenesium>*/