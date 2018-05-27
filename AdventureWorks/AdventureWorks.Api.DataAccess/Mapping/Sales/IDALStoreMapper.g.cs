using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALStoreMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOStore dto,
			Store efStore);

		DTOStore MapEFToDTO(
			Store efStore);
	}
}

/*<Codenesium>
    <Hash>9badd4239b70ebea66a9adb535c6a660</Hash>
</Codenesium>*/