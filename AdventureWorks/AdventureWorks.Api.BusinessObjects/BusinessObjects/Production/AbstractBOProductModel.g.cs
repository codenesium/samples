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
	public abstract class AbstractBOProductModel: AbstractBOManager
	{
		private IProductModelRepository productModelRepository;
		private IApiProductModelRequestModelValidator productModelModelValidator;
		private IBOLProductModelMapper productModelMapper;
		private ILogger logger;

		public AbstractBOProductModel(
			ILogger logger,
			IProductModelRepository productModelRepository,
			IApiProductModelRequestModelValidator productModelModelValidator,
			IBOLProductModelMapper productModelMapper)
			: base()

		{
			this.productModelRepository = productModelRepository;
			this.productModelModelValidator = productModelModelValidator;
			this.productModelMapper = productModelMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductModelResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productModelRepository.All(skip, take, orderClause);

			return this.productModelMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductModelResponseModel> Get(int productModelID)
		{
			var record = await productModelRepository.Get(productModelID);

			return this.productModelMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductModelResponseModel>> Create(
			ApiProductModelRequestModel model)
		{
			CreateResponse<ApiProductModelResponseModel> response = new CreateResponse<ApiProductModelResponseModel>(await this.productModelModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productModelMapper.MapModelToDTO(default (int), model);
				var record = await this.productModelRepository.Create(dto);

				response.SetRecord(this.productModelMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ApiProductModelRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				var dto = this.productModelMapper.MapModelToDTO(productModelID, model);
				await this.productModelRepository.Update(productModelID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.productModelModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				await this.productModelRepository.Delete(productModelID);
			}
			return response;
		}

		public async Task<ApiProductModelResponseModel> GetName(string name)
		{
			DTOProductModel record = await this.productModelRepository.GetName(name);

			return this.productModelMapper.MapDTOToModel(record);
		}
		public async Task<List<ApiProductModelResponseModel>> GetCatalogDescription(string catalogDescription)
		{
			List<DTOProductModel> records = await this.productModelRepository.GetCatalogDescription(catalogDescription);

			return this.productModelMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiProductModelResponseModel>> GetInstructions(string instructions)
		{
			List<DTOProductModel> records = await this.productModelRepository.GetInstructions(instructions);

			return this.productModelMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f5c85ed50c6a2cae87d9b0c7acc6d82c</Hash>
</Codenesium>*/