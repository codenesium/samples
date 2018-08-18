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
	public partial class ProductPhotoRepository : AbstractProductPhotoRepository, IProductPhotoRepository
	{
		public ProductPhotoRepository(
			ILogger<ProductPhotoRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c86165ac634219004162fc208c4562b2</Hash>
</Codenesium>*/