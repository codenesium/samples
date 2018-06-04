using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductCategoryService: AbstractService
	{
		private IProductCategoryRepository productCategoryRepository;
		private IApiProductCategoryRequestModelValidator productCategoryModelValidator;
		private IBOLProductCategoryMapper BOLProductCategoryMapper;
		private IDALProductCategoryMapper DALProductCategoryMapper;
		private ILogger logger;

		public AbstractProductCategoryService(
			ILogger logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryRequestModelValidator productCategoryModelValidator,
			IBOLProductCategoryMapper bolproductCategoryMapper,
			IDALProductCategoryMapper dalproductCategoryMapper)
			: base()

		{
			this.productCategoryRepository = productCategoryRepository;
			this.productCategoryModelValidator = productCategoryModelValidator;
			this.BOLProductCategoryMapper = bolproductCategoryMapper;
			this.DALProductCategoryMapper = dalproductCategoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductCategoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productCategoryRepository.All(skip, take, orderClause);

			return this.BOLProductCategoryMapper.MapBOToModel(this.DALProductCategoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductCategoryResponseModel> Get(int productCategoryID)
		{
			var record = await productCategoryRepository.Get(productCategoryID);

			return this.BOLProductCategoryMapper.MapBOToModel(this.DALProductCategoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductCategoryResponseModel>> Create(
			ApiProductCategoryRequestModel model)
		{
			CreateResponse<ApiProductCategoryResponseModel> response = new CreateResponse<ApiProductCategoryResponseModel>(await this.productCategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductCategoryMapper.MapModelToBO(default (int), model);
				var record = await this.productCategoryRepository.Create(this.DALProductCategoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductCategoryMapper.MapBOToModel(this.DALProductCategoryMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productCategoryID,
			ApiProductCategoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productCategoryModelValidator.ValidateUpdateAsync(productCategoryID, model));

			if (response.Success)
			{
				var bo = this.BOLProductCategoryMapper.MapModelToBO(productCategoryID, model);
				await this.productCategoryRepository.Update(this.DALProductCategoryMapper.MapBOToEF(bo));
			}

			return response;
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

		public async Task<ApiProductCategoryResponseModel> GetName(string name)
		{
			ProductCategory record = await this.productCategoryRepository.GetName(name);

			return this.BOLProductCategoryMapper.MapBOToModel(this.DALProductCategoryMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>a1d557f02b83fee4d14c6996173da3f3</Hash>
</Codenesium>*/