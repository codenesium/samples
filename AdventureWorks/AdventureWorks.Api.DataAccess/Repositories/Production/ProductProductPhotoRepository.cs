using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ProductProductPhotoRepository : AbstractProductProductPhotoRepository, IProductProductPhotoRepository
	{
		public ProductProductPhotoRepository(
			ILogger<ProductProductPhotoRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8a34bd59f3d91379427dfe5577bc5fc2</Hash>
</Codenesium>*/