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
    <Hash>f94b9a88574fea20a39144972fbe72dc</Hash>
</Codenesium>*/