using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALDocumentMapper
	{
		void MapDTOToEF(
			Guid documentNode,
			DTODocument dto,
			Document efDocument);

		DTODocument MapEFToDTO(
			Document efDocument);
	}
}

/*<Codenesium>
    <Hash>6b06ebd4d17d5311857368fe76bd99d0</Hash>
</Codenesium>*/