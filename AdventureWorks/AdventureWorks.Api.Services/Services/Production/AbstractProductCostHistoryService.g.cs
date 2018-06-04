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
	public abstract class AbstractProductCostHistoryService: AbstractService
	{
		private IProductCostHistoryRepository productCostHistoryRepository;
		private IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator;
		private IBOLProductCostHistoryMapper BOLProductCostHistoryMapper;
		private IDALProductCostHistoryMapper DALProductCostHistoryMapper;
		private ILogger logger;

		public AbstractProductCostHistoryService(
			ILogger logger,
			IProductCostHistoryRepository productCostHistoryRepository,
			IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator,
			IBOLProductCostHistoryMapper bolproductCostHistoryMapper,
			IDALProductCostHistoryMapper dalproductCostHistoryMapper)
			: base()

		{
			this.productCostHistoryRepository = productCostHistoryRepository;
			this.productCostHistoryModelValidator = productCostHistoryModelValidator;
			this.BOLProductCostHistoryMapper = bolproductCostHistoryMapper;
			this.DALProductCostHistoryMapper = dalproductCostHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductCostHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productCostHistoryRepository.All(skip, take, orderClause);

			return this.BOLProductCostHistoryMapper.MapBOToModel(this.DALProductCostHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductCostHistoryResponseModel> Get(int productID)
		{
			var record = await productCostHistoryRepository.Get(productID);

			return this.BOLProductCostHistoryMapper.MapBOToModel(this.DALProductCostHistoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductCostHistoryResponseModel>> Create(
			ApiProductCostHistoryRequestModel model)
		{
			CreateResponse<ApiProductCostHistoryResponseModel> response = new CreateResponse<ApiProductCostHistoryResponseModel>(await this.productCostHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductCostHistoryMapper.MapModelToBO(default (int), model);
				var record = await this.productCostHistoryRepository.Create(this.DALProductCostHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductCostHistoryMapper.MapBOToModel(this.DALProductCostHistoryMapper.MapEFToBO(record)));
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
				var bo = this.BOLProductCostHistoryMapper.MapModelToBO(productID, model);
				await this.productCostHistoryRepository.Update(this.DALProductCostHistoryMapper.MapBOToEF(bo));
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
    <Hash>7edf8a1c2ad0af4403671f5b544eb9b9</Hash>
</Codenesium>*/