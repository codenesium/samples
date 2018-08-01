using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALProvinceMapper
	{
		Province MapBOToEF(
			BOProvince bo);

		BOProvince MapEFToBO(
			Province efProvince);

		List<BOProvince> MapEFToBO(
			List<Province> records);
	}
}

/*<Codenesium>
    <Hash>4090414d17162fc56618166a276d694c</Hash>
</Codenesium>*/