using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALDatabaseLogMapper
	{
		void MapDTOToEF(
			int databaseLogID,
			DTODatabaseLog dto,
			DatabaseLog efDatabaseLog);

		DTODatabaseLog MapEFToDTO(
			DatabaseLog efDatabaseLog);
	}
}

/*<Codenesium>
    <Hash>f9fed8fdf7c28f8fe522a84cb3c45038</Hash>
</Codenesium>*/