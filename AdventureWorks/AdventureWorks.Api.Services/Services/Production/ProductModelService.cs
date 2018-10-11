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
	public partial class ProductModelService : AbstractProductModelService, IProductModelService
	{
		public ProductModelService(
			ILogger<IProductModelRepository> logger,
			IProductModelRepository productModelRepository,
			IApiProductModelRequestModelValidator productModelModelValidator,
			IBOLProductModelMapper bolproductModelMapper,
			IDALProductModelMapper dalproductModelMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper)
			: base(logger,
			       productModelRepository,
			       productModelModelValidator,
			       bolproductModelMapper,
			       dalproductModelMapper,
			       bolProductMapper,
			       dalProductMapper,
			       bolProductModelProductDescriptionCultureMapper,
			       dalProductModelProductDescriptionCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c676e354f532cbf71fd5eff3b261196f</Hash>
</Codenesium>*/