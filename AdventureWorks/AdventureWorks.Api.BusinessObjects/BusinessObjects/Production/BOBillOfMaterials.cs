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
			IApiBillOfMaterialsModelValidator billOfMaterialsModelValidator)
			: base(logger, billOfMaterialsRepository, billOfMaterialsModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a6397516a49c9b178a28b610f62eacef</Hash>
</Codenesium>*/