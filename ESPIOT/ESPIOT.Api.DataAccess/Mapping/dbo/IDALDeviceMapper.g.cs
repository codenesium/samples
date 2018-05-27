using System;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.DataAccess
{
	public interface IDALDeviceMapper
	{
		void MapDTOToEF(
			int id,
			DTODevice dto,
			Device efDevice);

		DTODevice MapEFToDTO(
			Device efDevice);
	}
}

/*<Codenesium>
    <Hash>5035fb8398e62eabc53a756ba322d967</Hash>
</Codenesium>*/