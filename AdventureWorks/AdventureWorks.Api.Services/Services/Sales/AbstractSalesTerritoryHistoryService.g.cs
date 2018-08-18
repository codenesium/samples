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
		protected ISalesTerritoryHistoryRepository SalesTerritoryHistoryRepository { get; private set; }

		protected IApiSalesTerritoryHistoryRequestModelValidator SalesTerritoryHistoryModelValidator { get; private set; }

		protected IBOLSalesTerritoryHistoryMapper BolSalesTerritoryHistoryMapper { get; private set; }

		protected IDALSalesTerritoryHistoryMapper DalSalesTerritoryHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesTerritoryHistoryService(
			ILogger logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
			IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper)
			: base()
		{
			this.SalesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
			this.SalesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
			this.BolSalesTerritoryHistoryMapper = bolSalesTerritoryHistoryMapper;
			this.DalSalesTerritoryHistoryMapper = dalSalesTerritoryHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesTerritoryHistoryRepository.All(limit, offset);

			return this.BolSalesTerritoryHistoryMapper.MapBOToModel(this.DalSalesTerritoryHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await this.SalesTerritoryHistoryRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesTerritoryHistoryMapper.MapBOToModel(this.DalSalesTerritoryHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> Create(
			ApiSalesTerritoryHistoryRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryHistoryResponseModel> response = new CreateResponse<ApiSalesTerritoryHistoryResponseModel>(await this.SalesTerritoryHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSalesTerritoryHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.SalesTerritoryHistoryRepository.Create(this.DalSalesTerritoryHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesTerritoryHistoryMapper.MapBOToModel(this.DalSalesTerritoryHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesTerritoryHistoryResponseModel>> Update(
			int businessEntityID,
			ApiSalesTerritoryHistoryRequestModel model)
		{
			var validationResult = await this.SalesTerritoryHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesTerritoryHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.SalesTerritoryHistoryRepository.Update(this.DalSalesTerritoryHistoryMapper.MapBOToEF(bo));

				var record = await this.SalesTerritoryHistoryRepository.Get(businessEntityID);

				return new UpdateResponse<ApiSalesTerritoryHistoryResponseModel>(this.BolSalesTerritoryHistoryMapper.MapBOToModel(this.DalSalesTerritoryHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesTerritoryHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.SalesTerritoryHistoryModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.SalesTerritoryHistoryRepository.Delete(businessEntityID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d0a14c94b82a6e6ef04b53165ec16bd5</Hash>
</Codenesium>*/