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
	public abstract class AbstractBOProductListPriceHistory: AbstractBOManager
	{
		private IProductListPriceHistoryRepository productListPriceHistoryRepository;
		private IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator;
		private IBOLProductListPriceHistoryMapper productListPriceHistoryMapper;
		private ILogger logger;

		public AbstractBOProductListPriceHistory(
			ILogger logger,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator,
			IBOLProductListPriceHistoryMapper productListPriceHistoryMapper)
			: base()

		{
			this.productListPriceHistoryRepository = productListPriceHistoryRepository;
			this.productListPriceHistoryModelValidator = productListPriceHistoryModelValidator;
			this.productListPriceHistoryMapper = productListPriceHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productListPriceHistoryRepository.All(skip, take, orderClause);

			return this.productListPriceHistoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductListPriceHistoryResponseModel> Get(int productID)
		{
			var record = await productListPriceHistoryRepository.Get(productID);

			return this.productListPriceHistoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductListPriceHistoryResponseModel>> Create(
			ApiProductListPriceHistoryRequestModel model)
		{
			CreateResponse<ApiProductListPriceHistoryResponseModel> response = new CreateResponse<ApiProductListPriceHistoryResponseModel>(await this.productListPriceHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productListPriceHistoryMapper.MapModelToDTO(default (int), model);
				var record = await this.productListPriceHistoryRepository.Create(dto);

				response.SetRecord(this.productListPriceHistoryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductListPriceHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productListPriceHistoryModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				var dto = this.productListPriceHistoryMapper.MapModelToDTO(productID, model);
				await this.productListPriceHistoryRepository.Update(productID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productListPriceHistoryModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productListPriceHistoryRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2b2a8dc5136da0e3b95e7307780a948d</Hash>
</Codenesium>*/