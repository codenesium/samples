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
			IBillOfMaterialsModelValidator billOfMaterialsModelValidator)
			: base(logger, billOfMaterialsRepository, billOfMaterialsModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b08b733de844b2a739866b472afdb938</Hash>
</Codenesium>*/