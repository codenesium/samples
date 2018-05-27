using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALPersonPhoneMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOPersonPhone dto,
			PersonPhone efPersonPhone);

		DTOPersonPhone MapEFToDTO(
			PersonPhone efPersonPhone);
	}
}

/*<Codenesium>
    <Hash>304bad83f38e3b1d01b71dce5d9e2d17</Hash>
</Codenesium>*/