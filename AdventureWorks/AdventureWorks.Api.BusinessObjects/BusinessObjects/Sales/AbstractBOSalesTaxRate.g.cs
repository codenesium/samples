using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOSalesTaxRate
	{
		private ISalesTaxRateRepository salesTaxRateRepository;
		private ISalesTaxRateModelValidator salesTaxRateModelValidator;
		private ILogger logger;

		public AbstractBOSalesTaxRate(
			ILogger logger,
			ISalesTaxRateRepository salesTaxRateRepository,
			ISalesTaxRateModelValidator salesTaxRateModelValidator)

		{
			this.salesTaxRateRepository = salesTaxRateRepository;
			this.salesTaxRateModelValidator = salesTaxRateModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SalesTaxRateModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.salesTaxRateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.salesTaxRateRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesTaxRateID,
			SalesTaxRateModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesTaxRateModelValidator.ValidateUpdateAsync(salesTaxRateID, model));

			if (response.Success)
			{
				this.salesTaxRateRepository.Update(salesTaxRateID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesTaxRateID)
		{
			ActionResponse response = new ActionResponse(await this.salesTaxRateModelValidator.ValidateDeleteAsync(salesTaxRateID));

			if (response.Success)
			{
				this.salesTaxRateRepository.Delete(salesTaxRateID);
			}
			return response;
		}

		public virtual POCOSalesTaxRate Get(int salesTaxRateID)
		{
			return this.salesTaxRateRepository.Get(salesTaxRateID);
		}

		public virtual List<POCOSalesTaxRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTaxRateRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>52919c6fb13135b815e3302f58ae48c9</Hash>
</Codenesium>*/