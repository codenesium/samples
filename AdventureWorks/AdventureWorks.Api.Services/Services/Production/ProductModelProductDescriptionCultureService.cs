using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>26671955362f67454653f99533007b50</Hash>
</Codenesium>*/