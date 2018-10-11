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
			IDALBillOfMaterialMapper dalbillOfMaterialMapper)
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
    <Hash>a3b38265f1d5855745117a0e4490607c</Hash>
</Codenesium>*/