using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class SpecialOfferService : AbstractSpecialOfferService, ISpecialOfferService
	{
		public SpecialOfferService(
			ILogger<ISpecialOfferRepository> logger,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
			IBOLSpecialOfferMapper bolspecialOfferMapper,
			IDALSpecialOfferMapper dalspecialOfferMapper,
			IBOLSpecialOfferProductMapper bolSpecialOfferProductMapper,
			IDALSpecialOfferProductMapper dalSpecialOfferProductMapper
			)
			: base(logger,
			       specialOfferRepository,
			       specialOfferModelValidator,
			       bolspecialOfferMapper,
			       dalspecialOfferMapper,
			       bolSpecialOfferProductMapper,
			       dalSpecialOfferProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>15137406fe0c8f903426b74fa48901be</Hash>
</Codenesium>*/