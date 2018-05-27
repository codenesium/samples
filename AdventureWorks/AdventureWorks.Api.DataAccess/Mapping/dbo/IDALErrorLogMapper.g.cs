using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALErrorLogMapper
	{
		void MapDTOToEF(
			int errorLogID,
			DTOErrorLog dto,
			ErrorLog efErrorLog);

		DTOErrorLog MapEFToDTO(
			ErrorLog efErrorLog);
	}
}

/*<Codenesium>
    <Hash>eb2b6f39e0d6d0cd22626fa2265ff82c</Hash>
</Codenesium>*/