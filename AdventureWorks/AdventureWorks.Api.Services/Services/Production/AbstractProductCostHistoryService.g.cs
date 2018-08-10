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
	public abstract class AbstractProductCostHistoryService : AbstractService
	{
		protected IProductCostHistoryRepository ProductCostHistoryRepository { get; private set; }

		protected IApiProductCostHistoryRequestModelValidator ProductCostHistoryModelValidator { get; private set; }

		protected IBOLProductCostHistoryMapper BolProductCostHistoryMapper { get; private set; }

		protected IDALProductCostHistoryMapper DalProductCostHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractProductCostHistoryService(
			ILogger logger,
			IProductCostHistoryRepository productCostHistoryRepository,
			IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator,
			IBOLProductCostHistoryMapper bolProductCostHistoryMapper,
			IDALProductCostHistoryMapper dalProductCostHistoryMapper)
			: base()
		{
			this.ProductCostHistoryRepository = productCostHistoryRepository;
			this.ProductCostHistoryModelValidator = productCostHistoryModelValidator;
			this.BolProductCostHistoryMapper = bolProductCostHistoryMapper;
			this.DalProductCostHistoryMapper = dalProductCostHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductCostHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductCostHistoryRepository.All(limit, offset);

			return this.BolProductCostHistoryMapper.MapBOToModel(this.DalProductCostHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductCostHistoryResponseModel> Get(int productID)
		{
			var record = await this.ProductCostHistoryRepository.Get(productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductCostHistoryMapper.MapBOToModel(this.DalProductCostHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductCostHistoryResponseModel>> Create(
			ApiProductCostHistoryRequestModel model)
		{
			CreateResponse<ApiProductCostHistoryResponseModel> response = new CreateResponse<ApiProductCostHistoryResponseModel>(await this.ProductCostHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductCostHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.ProductCostHistoryRepository.Create(this.DalProductCostHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductCostHistoryMapper.MapBOToModel(this.DalProductCostHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductCostHistoryResponseModel>> Update(
			int productID,
			ApiProductCostHistoryRequestModel model)
		{
			var validationResult = await this.ProductCostHistoryModelValidator.ValidateUpdateAsync(productID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductCostHistoryMapper.MapModelToBO(productID, model);
				await this.ProductCostHistoryRepository.Update(this.DalProductCostHistoryMapper.MapBOToEF(bo));

				var record = await this.ProductCostHistoryRepository.Get(productID);

				return new UpdateResponse<ApiProductCostHistoryResponseModel>(this.BolProductCostHistoryMapper.MapBOToModel(this.DalProductCostHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductCostHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.ProductCostHistoryModelValidator.ValidateDeleteAsync(productID));
			if (response.Success)
			{
				await this.ProductCostHistoryRepository.Delete(productID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>afc11eeb1031796f738c267aaf729f9b</Hash>
</Codenesium>*/