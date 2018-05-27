using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALEmployeeMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOEmployee dto,
			Employee efEmployee);

		DTOEmployee MapEFToDTO(
			Employee efEmployee);
	}
}

/*<Codenesium>
    <Hash>31912b72da1b1ea784c37b5b883c57ca</Hash>
</Codenesium>*/