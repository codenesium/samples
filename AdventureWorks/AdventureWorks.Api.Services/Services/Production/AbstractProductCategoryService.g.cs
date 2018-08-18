using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductCategoryService : AbstractService
	{
		protected IProductCategoryRepository ProductCategoryRepository { get; private set; }

		protected IApiProductCategoryRequestModelValidator ProductCategoryModelValidator { get; private set; }

		protected IBOLProductCategoryMapper BolProductCategoryMapper { get; private set; }

		protected IDALProductCategoryMapper DalProductCategoryMapper { get; private set; }

		protected IBOLProductSubcategoryMapper BolProductSubcategoryMapper { get; private set; }

		protected IDALProductSubcategoryMapper DalProductSubcategoryMapper { get; private set; }

		private ILogger logger;

		public AbstractProductCategoryService(
			ILogger logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryRequestModelValidator productCategoryModelValidator,
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

		public virtual async Task<List<ApiProductCategoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductCategoryRepository.All(limit, offset);

			return this.BolProductCategoryMapper.MapBOToModel(this.DalProductCategoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductCategoryResponseModel> Get(int productCategoryID)
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

		public virtual async Task<CreateResponse<ApiProductCategoryResponseModel>> Create(
			ApiProductCategoryRequestModel model)
		{
			CreateResponse<ApiProductCategoryResponseModel> response = new CreateResponse<ApiProductCategoryResponseModel>(await this.ProductCategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductCategoryMapper.MapModelToBO(default(int), model);
				var record = await this.ProductCategoryRepository.Create(this.DalProductCategoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductCategoryMapper.MapBOToModel(this.DalProductCategoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductCategoryResponseModel>> Update(
			int productCategoryID,
			ApiProductCategoryRequestModel model)
		{
			var validationResult = await this.ProductCategoryModelValidator.ValidateUpdateAsync(productCategoryID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductCategoryMapper.MapModelToBO(productCategoryID, model);
				await this.ProductCategoryRepository.Update(this.DalProductCategoryMapper.MapBOToEF(bo));

				var record = await this.ProductCategoryRepository.Get(productCategoryID);

				return new UpdateResponse<ApiProductCategoryResponseModel>(this.BolProductCategoryMapper.MapBOToModel(this.DalProductCategoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductCategoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productCategoryID)
		{
			ActionResponse response = new ActionResponse(await this.ProductCategoryModelValidator.ValidateDeleteAsync(productCategoryID));
			if (response.Success)
			{
				await this.ProductCategoryRepository.Delete(productCategoryID);
			}

			return response;
		}

		public async Task<ApiProductCategoryResponseModel> ByName(string name)
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

		public async virtual Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategories(int productCategoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductSubcategory> records = await this.ProductCategoryRepository.ProductSubcategories(productCategoryID, limit, offset);

			return this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5cd79ca99024c2cb1315fbc7975cf1b1</Hash>
</Codenesium>*/