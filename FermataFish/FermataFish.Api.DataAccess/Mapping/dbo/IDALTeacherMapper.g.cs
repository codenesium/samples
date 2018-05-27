using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALTeacherMapper
	{
		void MapDTOToEF(
			int id,
			DTOTeacher dto,
			Teacher efTeacher);

		DTOTeacher MapEFToDTO(
			Teacher efTeacher);
	}
}

/*<Codenesium>
    <Hash>49733c836aced5e541e2009d9baa91bb</Hash>
</Codenesium>*/