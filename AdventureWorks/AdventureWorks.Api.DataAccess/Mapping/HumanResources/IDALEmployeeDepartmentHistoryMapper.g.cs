using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALEmployeeDepartmentHistoryMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOEmployeeDepartmentHistory dto,
			EmployeeDepartmentHistory efEmployeeDepartmentHistory);

		DTOEmployeeDepartmentHistory MapEFToDTO(
			EmployeeDepartmentHistory efEmployeeDepartmentHistory);
	}
}

/*<Codenesium>
    <Hash>fce14853922d1ce6dafa7c4412f2a860</Hash>
</Codenesium>*/