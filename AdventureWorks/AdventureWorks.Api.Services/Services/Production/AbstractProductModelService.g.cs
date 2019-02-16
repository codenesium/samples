using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductModelService : AbstractService
	{
		private IMediator mediator;

		protected IProductModelRepository ProductModelRepository { get; private set; }

		protected IApiProductModelServerRequestModelValidator ProductModelModelValidator { get; private set; }

		protected IDALProductModelMapper DalProductModelMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		private ILogger logger;

		public AbstractProductModelService(
			ILogger logger,
			IMediator mediator,
			IProductModelRepository productModelRepository,
			IApiProductModelServerRequestModelValidator productModelModelValidator,
			IDALProductModelMapper dalProductModelMapper,
			IDALProductMapper dalProductMapper)
			: base()
		{
			this.ProductModelRepository = productModelRepository;
			this.ProductModelModelValidator = productModelModelValidator;
			this.DalProductModelMapper = dalProductModelMapper;
			this.DalProductMapper = dalProductMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductModelServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.ProductModelRepository.All(limit, offset, query);

			return this.DalProductModelMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiProductModelServerResponseModel> Get(int productModelID)
		{
			var record = await this.ProductModelRepository.Get(productModelID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductModelMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductModelServerResponseModel>> Create(
			ApiProductModelServerRequestModel model)
		{
			CreateResponse<ApiProductModelServerResponseModel> response = ValidationResponseFactory<ApiProductModelServerResponseModel>.CreateResponse(await this.ProductModelModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalProductModelMapper.MapModelToBO(default(int), model);
				var record = await this.ProductModelRepository.Create(bo);

				response.SetRecord(this.DalProductModelMapper.MapBOToModel(record));
				await this.mediator.Publish(new ProductModelCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductModelServerResponseModel>> Update(
			int productModelID,
			ApiProductModelServerRequestModel model)
		{
			var validationResult = await this.ProductModelModelValidator.ValidateUpdateAsync(productModelID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalProductModelMapper.MapModelToBO(productModelID, model);
				await this.ProductModelRepository.Update(bo);

				var record = await this.ProductModelRepository.Get(productModelID);

				var apiModel = this.DalProductModelMapper.MapBOToModel(record);
				await this.mediator.Publish(new ProductModelUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProductModelServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiProductModelServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductModelModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				await this.ProductModelRepository.Delete(productModelID);

				await this.mediator.Publish(new ProductModelDeletedNotification(productModelID));
			}

			return response;
		}

		public async virtual Task<ApiProductModelServerResponseModel> ByName(string name)
		{
			ProductModel record = await this.ProductModelRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductModelMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<ApiProductModelServerResponseModel> ByRowguid(Guid rowguid)
		{
			ProductModel record = await this.ProductModelRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductModelMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiProductModelServerResponseModel>> ByCatalogDescription(string catalogDescription, int limit = 0, int offset = int.MaxValue)
		{
			List<ProductModel> records = await this.ProductModelRepository.ByCatalogDescription(catalogDescription, limit, offset);

			return this.DalProductModelMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiProductModelServerResponseModel>> ByInstruction(string instruction, int limit = 0, int offset = int.MaxValue)
		{
			List<ProductModel> records = await this.ProductModelRepository.ByInstruction(instruction, limit, offset);

			return this.DalProductModelMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiProductServerResponseModel>> ProductsByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.ProductModelRepository.ProductsByProductModelID(productModelID, limit, offset);

			return this.DalProductMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>8dfedb8598e072f548fb1fe569bae5d1</Hash>
</Codenesium>*/