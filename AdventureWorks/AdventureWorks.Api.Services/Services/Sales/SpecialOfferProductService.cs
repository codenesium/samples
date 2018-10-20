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
	public partial class SpecialOfferProductService : AbstractSpecialOfferProductService, ISpecialOfferProductService
	{
		public SpecialOfferProductService(
			ILogger<ISpecialOfferProductRepository> logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
			IBOLSpecialOfferProductMapper bolspecialOfferProductMapper,
			IDALSpecialOfferProductMapper dalspecialOfferProductMapper)
			: base(logger,
			       specialOfferProductRepository,
			       specialOfferProductModelValidator,
			       bolspecialOfferProductMapper,
			       dalspecialOfferProductMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1f32459dbf58b295712d4f63d2a938fa</Hash>
</Codenesium>*/