using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALCultureMapper
	{
		void MapDTOToEF(
			string cultureID,
			DTOCulture dto,
			Culture efCulture);

		DTOCulture MapEFToDTO(
			Culture efCulture);
	}
}

/*<Codenesium>
    <Hash>5e04aadbd83a2ebd8bb01315fec6ce21</Hash>
</Codenesium>*/