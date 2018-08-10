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
	public partial class ProductModelProductDescriptionCultureService : AbstractProductModelProductDescriptionCultureService, IProductModelProductDescriptionCultureService
	{
		public ProductModelProductDescriptionCultureService(
			ILogger<IProductModelProductDescriptionCultureRepository> logger,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
			IBOLProductModelProductDescriptionCultureMapper bolproductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalproductModelProductDescriptionCultureMapper
			)
			: base(logger,
			       productModelProductDescriptionCultureRepository,
			       productModelProductDescriptionCultureModelValidator,
			       bolproductModelProductDescriptionCultureMapper,
			       dalproductModelProductDescriptionCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7e4bc4f22796d09b7b873c567b2560e3</Hash>
</Codenesium>*/