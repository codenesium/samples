using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class ProvinceService : AbstractProvinceService, IProvinceService
	{
		public ProvinceService(
			ILogger<IProvinceRepository> logger,
			IProvinceRepository provinceRepository,
			IApiProvinceRequestModelValidator provinceModelValidator,
			IBOLProvinceMapper bolprovinceMapper,
			IDALProvinceMapper dalprovinceMapper,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base(logger,
			       provinceRepository,
			       provinceModelValidator,
			       bolprovinceMapper,
			       dalprovinceMapper,
			       bolCityMapper,
			       dalCityMapper,
			       bolVenueMapper,
			       dalVenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>061385c141d19265338f436853bfc898</Hash>
</Codenesium>*/