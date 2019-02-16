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

		protected IDALProductDescriptionMapper DalProductDescriptionMapper { get; private set; }

		private ILogger logger;

		public AbstractProductDescriptionService(
			ILogger logger,
			IMediator mediator,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionServerRequestModelValidator productDescriptionModelValidator,
			IDALProductDescriptionMapper dalProductDescriptionMapper)
			: base()
		{
			this.ProductDescriptionRepository = productDescriptionRepository;
			this.ProductDescriptionModelValidator = productDescriptionModelValidator;
			this.DalProductDescriptionMapper = dalProductDescriptionMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductDescriptionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.ProductDescriptionRepository.All(limit, offset, query);

			return this.DalProductDescriptionMapper.MapBOToModel(records);
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
				return this.DalProductDescriptionMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductDescriptionServerResponseModel>> Create(
			ApiProductDescriptionServerRequestModel model)
		{
			CreateResponse<ApiProductDescriptionServerResponseModel> response = ValidationResponseFactory<ApiProductDescriptionServerResponseModel>.CreateResponse(await this.ProductDescriptionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalProductDescriptionMapper.MapModelToBO(default(int), model);
				var record = await this.ProductDescriptionRepository.Create(bo);

				response.SetRecord(this.DalProductDescriptionMapper.MapBOToModel(record));
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
				var bo = this.DalProductDescriptionMapper.MapModelToBO(productDescriptionID, model);
				await this.ProductDescriptionRepository.Update(bo);

				var record = await this.ProductDescriptionRepository.Get(productDescriptionID);

				var apiModel = this.DalProductDescriptionMapper.MapBOToModel(record);
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
				return this.DalProductDescriptionMapper.MapBOToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>92c0e1f13ee1b782499f9c9c0f9d6143</Hash>
</Codenesium>*/