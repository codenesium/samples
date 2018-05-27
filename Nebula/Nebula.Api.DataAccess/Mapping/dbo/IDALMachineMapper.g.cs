using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALMachineMapper
	{
		void MapDTOToEF(
			int id,
			DTOMachine dto,
			Machine efMachine);

		DTOMachine MapEFToDTO(
			Machine efMachine);
	}
}

/*<Codenesium>
    <Hash>a30fa55c32f5c1eb5bd6f692df4f3edf</Hash>
</Codenesium>*/