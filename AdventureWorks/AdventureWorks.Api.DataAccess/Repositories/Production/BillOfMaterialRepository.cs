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
	public partial class BillOfMaterialRepository : AbstractBillOfMaterialRepository, IBillOfMaterialRepository
	{
		public BillOfMaterialRepository(
			ILogger<BillOfMaterialRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d8fc1eb426d7b25de6dc125a9aa29880</Hash>
</Codenesium>*/