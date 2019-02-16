using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductPhotoService : AbstractService
	{
		private IMediator mediator;

		protected IProductPhotoRepository ProductPhotoRepository { get; private set; }

		protected IApiProductPhotoServerRequestModelValidator ProductPhotoModelValidator { get; private set; }

		protected IDALProductPhotoMapper DalProductPhotoMapper { get; private set; }

		private ILogger logger;

		public AbstractProductPhotoService(
			ILogger logger,
			IMediator mediator,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoServerRequestModelValidator productPhotoModelValidator,
			IDALProductPhotoMapper dalProductPhotoMapper)
			: base()
		{
			this.ProductPhotoRepository = productPhotoRepository;
			this.ProductPhotoModelValidator = productPhotoModelValidator;
			this.DalProductPhotoMapper = dalProductPhotoMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductPhotoServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.ProductPhotoRepository.All(limit, offset, query);

			return this.DalProductPhotoMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiProductPhotoServerResponseModel> Get(int productPhotoID)
		{
			var record = await this.ProductPhotoRepository.Get(productPhotoID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductPhotoMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductPhotoServerResponseModel>> Create(
			ApiProductPhotoServerRequestModel model)
		{
			CreateResponse<ApiProductPhotoServerResponseModel> response = ValidationResponseFactory<ApiProductPhotoServerResponseModel>.CreateResponse(await this.ProductPhotoModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalProductPhotoMapper.MapModelToBO(default(int), model);
				var record = await this.ProductPhotoRepository.Create(bo);

				response.SetRecord(this.DalProductPhotoMapper.MapBOToModel(record));
				await this.mediator.Publish(new ProductPhotoCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductPhotoServerResponseModel>> Update(
			int productPhotoID,
			ApiProductPhotoServerRequestModel model)
		{
			var validationResult = await this.ProductPhotoModelValidator.ValidateUpdateAsync(productPhotoID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalProductPhotoMapper.MapModelToBO(productPhotoID, model);
				await this.ProductPhotoRepository.Update(bo);

				var record = await this.ProductPhotoRepository.Get(productPhotoID);

				var apiModel = this.DalProductPhotoMapper.MapBOToModel(record);
				await this.mediator.Publish(new ProductPhotoUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProductPhotoServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiProductPhotoServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productPhotoID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductPhotoModelValidator.ValidateDeleteAsync(productPhotoID));

			if (response.Success)
			{
				await this.ProductPhotoRepository.Delete(productPhotoID);

				await this.mediator.Publish(new ProductPhotoDeletedNotification(productPhotoID));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cd7537d006e2a3eb67d35a9fdfeca797</Hash>
</Codenesium>*/