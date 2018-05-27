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
	public abstract class AbstractBOProductSubcategory: AbstractBOManager
	{
		private IProductSubcategoryRepository productSubcategoryRepository;
		private IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator;
		private IBOLProductSubcategoryMapper productSubcategoryMapper;
		private ILogger logger;

		public AbstractBOProductSubcategory(
			ILogger logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
			IBOLProductSubcategoryMapper productSubcategoryMapper)
			: base()

		{
			this.productSubcategoryRepository = productSubcategoryRepository;
			this.productSubcategoryModelValidator = productSubcategoryModelValidator;
			this.productSubcategoryMapper = productSubcategoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductSubcategoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productSubcategoryRepository.All(skip, take, orderClause);

			return this.productSubcategoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductSubcategoryResponseModel> Get(int productSubcategoryID)
		{
			var record = await productSubcategoryRepository.Get(productSubcategoryID);

			return this.productSubcategoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductSubcategoryResponseModel>> Create(
			ApiProductSubcategoryRequestModel model)
		{
			CreateResponse<ApiProductSubcategoryResponseModel> response = new CreateResponse<ApiProductSubcategoryResponseModel>(await this.productSubcategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productSubcategoryMapper.MapModelToDTO(default (int), model);
				var record = await this.productSubcategoryRepository.Create(dto);

				response.SetRecord(this.productSubcategoryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productSubcategoryID,
			ApiProductSubcategoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateUpdateAsync(productSubcategoryID, model));

			if (response.Success)
			{
				var dto = this.productSubcategoryMapper.MapModelToDTO(productSubcategoryID, model);
				await this.productSubcategoryRepository.Update(productSubcategoryID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productSubcategoryID)
		{
			ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateDeleteAsync(productSubcategoryID));

			if (response.Success)
			{
				await this.productSubcategoryRepository.Delete(productSubcategoryID);
			}
			return response;
		}

		public async Task<ApiProductSubcategoryResponseModel> GetName(string name)
		{
			DTOProductSubcategory record = await this.productSubcategoryRepository.GetName(name);

			return this.productSubcategoryMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>12403cd06ce1a1bd09388c9f3913217b</Hash>
</Codenesium>*/