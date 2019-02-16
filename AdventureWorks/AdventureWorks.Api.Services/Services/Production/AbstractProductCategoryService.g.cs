using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductCategoryService : AbstractService
	{
		private IMediator mediator;

		protected IProductCategoryRepository ProductCategoryRepository { get; private set; }

		protected IApiProductCategoryServerRequestModelValidator ProductCategoryModelValidator { get; private set; }

		protected IDALProductCategoryMapper DalProductCategoryMapper { get; private set; }

		protected IDALProductSubcategoryMapper DalProductSubcategoryMapper { get; private set; }

		private ILogger logger;

		public AbstractProductCategoryService(
			ILogger logger,
			IMediator mediator,
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
			var records = await this.ProductCategoryRepository.All(limit, offset, query);

			return this.DalProductCategoryMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiProductCategoryServerResponseModel> Get(int productCategoryID)
		{
			var record = await this.ProductCategoryRepository.Get(productCategoryID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductCategoryMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductCategoryServerResponseModel>> Create(
			ApiProductCategoryServerRequestModel model)
		{
			CreateResponse<ApiProductCategoryServerResponseModel> response = ValidationResponseFactory<ApiProductCategoryServerResponseModel>.CreateResponse(await this.ProductCategoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalProductCategoryMapper.MapModelToBO(default(int), model);
				var record = await this.ProductCategoryRepository.Create(bo);

				response.SetRecord(this.DalProductCategoryMapper.MapBOToModel(record));
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
				var bo = this.DalProductCategoryMapper.MapModelToBO(productCategoryID, model);
				await this.ProductCategoryRepository.Update(bo);

				var record = await this.ProductCategoryRepository.Get(productCategoryID);

				var apiModel = this.DalProductCategoryMapper.MapBOToModel(record);
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
				return this.DalProductCategoryMapper.MapBOToModel(record);
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
				return this.DalProductCategoryMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiProductSubcategoryServerResponseModel>> ProductSubcategoriesByProductCategoryID(int productCategoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductSubcategory> records = await this.ProductCategoryRepository.ProductSubcategoriesByProductCategoryID(productCategoryID, limit, offset);

			return this.DalProductSubcategoryMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>a922f49881a431f7b856e21c874d0061</Hash>
</Codenesium>*/