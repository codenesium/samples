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
	public partial class ProductModelProductDescriptionCultureRepository : AbstractProductModelProductDescriptionCultureRepository, IProductModelProductDescriptionCultureRepository
	{
		public ProductModelProductDescriptionCultureRepository(
			ILogger<ProductModelProductDescriptionCultureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a58ffcf24c2b834af51aa76190d906b4</Hash>
</Codenesium>*/