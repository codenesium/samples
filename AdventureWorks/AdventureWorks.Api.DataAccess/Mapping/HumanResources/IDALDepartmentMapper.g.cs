using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALDepartmentMapper
	{
		void MapDTOToEF(
			short departmentID,
			DTODepartment dto,
			Department efDepartment);

		DTODepartment MapEFToDTO(
			Department efDepartment);
	}
}

/*<Codenesium>
    <Hash>268ff22abd5aa8774ca674a0cabef5ca</Hash>
</Codenesium>*/