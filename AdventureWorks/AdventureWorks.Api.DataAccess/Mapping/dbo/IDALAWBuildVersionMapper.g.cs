using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALAWBuildVersionMapper
	{
		void MapDTOToEF(
			int systemInformationID,
			DTOAWBuildVersion dto,
			AWBuildVersion efAWBuildVersion);

		DTOAWBuildVersion MapEFToDTO(
			AWBuildVersion efAWBuildVersion);
	}
}

/*<Codenesium>
    <Hash>c1f6abaef939cffdb108ee2dfebcc324</Hash>
</Codenesium>*/