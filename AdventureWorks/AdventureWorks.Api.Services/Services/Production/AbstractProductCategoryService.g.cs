using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductCategoryService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IProductCategoryRepository ProductCategoryRepository { get; private set; }

		protected IApiProductCategoryServerRequestModelValidator ProductCategoryModelValidator { get; private set; }

		protected IDALProductCategoryMapper DalProductCategoryMapper { get; private set; }

		protected IDALProductSubcategoryMapper DalProductSubcategoryMapper { get; private set; }

		private ILogger logger;

		public AbstractProductCategoryService(
			ILogger logger,
			MediatR.IMediator mediator,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryServerRequestModelValidator productCategoryModelValidator,
			IDALProductCategoryMapper dalProductCategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper)
			: base()
		{
			this.ProductCategoryRepository = productCategoryRepository;
			this.ProductCategoryModelValidator = productCategoryModelValidator;
			this.DalProductCategoryMapper = dalProductCategoryMapper;
			this.DalProductSubcategoryMapper = dalProductSubcategoryMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductCategoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ProductCategory> records = await this.ProductCategoryRepository.All(limit, offset, query);

			return this.DalProductCategoryMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiProductCategoryServerResponseModel> Get(int productCategoryID)
		{
			ProductCategory record = await this.ProductCategoryRepository.Get(productCategoryID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductCategoryMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductCategoryServerResponseModel>> Create(
			ApiProductCategoryServerRequestModel model)
		{
			CreateResponse<ApiProductCategoryServerResponseModel> response = ValidationResponseFactory<ApiProductCategoryServerResponseModel>.CreateResponse(await this.ProductCategoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ProductCategory record = this.DalProductCategoryMapper.MapModelToEntity(default(int), model);
				record = await this.ProductCategoryRepository.Create(record);

				response.SetRecord(this.DalProductCategoryMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ProductCategoryCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductCategoryServerResponseModel>> Update(
			int productCategoryID,
			ApiProductCategoryServerRequestModel model)
		{
			var validationResult = await this.ProductCategoryModelValidator.ValidateUpdateAsync(productCategoryID, model);

			if (validationResult.IsValid)
			{
				ProductCategory record = this.DalProductCategoryMapper.MapModelToEntity(productCategoryID, model);
				await this.ProductCategoryRepository.Update(record);

				record = await this.ProductCategoryRepository.Get(productCategoryID);

				ApiProductCategoryServerResponseModel apiModel = this.DalProductCategoryMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ProductCategoryUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProductCategoryServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiProductCategoryServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productCategoryID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductCategoryModelValidator.ValidateDeleteAsync(productCategoryID));

			if (response.Success)
			{
				await this.ProductCategoryRepository.Delete(productCategoryID);

				await this.mediator.Publish(new ProductCategoryDeletedNotification(productCategoryID));
			}

			return response;
		}

		public async virtual Task<ApiProductCategoryServerResponseModel> ByName(string name)
		{
			ProductCategory record = await this.ProductCategoryRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductCategoryMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<ApiProductCategoryServerResponseModel> ByRowguid(Guid rowguid)
		{
			ProductCategory record = await this.ProductCategoryRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductCategoryMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiProductSubcategoryServerResponseModel>> ProductSubcategoriesByProductCategoryID(int productCategoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductSubcategory> records = await this.ProductCategoryRepository.ProductSubcategoriesByProductCategoryID(productCategoryID, limit, offset);

			return this.DalProductSubcategoryMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f966092559b69f2cd83066d0af2b6d9e</Hash>
</Codenesium>*/