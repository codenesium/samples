using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALShiftMapper
	{
		void MapDTOToEF(
			int shiftID,
			DTOShift dto,
			Shift efShift);

		DTOShift MapEFToDTO(
			Shift efShift);
	}
}

/*<Codenesium>
    <Hash>b93b7b908cb154e19b64c52f6af0aff2</Hash>
</Codenesium>*/