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
		protected IProductCategoryRepository ProductCategoryRepository { get; private set; }

		protected IApiProductCategoryServerRequestModelValidator ProductCategoryModelValidator { get; private set; }

		protected IBOLProductCategoryMapper BolProductCategoryMapper { get; private set; }

		protected IDALProductCategoryMapper DalProductCategoryMapper { get; private set; }

		protected IBOLProductSubcategoryMapper BolProductSubcategoryMapper { get; private set; }

		protected IDALProductSubcategoryMapper DalProductSubcategoryMapper { get; private set; }

		private ILogger logger;

		public AbstractProductCategoryService(
			ILogger logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryServerRequestModelValidator productCategoryModelValidator,
			IBOLProductCategoryMapper bolProductCategoryMapper,
			IDALProductCategoryMapper dalProductCategoryMapper,
			IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper)
			: base()
		{
			this.ProductCategoryRepository = productCategoryRepository;
			this.ProductCategoryModelValidator = productCategoryModelValidator;
			this.BolProductCategoryMapper = bolProductCategoryMapper;
			this.DalProductCategoryMapper = dalProductCategoryMapper;
			this.BolProductSubcategoryMapper = bolProductSubcategoryMapper;
			this.DalProductSubcategoryMapper = dalProductSubcategoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductCategoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductCategoryRepository.All(limit, offset);

			return this.BolProductCategoryMapper.MapBOToModel(this.DalProductCategoryMapper.MapEFToBO(records));
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
				return this.BolProductCategoryMapper.MapBOToModel(this.DalProductCategoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductCategoryServerResponseModel>> Create(
			ApiProductCategoryServerRequestModel model)
		{
			CreateResponse<ApiProductCategoryServerResponseModel> response = ValidationResponseFactory<ApiProductCategoryServerResponseModel>.CreateResponse(await this.ProductCategoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolProductCategoryMapper.MapModelToBO(default(int), model);
				var record = await this.ProductCategoryRepository.Create(this.DalProductCategoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductCategoryMapper.MapBOToModel(this.DalProductCategoryMapper.MapEFToBO(record)));
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
				var bo = this.BolProductCategoryMapper.MapModelToBO(productCategoryID, model);
				await this.ProductCategoryRepository.Update(this.DalProductCategoryMapper.MapBOToEF(bo));

				var record = await this.ProductCategoryRepository.Get(productCategoryID);

				return ValidationResponseFactory<ApiProductCategoryServerResponseModel>.UpdateResponse(this.BolProductCategoryMapper.MapBOToModel(this.DalProductCategoryMapper.MapEFToBO(record)));
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
				return this.BolProductCategoryMapper.MapBOToModel(this.DalProductCategoryMapper.MapEFToBO(record));
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
				return this.BolProductCategoryMapper.MapBOToModel(this.DalProductCategoryMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiProductSubcategoryServerResponseModel>> ProductSubcategoriesByProductCategoryID(int productCategoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductSubcategory> records = await this.ProductCategoryRepository.ProductSubcategoriesByProductCategoryID(productCategoryID, limit, offset);

			return this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>eb8ee775b0f928b90960c38223f574e0</Hash>
</Codenesium>*/