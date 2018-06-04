using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class BillOfMaterialsService: AbstractBillOfMaterialsService, IBillOfMaterialsService
	{
		public BillOfMaterialsService(
			ILogger<BillOfMaterialsRepository> logger,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IApiBillOfMaterialsRequestModelValidator billOfMaterialsModelValidator,
			IBOLBillOfMaterialsMapper BOLbillOfMaterialsMapper,
			IDALBillOfMaterialsMapper DALbillOfMaterialsMapper)
			: base(logger, billOfMaterialsRepository,
			       billOfMaterialsModelValidator,
			       BOLbillOfMaterialsMapper,
			       DALbillOfMaterialsMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7a05d1b7b68ac189b12390f3a6d0acdb</Hash>
</Codenesium>*/