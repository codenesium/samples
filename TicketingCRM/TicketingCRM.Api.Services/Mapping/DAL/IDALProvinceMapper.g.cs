using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALProvinceMapper
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
    <Hash>1af734f1dacfd075400399d319923c49</Hash>
</Codenesium>*/