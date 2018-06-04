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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesTaxRateService: AbstractService
	{
		private ISalesTaxRateRepository salesTaxRateRepository;
		private IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator;
		private IBOLSalesTaxRateMapper BOLSalesTaxRateMapper;
		private IDALSalesTaxRateMapper DALSalesTaxRateMapper;
		private ILogger logger;

		public AbstractSalesTaxRateService(
			ILogger logger,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator,
			IBOLSalesTaxRateMapper bolsalesTaxRateMapper,
			IDALSalesTaxRateMapper dalsalesTaxRateMapper)
			: base()

		{
			this.salesTaxRateRepository = salesTaxRateRepository;
			this.salesTaxRateModelValidator = salesTaxRateModelValidator;
			this.BOLSalesTaxRateMapper = bolsalesTaxRateMapper;
			this.DALSalesTaxRateMapper = dalsalesTaxRateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTaxRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesTaxRateRepository.All(skip, take, orderClause);

			return this.BOLSalesTaxRateMapper.MapBOToModel(this.DALSalesTaxRateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesTaxRateResponseModel> Get(int salesTaxRateID)
		{
			var record = await salesTaxRateRepository.Get(salesTaxRateID);

			return this.BOLSalesTaxRateMapper.MapBOToModel(this.DALSalesTaxRateMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesTaxRateResponseModel>> Create(
			ApiSalesTaxRateRequestModel model)
		{
			CreateResponse<ApiSalesTaxRateResponseModel> response = new CreateResponse<ApiSalesTaxRateResponseModel>(await this.salesTaxRateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSalesTaxRateMapper.MapModelToBO(default (int), model);
				var record = await this.salesTaxRateRepository.Create(this.DALSalesTaxRateMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSalesTaxRateMapper.MapBOToModel(this.DALSalesTaxRateMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesTaxRateID,
			ApiSalesTaxRateRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesTaxRateModelValidator.ValidateUpdateAsync(salesTaxRateID, model));

			if (response.Success)
			{
				var bo = this.BOLSalesTaxRateMapper.MapModelToBO(salesTaxRateID, model);
				await this.salesTaxRateRepository.Update(this.DALSalesTaxRateMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesTaxRateID)
		{
			ActionResponse response = new ActionResponse(await this.salesTaxRateModelValidator.ValidateDeleteAsync(salesTaxRateID));

			if (response.Success)
			{
				await this.salesTaxRateRepository.Delete(salesTaxRateID);
			}
			return response;
		}

		public async Task<ApiSalesTaxRateResponseModel> GetStateProvinceIDTaxType(int stateProvinceID,int taxType)
		{
			SalesTaxRate record = await this.salesTaxRateRepository.GetStateProvinceIDTaxType(stateProvinceID,taxType);

			return this.BOLSalesTaxRateMapper.MapBOToModel(this.DALSalesTaxRateMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>12fa319763cb7994a6505248e038a394</Hash>
</Codenesium>*/