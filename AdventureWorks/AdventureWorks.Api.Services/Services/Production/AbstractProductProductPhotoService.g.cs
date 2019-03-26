using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductProductPhotoService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IProductProductPhotoRepository ProductProductPhotoRepository { get; private set; }

		protected IApiProductProductPhotoServerRequestModelValidator ProductProductPhotoModelValidator { get; private set; }

		protected IDALProductProductPhotoMapper DalProductProductPhotoMapper { get; private set; }

		private ILogger logger;

		public AbstractProductProductPhotoService(
			ILogger logger,
			MediatR.IMediator mediator,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoServerRequestModelValidator productProductPhotoModelValidator,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper)
			: base()
		{
			this.ProductProductPhotoRepository = productProductPhotoRepository;
			this.ProductProductPhotoModelValidator = productProductPhotoModelValidator;
			this.DalProductProductPhotoMapper = dalProductProductPhotoMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductProductPhotoServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ProductProductPhoto> records = await this.ProductProductPhotoRepository.All(limit, offset, query);

			return this.DalProductProductPhotoMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiProductProductPhotoServerResponseModel> Get(int productID)
		{
			ProductProductPhoto record = await this.ProductProductPhotoRepository.Get(productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductProductPhotoMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductProductPhotoServerResponseModel>> Create(
			ApiProductProductPhotoServerRequestModel model)
		{
			CreateResponse<ApiProductProductPhotoServerResponseModel> response = ValidationResponseFactory<ApiProductProductPhotoServerResponseModel>.CreateResponse(await this.ProductProductPhotoModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ProductProductPhoto record = this.DalProductProductPhotoMapper.MapModelToEntity(default(int), model);
				record = await this.ProductProductPhotoRepository.Create(record);

				response.SetRecord(this.DalProductProductPhotoMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ProductProductPhotoCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductProductPhotoServerResponseModel>> Update(
			int productID,
			ApiProductProductPhotoServerRequestModel model)
		{
			var validationResult = await this.ProductProductPhotoModelValidator.ValidateUpdateAsync(productID, model);

			if (validationResult.IsValid)
			{
				ProductProductPhoto record = this.DalProductProductPhotoMapper.MapModelToEntity(productID, model);
				await this.ProductProductPhotoRepository.Update(record);

				record = await this.ProductProductPhotoRepository.Get(productID);

				ApiProductProductPhotoServerResponseModel apiModel = this.DalProductProductPhotoMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ProductProductPhotoUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProductProductPhotoServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiProductProductPhotoServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductProductPhotoModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.ProductProductPhotoRepository.Delete(productID);

				await this.mediator.Publish(new ProductProductPhotoDeletedNotification(productID));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>de8ba421ad8af186573a6e9c284a123b</Hash>
</Codenesium>*/