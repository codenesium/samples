using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductPhotoService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IProductPhotoRepository ProductPhotoRepository { get; private set; }

		protected IApiProductPhotoServerRequestModelValidator ProductPhotoModelValidator { get; private set; }

		protected IDALProductPhotoMapper DalProductPhotoMapper { get; private set; }

		protected IDALProductProductPhotoMapper DalProductProductPhotoMapper { get; private set; }

		private ILogger logger;

		public AbstractProductPhotoService(
			ILogger logger,
			MediatR.IMediator mediator,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoServerRequestModelValidator productPhotoModelValidator,
			IDALProductPhotoMapper dalProductPhotoMapper,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper)
			: base()
		{
			this.ProductPhotoRepository = productPhotoRepository;
			this.ProductPhotoModelValidator = productPhotoModelValidator;
			this.DalProductPhotoMapper = dalProductPhotoMapper;
			this.DalProductProductPhotoMapper = dalProductProductPhotoMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductPhotoServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ProductPhoto> records = await this.ProductPhotoRepository.All(limit, offset, query);

			return this.DalProductPhotoMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiProductPhotoServerResponseModel> Get(int productPhotoID)
		{
			ProductPhoto record = await this.ProductPhotoRepository.Get(productPhotoID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductPhotoMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductPhotoServerResponseModel>> Create(
			ApiProductPhotoServerRequestModel model)
		{
			CreateResponse<ApiProductPhotoServerResponseModel> response = ValidationResponseFactory<ApiProductPhotoServerResponseModel>.CreateResponse(await this.ProductPhotoModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ProductPhoto record = this.DalProductPhotoMapper.MapModelToEntity(default(int), model);
				record = await this.ProductPhotoRepository.Create(record);

				response.SetRecord(this.DalProductPhotoMapper.MapEntityToModel(record));
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
				ProductPhoto record = this.DalProductPhotoMapper.MapModelToEntity(productPhotoID, model);
				await this.ProductPhotoRepository.Update(record);

				record = await this.ProductPhotoRepository.Get(productPhotoID);

				ApiProductPhotoServerResponseModel apiModel = this.DalProductPhotoMapper.MapEntityToModel(record);
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

		public async virtual Task<List<ApiProductProductPhotoServerResponseModel>> ProductProductPhotoesByProductPhotoID(int productPhotoID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductProductPhoto> records = await this.ProductPhotoRepository.ProductProductPhotoesByProductPhotoID(productPhotoID, limit, offset);

			return this.DalProductProductPhotoMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>874b46661525f8a8598f414d464ea8ea</Hash>
</Codenesium>*/