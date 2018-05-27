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
	public abstract class AbstractBOSalesTaxRate: AbstractBOManager
	{
		private ISalesTaxRateRepository salesTaxRateRepository;
		private IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator;
		private IBOLSalesTaxRateMapper salesTaxRateMapper;
		private ILogger logger;

		public AbstractBOSalesTaxRate(
			ILogger logger,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateRequestModelValidator salesTaxRateModelValidator,
			IBOLSalesTaxRateMapper salesTaxRateMapper)
			: base()

		{
			this.salesTaxRateRepository = salesTaxRateRepository;
			this.salesTaxRateModelValidator = salesTaxRateModelValidator;
			this.salesTaxRateMapper = salesTaxRateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTaxRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesTaxRateRepository.All(skip, take, orderClause);

			return this.salesTaxRateMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSalesTaxRateResponseModel> Get(int salesTaxRateID)
		{
			var record = await salesTaxRateRepository.Get(salesTaxRateID);

			return this.salesTaxRateMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSalesTaxRateResponseModel>> Create(
			ApiSalesTaxRateRequestModel model)
		{
			CreateResponse<ApiSalesTaxRateResponseModel> response = new CreateResponse<ApiSalesTaxRateResponseModel>(await this.salesTaxRateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.salesTaxRateMapper.MapModelToDTO(default (int), model);
				var record = await this.salesTaxRateRepository.Create(dto);

				response.SetRecord(this.salesTaxRateMapper.MapDTOToModel(record));
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
				var dto = this.salesTaxRateMapper.MapModelToDTO(salesTaxRateID, model);
				await this.salesTaxRateRepository.Update(salesTaxRateID, dto);
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
			DTOSalesTaxRate record = await this.salesTaxRateRepository.GetStateProvinceIDTaxType(stateProvinceID,taxType);

			return this.salesTaxRateMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>cda2bead244d53d0051381f498ec6225</Hash>
</Codenesium>*/