using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOBillOfMaterials: AbstractBOBillOfMaterials, IBOBillOfMaterials
	{
		public BOBillOfMaterials(
			ILogger<BillOfMaterialsRepository> logger,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IApiBillOfMaterialsRequestModelValidator billOfMaterialsModelValidator,
			IBOLBillOfMaterialsMapper billOfMaterialsMapper)
			: base(logger, billOfMaterialsRepository, billOfMaterialsModelValidator, billOfMaterialsMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>de898335a37af46967b1391b28b6b4eb</Hash>
</Codenesium>*/