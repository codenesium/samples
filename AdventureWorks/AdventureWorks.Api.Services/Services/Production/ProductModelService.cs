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
			IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
			IDALProductModelIllustrationMapper dalProductModelIllustrationMapper,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper
			)
			: base(logger,
			       productModelRepository,
			       productModelModelValidator,
			       bolproductModelMapper,
			       dalproductModelMapper,
			       bolProductMapper,
			       dalProductMapper,
			       bolProductModelIllustrationMapper,
			       dalProductModelIllustrationMapper,
			       bolProductModelProductDescriptionCultureMapper,
			       dalProductModelProductDescriptionCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5d9724d1b28f048d100b5b578e972c8e</Hash>
</Codenesium>*/