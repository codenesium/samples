using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALPersonMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOPerson dto,
			Person efPerson);

		DTOPerson MapEFToDTO(
			Person efPerson);
	}
}

/*<Codenesium>
    <Hash>1697b7532d5dfa4fa0430fe0c8e6a062</Hash>
</Codenesium>*/