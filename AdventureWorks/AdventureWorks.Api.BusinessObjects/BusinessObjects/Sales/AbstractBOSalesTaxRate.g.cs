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

		public virtual ApiResponse GetById(int salesTaxRateID)
		{
			return this.salesTaxRateRepository.GetById(salesTaxRateID);
		}

		public virtual POCOSalesTaxRate GetByIdDirect(int salesTaxRateID)
		{
			return this.salesTaxRateRepository.GetByIdDirect(salesTaxRateID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTaxRateRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTaxRateRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesTaxRate> GetWhereDirect(Expression<Func<EFSalesTaxRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTaxRateRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>89347409cca0d4368206149f31b1ab7c</Hash>
</Codenesium>*/