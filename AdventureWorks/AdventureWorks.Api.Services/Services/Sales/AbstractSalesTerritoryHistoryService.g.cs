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
	public abstract class AbstractSalesTerritoryHistoryService : AbstractService
	{
		private ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository;

		private IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator;

		private IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper;

		private IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper;

		private ILogger logger;

		public AbstractSalesTerritoryHistoryService(
			ILogger logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
			IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper)
			: base()
		{
			this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
			this.salesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
			this.bolSalesTerritoryHistoryMapper = bolSalesTerritoryHistoryMapper;
			this.dalSalesTerritoryHistoryMapper = dalSalesTerritoryHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.salesTerritoryHistoryRepository.All(limit, offset);

			return this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await this.salesTerritoryHistoryRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> Create(
			ApiSalesTerritoryHistoryRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryHistoryResponseModel> response = new CreateResponse<ApiSalesTerritoryHistoryResponseModel>(await this.salesTerritoryHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolSalesTerritoryHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.salesTerritoryHistoryRepository.Create(this.dalSalesTerritoryHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesTerritoryHistoryResponseModel>> Update(
			int businessEntityID,
			ApiSalesTerritoryHistoryRequestModel model)
		{
			var validationResult = await this.salesTerritoryHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolSalesTerritoryHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.salesTerritoryHistoryRepository.Update(this.dalSalesTerritoryHistoryMapper.MapBOToEF(bo));

				var record = await this.salesTerritoryHistoryRepository.Get(businessEntityID);

				return new UpdateResponse<ApiSalesTerritoryHistoryResponseModel>(this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesTerritoryHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryHistoryModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.salesTerritoryHistoryRepository.Delete(businessEntityID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1ca70f011affe6a15756474bedcdfe2b</Hash>
</Codenesium>*/