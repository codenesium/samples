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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOProductCategory: AbstractBOManager
	{
		private IProductCategoryRepository productCategoryRepository;
		private IApiProductCategoryRequestModelValidator productCategoryModelValidator;
		private IBOLProductCategoryMapper productCategoryMapper;
		private ILogger logger;

		public AbstractBOProductCategory(
			ILogger logger,
			IProductCategoryRepository productCategoryRepository,
			IApiProductCategoryRequestModelValidator productCategoryModelValidator,
			IBOLProductCategoryMapper productCategoryMapper)
			: base()

		{
			this.productCategoryRepository = productCategoryRepository;
			this.productCategoryModelValidator = productCategoryModelValidator;
			this.productCategoryMapper = productCategoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductCategoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productCategoryRepository.All(skip, take, orderClause);

			return this.productCategoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductCategoryResponseModel> Get(int productCategoryID)
		{
			var record = await productCategoryRepository.Get(productCategoryID);

			return this.productCategoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductCategoryResponseModel>> Create(
			ApiProductCategoryRequestModel model)
		{
			CreateResponse<ApiProductCategoryResponseModel> response = new CreateResponse<ApiProductCategoryResponseModel>(await this.productCategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productCategoryMapper.MapModelToDTO(default (int), model);
				var record = await this.productCategoryRepository.Create(dto);

				response.SetRecord(this.productCategoryMapper.MapDTOToModel(record));
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
				var dto = this.productCategoryMapper.MapModelToDTO(productCategoryID, model);
				await this.productCategoryRepository.Update(productCategoryID, dto);
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
			DTOProductCategory record = await this.productCategoryRepository.GetName(name);

			return this.productCategoryMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>3479846f9b31c6a3efd0c61aada67e92</Hash>
</Codenesium>*/