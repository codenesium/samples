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
	public abstract class AbstractBOProductModelProductDescriptionCulture: AbstractBOManager
	{
		private IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository;
		private IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator;
		private IBOLProductModelProductDescriptionCultureMapper productModelProductDescriptionCultureMapper;
		private ILogger logger;

		public AbstractBOProductModelProductDescriptionCulture(
			ILogger logger,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
			IBOLProductModelProductDescriptionCultureMapper productModelProductDescriptionCultureMapper)
			: base()

		{
			this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
			this.productModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
			this.productModelProductDescriptionCultureMapper = productModelProductDescriptionCultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productModelProductDescriptionCultureRepository.All(skip, take, orderClause);

			return this.productModelProductDescriptionCultureMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID)
		{
			var record = await productModelProductDescriptionCultureRepository.Get(productModelID);

			return this.productModelProductDescriptionCultureMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Create(
			ApiProductModelProductDescriptionCultureRequestModel model)
		{
			CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> response = new CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>(await this.productModelProductDescriptionCultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productModelProductDescriptionCultureMapper.MapModelToDTO(default (int), model);
				var record = await this.productModelProductDescriptionCultureRepository.Create(dto);

				response.SetRecord(this.productModelProductDescriptionCultureMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelProductDescriptionCultureModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				var dto = this.productModelProductDescriptionCultureMapper.MapModelToDTO(productModelID, model);
				await this.productModelProductDescriptionCultureRepository.Update(productModelID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.productModelProductDescriptionCultureModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				await this.productModelProductDescriptionCultureRepository.Delete(productModelID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b8bfc1dacf93ec56418ba184ef65bbae</Hash>
</Codenesium>*/