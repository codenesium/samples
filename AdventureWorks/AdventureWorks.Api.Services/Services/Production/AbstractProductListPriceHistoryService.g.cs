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
	public abstract class AbstractProductListPriceHistoryService: AbstractService
	{
		private IProductListPriceHistoryRepository productListPriceHistoryRepository;
		private IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator;
		private IBOLProductListPriceHistoryMapper BOLProductListPriceHistoryMapper;
		private IDALProductListPriceHistoryMapper DALProductListPriceHistoryMapper;
		private ILogger logger;

		public AbstractProductListPriceHistoryService(
			ILogger logger,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator,
			IBOLProductListPriceHistoryMapper bolproductListPriceHistoryMapper,
			IDALProductListPriceHistoryMapper dalproductListPriceHistoryMapper)
			: base()

		{
			this.productListPriceHistoryRepository = productListPriceHistoryRepository;
			this.productListPriceHistoryModelValidator = productListPriceHistoryModelValidator;
			this.BOLProductListPriceHistoryMapper = bolproductListPriceHistoryMapper;
			this.DALProductListPriceHistoryMapper = dalproductListPriceHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productListPriceHistoryRepository.All(skip, take, orderClause);

			return this.BOLProductListPriceHistoryMapper.MapBOToModel(this.DALProductListPriceHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductListPriceHistoryResponseModel> Get(int productID)
		{
			var record = await productListPriceHistoryRepository.Get(productID);

			return this.BOLProductListPriceHistoryMapper.MapBOToModel(this.DALProductListPriceHistoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductListPriceHistoryResponseModel>> Create(
			ApiProductListPriceHistoryRequestModel model)
		{
			CreateResponse<ApiProductListPriceHistoryResponseModel> response = new CreateResponse<ApiProductListPriceHistoryResponseModel>(await this.productListPriceHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductListPriceHistoryMapper.MapModelToBO(default (int), model);
				var record = await this.productListPriceHistoryRepository.Create(this.DALProductListPriceHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductListPriceHistoryMapper.MapBOToModel(this.DALProductListPriceHistoryMapper.MapEFToBO(record)));
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
				var bo = this.BOLProductListPriceHistoryMapper.MapModelToBO(productID, model);
				await this.productListPriceHistoryRepository.Update(this.DALProductListPriceHistoryMapper.MapBOToEF(bo));
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
    <Hash>0a329993b3d223b1268821b42539e77a</Hash>
</Codenesium>*/