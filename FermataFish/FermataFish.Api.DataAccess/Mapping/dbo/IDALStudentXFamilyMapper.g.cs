using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALStudentXFamilyMapper
	{
		void MapDTOToEF(
			int id,
			DTOStudentXFamily dto,
			StudentXFamily efStudentXFamily);

		DTOStudentXFamily MapEFToDTO(
			StudentXFamily efStudentXFamily);
	}
}

/*<Codenesium>
    <Hash>f8bdfb9acf798956fc2d9d1cec0a0225</Hash>
</Codenesium>*/