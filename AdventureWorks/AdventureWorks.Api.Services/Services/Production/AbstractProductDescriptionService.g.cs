using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductDescriptionService : AbstractService
	{
		private IMediator mediator;

		protected IProductDescriptionRepository ProductDescriptionRepository { get; private set; }

		protected IApiProductDescriptionServerRequestModelValidator ProductDescriptionModelValidator { get; private set; }

		protected IBOLProductDescriptionMapper BolProductDescriptionMapper { get; private set; }

		protected IDALProductDescriptionMapper DalProductDescriptionMapper { get; private set; }

		private ILogger logger;

		public AbstractProductDescriptionService(
			ILogger logger,
			IMediator mediator,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionServerRequestModelValidator productDescriptionModelValidator,
			IBOLProductDescriptionMapper bolProductDescriptionMapper,
			IDALProductDescriptionMapper dalProductDescriptionMapper)
			: base()
		{
			this.ProductDescriptionRepository = productDescriptionRepository;
			this.ProductDescriptionModelValidator = productDescriptionModelValidator;
			this.BolProductDescriptionMapper = bolProductDescriptionMapper;
			this.DalProductDescriptionMapper = dalProductDescriptionMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductDescriptionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductDescriptionRepository.All(limit, offset);

			return this.BolProductDescriptionMapper.MapBOToModel(this.DalProductDescriptionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductDescriptionServerResponseModel> Get(int productDescriptionID)
		{
			var record = await this.ProductDescriptionRepository.Get(productDescriptionID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductDescriptionMapper.MapBOToModel(this.DalProductDescriptionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductDescriptionServerResponseModel>> Create(
			ApiProductDescriptionServerRequestModel model)
		{
			CreateResponse<ApiProductDescriptionServerResponseModel> response = ValidationResponseFactory<ApiProductDescriptionServerResponseModel>.CreateResponse(await this.ProductDescriptionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolProductDescriptionMapper.MapModelToBO(default(int), model);
				var record = await this.ProductDescriptionRepository.Create(this.DalProductDescriptionMapper.MapBOToEF(bo));

				var businessObject = this.DalProductDescriptionMapper.MapEFToBO(record);
				response.SetRecord(this.BolProductDescriptionMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new ProductDescriptionCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductDescriptionServerResponseModel>> Update(
			int productDescriptionID,
			ApiProductDescriptionServerRequestModel model)
		{
			var validationResult = await this.ProductDescriptionModelValidator.ValidateUpdateAsync(productDescriptionID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductDescriptionMapper.MapModelToBO(productDescriptionID, model);
				await this.ProductDescriptionRepository.Update(this.DalProductDescriptionMapper.MapBOToEF(bo));

				var record = await this.ProductDescriptionRepository.Get(productDescriptionID);

				var businessObject = this.DalProductDescriptionMapper.MapEFToBO(record);
				var apiModel = this.BolProductDescriptionMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new ProductDescriptionUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProductDescriptionServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiProductDescriptionServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productDescriptionID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductDescriptionModelValidator.ValidateDeleteAsync(productDescriptionID));

			if (response.Success)
			{
				await this.ProductDescriptionRepository.Delete(productDescriptionID);

				await this.mediator.Publish(new ProductDescriptionDeletedNotification(productDescriptionID));
			}

			return response;
		}

		public async virtual Task<ApiProductDescriptionServerResponseModel> ByRowguid(Guid rowguid)
		{
			ProductDescription record = await this.ProductDescriptionRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductDescriptionMapper.MapBOToModel(this.DalProductDescriptionMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>a1355846f8e24dd1cb4258356f81fdfd</Hash>
</Codenesium>*/