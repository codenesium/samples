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
	public partial class ProductProductPhotoService : AbstractProductProductPhotoService, IProductProductPhotoService
	{
		public ProductProductPhotoService(
			ILogger<IProductProductPhotoRepository> logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator,
			IBOLProductProductPhotoMapper bolproductProductPhotoMapper,
			IDALProductProductPhotoMapper dalproductProductPhotoMapper)
			: base(logger,
			       productProductPhotoRepository,
			       productProductPhotoModelValidator,
			       bolproductProductPhotoMapper,
			       dalproductProductPhotoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>69e4007c5e10d9775ec69cf88ab14a6f</Hash>
</Codenesium>*/