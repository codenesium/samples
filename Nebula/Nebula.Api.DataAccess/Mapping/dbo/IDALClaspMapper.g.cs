using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALClaspMapper
	{
		void MapDTOToEF(
			int id,
			DTOClasp dto,
			Clasp efClasp);

		DTOClasp MapEFToDTO(
			Clasp efClasp);
	}
}

/*<Codenesium>
    <Hash>56671457a8741a052fd9adddb4af34fd</Hash>
</Codenesium>*/