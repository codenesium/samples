using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALStudentMapper
	{
		void MapDTOToEF(
			int id,
			DTOStudent dto,
			Student efStudent);

		DTOStudent MapEFToDTO(
			Student efStudent);
	}
}

/*<Codenesium>
    <Hash>56cd34962295cdff60a4dcc3deae8cd2</Hash>
</Codenesium>*/