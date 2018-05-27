using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALEmployeePayHistoryMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOEmployeePayHistory dto,
			EmployeePayHistory efEmployeePayHistory);

		DTOEmployeePayHistory MapEFToDTO(
			EmployeePayHistory efEmployeePayHistory);
	}
}

/*<Codenesium>
    <Hash>82fe5c82236c296f5e8cf5bed7957826</Hash>
</Codenesium>*/