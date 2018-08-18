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
	public partial class ProductPhotoService : AbstractProductPhotoService, IProductPhotoService
	{
		public ProductPhotoService(
			ILogger<IProductPhotoRepository> logger,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoRequestModelValidator productPhotoModelValidator,
			IBOLProductPhotoMapper bolproductPhotoMapper,
			IDALProductPhotoMapper dalproductPhotoMapper,
			IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper
			)
			: base(logger,
			       productPhotoRepository,
			       productPhotoModelValidator,
			       bolproductPhotoMapper,
			       dalproductPhotoMapper,
			       bolProductProductPhotoMapper,
			       dalProductProductPhotoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1f5d727b9a9b2a86cde85fa13a728a7d</Hash>
</Codenesium>*/