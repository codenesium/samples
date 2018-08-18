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
	public partial class BillOfMaterialService : AbstractBillOfMaterialService, IBillOfMaterialService
	{
		public BillOfMaterialService(
			ILogger<IBillOfMaterialRepository> logger,
			IBillOfMaterialRepository billOfMaterialRepository,
			IApiBillOfMaterialRequestModelValidator billOfMaterialModelValidator,
			IBOLBillOfMaterialMapper bolbillOfMaterialMapper,
			IDALBillOfMaterialMapper dalbillOfMaterialMapper
			)
			: base(logger,
			       billOfMaterialRepository,
			       billOfMaterialModelValidator,
			       bolbillOfMaterialMapper,
			       dalbillOfMaterialMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2115f8164204772392e9260dbd22a972</Hash>
</Codenesium>*/