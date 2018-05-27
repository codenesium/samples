using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductDocumentMapper
	{
		void MapDTOToEF(
			int productID,
			DTOProductDocument dto,
			ProductDocument efProductDocument);

		DTOProductDocument MapEFToDTO(
			ProductDocument efProductDocument);
	}
}

/*<Codenesium>
    <Hash>da97d6baca1c01929ab9da26aabcac98</Hash>
</Codenesium>*/