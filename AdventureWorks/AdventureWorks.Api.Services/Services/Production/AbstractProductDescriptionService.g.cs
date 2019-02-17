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
			List<ProductDescription> records = await this.ProductDescriptionRepository.All(limit, offset, query);

			return this.DalProductDescriptionMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiProductDescriptionServerResponseModel> Get(int productDescriptionID)
		{
			ProductDescription record = await this.ProductDescriptionRepository.Get(productDescriptionID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductDescriptionMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductDescriptionServerResponseModel>> Create(
			ApiProductDescriptionServerRequestModel model)
		{
			CreateResponse<ApiProductDescriptionServerResponseModel> response = ValidationResponseFactory<ApiProductDescriptionServerResponseModel>.CreateResponse(await this.ProductDescriptionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ProductDescription record = this.DalProductDescriptionMapper.MapModelToEntity(default(int), model);
				record = await this.ProductDescriptionRepository.Create(record);

				response.SetRecord(this.DalProductDescriptionMapper.MapEntityToModel(record));
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
				ProductDescription record = this.DalProductDescriptionMapper.MapModelToEntity(productDescriptionID, model);
				await this.ProductDescriptionRepository.Update(record);

				record = await this.ProductDescriptionRepository.Get(productDescriptionID);

				ApiProductDescriptionServerResponseModel apiModel = this.DalProductDescriptionMapper.MapEntityToModel(record);
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
				return this.DalProductDescriptionMapper.MapEntityToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>640aef2764587b45077df97d30de2aea</Hash>
</Codenesium>*/