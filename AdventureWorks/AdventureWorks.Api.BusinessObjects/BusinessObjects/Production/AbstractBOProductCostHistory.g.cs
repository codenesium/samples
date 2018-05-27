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
	public abstract class AbstractBOProductCostHistory: AbstractBOManager
	{
		private IProductCostHistoryRepository productCostHistoryRepository;
		private IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator;
		private IBOLProductCostHistoryMapper productCostHistoryMapper;
		private ILogger logger;

		public AbstractBOProductCostHistory(
			ILogger logger,
			IProductCostHistoryRepository productCostHistoryRepository,
			IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator,
			IBOLProductCostHistoryMapper productCostHistoryMapper)
			: base()

		{
			this.productCostHistoryRepository = productCostHistoryRepository;
			this.productCostHistoryModelValidator = productCostHistoryModelValidator;
			this.productCostHistoryMapper = productCostHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductCostHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productCostHistoryRepository.All(skip, take, orderClause);

			return this.productCostHistoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductCostHistoryResponseModel> Get(int productID)
		{
			var record = await productCostHistoryRepository.Get(productID);

			return this.productCostHistoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductCostHistoryResponseModel>> Create(
			ApiProductCostHistoryRequestModel model)
		{
			CreateResponse<ApiProductCostHistoryResponseModel> response = new CreateResponse<ApiProductCostHistoryResponseModel>(await this.productCostHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productCostHistoryMapper.MapModelToDTO(default (int), model);
				var record = await this.productCostHistoryRepository.Create(dto);

				response.SetRecord(this.productCostHistoryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductCostHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productCostHistoryModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				var dto = this.productCostHistoryMapper.MapModelToDTO(productID, model);
				await this.productCostHistoryRepository.Update(productID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productCostHistoryModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productCostHistoryRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>05312047c85e3ba8418e39aace64a4bc</Hash>
</Codenesium>*/