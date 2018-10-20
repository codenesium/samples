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
			IDALSpecialOfferMapper dalspecialOfferMapper)
			: base(logger,
			       specialOfferRepository,
			       specialOfferModelValidator,
			       bolspecialOfferMapper,
			       dalspecialOfferMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>03a3176bdde87145374c7a35889ead26</Hash>
</Codenesium>*/