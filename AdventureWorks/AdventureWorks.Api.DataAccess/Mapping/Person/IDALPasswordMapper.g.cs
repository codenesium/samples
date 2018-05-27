using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALPasswordMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOPassword dto,
			Password efPassword);

		DTOPassword MapEFToDTO(
			Password efPassword);
	}
}

/*<Codenesium>
    <Hash>b185e4428960303c13152bc55f1f6f99</Hash>
</Codenesium>*/