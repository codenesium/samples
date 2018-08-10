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
	public partial class ProductModelIllustrationRepository : AbstractProductModelIllustrationRepository, IProductModelIllustrationRepository
	{
		public ProductModelIllustrationRepository(
			ILogger<ProductModelIllustrationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a33a79e446771c958c3d3c3dcebd7288</Hash>
</Codenesium>*/