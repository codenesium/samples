using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALBusinessEntityMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOBusinessEntity dto,
			BusinessEntity efBusinessEntity);

		DTOBusinessEntity MapEFToDTO(
			BusinessEntity efBusinessEntity);
	}
}

/*<Codenesium>
    <Hash>751cfcbba4f4d65141e222647861f859</Hash>
</Codenesium>*/