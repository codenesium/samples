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
	public partial class ProductModelIllustrationService : AbstractProductModelIllustrationService, IProductModelIllustrationService
	{
		public ProductModelIllustrationService(
			ILogger<IProductModelIllustrationRepository> logger,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator,
			IBOLProductModelIllustrationMapper bolproductModelIllustrationMapper,
			IDALProductModelIllustrationMapper dalproductModelIllustrationMapper
			)
			: base(logger,
			       productModelIllustrationRepository,
			       productModelIllustrationModelValidator,
			       bolproductModelIllustrationMapper,
			       dalproductModelIllustrationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7bba490afe1d45caddb3c57caaefcbd1</Hash>
</Codenesium>*/