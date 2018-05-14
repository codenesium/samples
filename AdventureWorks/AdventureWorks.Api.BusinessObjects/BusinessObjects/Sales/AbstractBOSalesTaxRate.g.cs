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
		private IApiSalesTaxRateModelValidator salesTaxRateModelValidator;
		private ILogger logger;

		public AbstractBOSalesTaxRate(
			ILogger logger,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateModelValidator salesTaxRateModelValidator)

		{
			this.salesTaxRateRepository = salesTaxRateRepository;
			this.salesTaxRateModelValidator = salesTaxRateModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOSalesTaxRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTaxRateRepository.All(skip, take, orderClause);
		}

		public virtual POCOSalesTaxRate Get(int salesTaxRateID)
		{
			return this.salesTaxRateRepository.Get(salesTaxRateID);
		}

		public virtual async Task<CreateResponse<POCOSalesTaxRate>> Create(
			ApiSalesTaxRateModel model)
		{
			CreateResponse<POCOSalesTaxRate> response = new CreateResponse<POCOSalesTaxRate>(await this.salesTaxRateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesTaxRate record = this.salesTaxRateRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesTaxRateID,
			ApiSalesTaxRateModel model)
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

		public POCOSalesTaxRate GetStateProvinceIDTaxType(int stateProvinceID,int taxType)
		{
			return this.salesTaxRateRepository.GetStateProvinceIDTaxType(stateProvinceID,taxType);
		}
	}
}

/*<Codenesium>
    <Hash>9a9f6b88488d4c102d685da4c02a00f4</Hash>
</Codenesium>*/