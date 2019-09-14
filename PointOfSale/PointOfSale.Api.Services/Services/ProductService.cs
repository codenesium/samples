using Microsoft.Extensions.Logging;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public class ProductService : AbstractService, IProductService
	{
		private MediatR.IMediator mediator;

		protected IProductRepository ProductRepository { get; private set; }

		protected IApiProductServerRequestModelValidator ProductModelValidator { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		private ILogger logger;

		public ProductService(
			ILogger<IProductService> logger,
			MediatR.IMediator mediator,
			IProductRepository productRepository,
			IApiProductServerRequestModelValidator productModelValidator,
			IDALProductMapper dalProductMapper)
			: base()
		{
			this.ProductRepository = productRepository;
			this.ProductModelValidator = productModelValidator;
			this.DalProductMapper = dalProductMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Product> records = await this.ProductRepository.All(limit, offset, query);

			return this.DalProductMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiProductServerResponseModel> Get(int id)
		{
			Product record = await this.ProductRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductServerResponseModel>> Create(
			ApiProductServerRequestModel model)
		{
			CreateResponse<ApiProductServerResponseModel> response = ValidationResponseFactory<ApiProductServerResponseModel>.CreateResponse(await this.ProductModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Product record = this.DalProductMapper.MapModelToEntity(default(int), model);
				record = await this.ProductRepository.Create(record);

				response.SetRecord(this.DalProductMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ProductCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductServerResponseModel>> Update(
			int id,
			ApiProductServerRequestModel model)
		{
			var validationResult = await this.ProductModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Product record = this.DalProductMapper.MapModelToEntity(id, model);
				await this.ProductRepository.Update(record);

				record = await this.ProductRepository.Get(id);

				ApiProductServerResponseModel apiModel = this.DalProductMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ProductUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProductServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiProductServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.ProductRepository.Delete(id);

				await this.mediator.Publish(new ProductDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bc011ed1e266fd4fe7f5096a8a53b65a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/