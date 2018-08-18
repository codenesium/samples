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
	public partial class ProductDescriptionService : AbstractProductDescriptionService, IProductDescriptionService
	{
		public ProductDescriptionService(
			ILogger<IProductDescriptionRepository> logger,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionRequestModelValidator productDescriptionModelValidator,
			IBOLProductDescriptionMapper bolproductDescriptionMapper,
			IDALProductDescriptionMapper dalproductDescriptionMapper,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper
			)
			: base(logger,
			       productDescriptionRepository,
			       productDescriptionModelValidator,
			       bolproductDescriptionMapper,
			       dalproductDescriptionMapper,
			       bolProductModelProductDescriptionCultureMapper,
			       dalProductModelProductDescriptionCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>31296a1bbc94724222817385a559fcc4</Hash>
</Codenesium>*/