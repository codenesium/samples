using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IDALVersionInfoMapper
	{
		VersionInfo MapBOToEF(
			BOVersionInfo bo);

		BOVersionInfo MapEFToBO(
			VersionInfo efVersionInfo);

		List<BOVersionInfo> MapEFToBO(
			List<VersionInfo> records);
	}
}

/*<Codenesium>
    <Hash>25e1852331adf4f372bc429ab9419e0d</Hash>
</Codenesium>*/