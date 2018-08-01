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
		private IProductCategoryRepository productCategoryRepository;

		private IApiProductCategoryRequestModelValidator productCategoryModelValidator;

		private IBOLProductCategoryMapper bolProductCategoryMapper;

		private IDALProductCategoryMapper dalProductCategoryMapper;

		private IBOLProductSubcategoryMapper bolProductSubcategoryMapper;

		private IDALProductSubcategoryMapper dalProductSubcategoryMapper;

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
			this.productCategoryRepository = productCategoryRepository;
			this.productCategoryModelValidator = productCategoryModelValidator;
			this.bolProductCategoryMapper = bolProductCategoryMapper;
			this.dalProductCategoryMapper = dalProductCategoryMapper;
			this.bolProductSubcategoryMapper = bolProductSubcategoryMapper;
			this.dalProductSubcategoryMapper = dalProductSubcategoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductCategoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.productCategoryRepository.All(limit, offset);

			return this.bolProductCategoryMapper.MapBOToModel(this.dalProductCategoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductCategoryResponseModel> Get(int productCategoryID)
		{
			var record = await this.productCategoryRepository.Get(productCategoryID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolProductCategoryMapper.MapBOToModel(this.dalProductCategoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductCategoryResponseModel>> Create(
			ApiProductCategoryRequestModel model)
		{
			CreateResponse<ApiProductCategoryResponseModel> response = new CreateResponse<ApiProductCategoryResponseModel>(await this.productCategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolProductCategoryMapper.MapModelToBO(default(int), model);
				var record = await this.productCategoryRepository.Create(this.dalProductCategoryMapper.MapBOToEF(bo));

				response.SetRecord(this.bolProductCategoryMapper.MapBOToModel(this.dalProductCategoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductCategoryResponseModel>> Update(
			int productCategoryID,
			ApiProductCategoryRequestModel model)
		{
			var validationResult = await this.productCategoryModelValidator.ValidateUpdateAsync(productCategoryID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolProductCategoryMapper.MapModelToBO(productCategoryID, model);
				await this.productCategoryRepository.Update(this.dalProductCategoryMapper.MapBOToEF(bo));

				var record = await this.productCategoryRepository.Get(productCategoryID);

				return new UpdateResponse<ApiProductCategoryResponseModel>(this.bolProductCategoryMapper.MapBOToModel(this.dalProductCategoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductCategoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productCategoryID)
		{
			ActionResponse response = new ActionResponse(await this.productCategoryModelValidator.ValidateDeleteAsync(productCategoryID));
			if (response.Success)
			{
				await this.productCategoryRepository.Delete(productCategoryID);
			}

			return response;
		}

		public async Task<ApiProductCategoryResponseModel> ByName(string name)
		{
			ProductCategory record = await this.productCategoryRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolProductCategoryMapper.MapBOToModel(this.dalProductCategoryMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategories(int productCategoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductSubcategory> records = await this.productCategoryRepository.ProductSubcategories(productCategoryID, limit, offset);

			return this.bolProductSubcategoryMapper.MapBOToModel(this.dalProductSubcategoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>18f2d2ee7dae6eeb1b4615ac106f5cb9</Hash>
</Codenesium>*/