using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesTaxRateService : AbstractService
	{
		private IMediator mediator;

		protected ISalesTaxRateRepository SalesTaxRateRepository { get; private set; }

		protected IApiSalesTaxRateServerRequestModelValidator SalesTaxRateModelValidator { get; private set; }

		protected IBOLSalesTaxRateMapper BolSalesTaxRateMapper { get; private set; }

		protected IDALSalesTaxRateMapper DalSalesTaxRateMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesTaxRateService(
			ILogger logger,
			IMediator mediator,
			ISalesTaxRateRepository salesTaxRateRepository,
			IApiSalesTaxRateServerRequestModelValidator salesTaxRateModelValidator,
			IBOLSalesTaxRateMapper bolSalesTaxRateMapper,
			IDALSalesTaxRateMapper dalSalesTaxRateMapper)
			: base()
		{
			this.SalesTaxRateRepository = salesTaxRateRepository;
			this.SalesTaxRateModelValidator = salesTaxRateModelValidator;
			this.BolSalesTaxRateMapper = bolSalesTaxRateMapper;
			this.DalSalesTaxRateMapper = dalSalesTaxRateMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSalesTaxRateServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesTaxRateRepository.All(limit, offset);

			return this.BolSalesTaxRateMapper.MapBOToModel(this.DalSalesTaxRateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesTaxRateServerResponseModel> Get(int salesTaxRateID)
		{
			var record = await this.SalesTaxRateRepository.Get(salesTaxRateID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesTaxRateMapper.MapBOToModel(this.DalSalesTaxRateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesTaxRateServerResponseModel>> Create(
			ApiSalesTaxRateServerRequestModel model)
		{
			CreateResponse<ApiSalesTaxRateServerResponseModel> response = ValidationResponseFactory<ApiSalesTaxRateServerResponseModel>.CreateResponse(await this.SalesTaxRateModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSalesTaxRateMapper.MapModelToBO(default(int), model);
				var record = await this.SalesTaxRateRepository.Create(this.DalSalesTaxRateMapper.MapBOToEF(bo));

				var businessObject = this.DalSalesTaxRateMapper.MapEFToBO(record);
				response.SetRecord(this.BolSalesTaxRateMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new SalesTaxRateCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesTaxRateServerResponseModel>> Update(
			int salesTaxRateID,
			ApiSalesTaxRateServerRequestModel model)
		{
			var validationResult = await this.SalesTaxRateModelValidator.ValidateUpdateAsync(salesTaxRateID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesTaxRateMapper.MapModelToBO(salesTaxRateID, model);
				await this.SalesTaxRateRepository.Update(this.DalSalesTaxRateMapper.MapBOToEF(bo));

				var record = await this.SalesTaxRateRepository.Get(salesTaxRateID);

				var businessObject = this.DalSalesTaxRateMapper.MapEFToBO(record);
				var apiModel = this.BolSalesTaxRateMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new SalesTaxRateUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSalesTaxRateServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSalesTaxRateServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int salesTaxRateID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SalesTaxRateModelValidator.ValidateDeleteAsync(salesTaxRateID));

			if (response.Success)
			{
				await this.SalesTaxRateRepository.Delete(salesTaxRateID);

				await this.mediator.Publish(new SalesTaxRateDeletedNotification(salesTaxRateID));
			}

			return response;
		}

		public async virtual Task<ApiSalesTaxRateServerResponseModel> ByRowguid(Guid rowguid)
		{
			SalesTaxRate record = await this.SalesTaxRateRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesTaxRateMapper.MapBOToModel(this.DalSalesTaxRateMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<ApiSalesTaxRateServerResponseModel> ByStateProvinceIDTaxType(int stateProvinceID, int taxType)
		{
			SalesTaxRate record = await this.SalesTaxRateRepository.ByStateProvinceIDTaxType(stateProvinceID, taxType);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesTaxRateMapper.MapBOToModel(this.DalSalesTaxRateMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>800f10ac588fa2ea2f0c847f0fe50298</Hash>
</Codenesium>*/