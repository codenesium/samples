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
	public abstract class AbstractSalesPersonQuotaHistoryService : AbstractService
	{
		protected ISalesPersonQuotaHistoryRepository SalesPersonQuotaHistoryRepository { get; private set; }

		protected IApiSalesPersonQuotaHistoryRequestModelValidator SalesPersonQuotaHistoryModelValidator { get; private set; }

		protected IBOLSalesPersonQuotaHistoryMapper BolSalesPersonQuotaHistoryMapper { get; private set; }

		protected IDALSalesPersonQuotaHistoryMapper DalSalesPersonQuotaHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesPersonQuotaHistoryService(
			ILogger logger,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator,
			IBOLSalesPersonQuotaHistoryMapper bolSalesPersonQuotaHistoryMapper,
			IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper)
			: base()
		{
			this.SalesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
			this.SalesPersonQuotaHistoryModelValidator = salesPersonQuotaHistoryModelValidator;
			this.BolSalesPersonQuotaHistoryMapper = bolSalesPersonQuotaHistoryMapper;
			this.DalSalesPersonQuotaHistoryMapper = dalSalesPersonQuotaHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesPersonQuotaHistoryRepository.All(limit, offset);

			return this.BolSalesPersonQuotaHistoryMapper.MapBOToModel(this.DalSalesPersonQuotaHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await this.SalesPersonQuotaHistoryRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesPersonQuotaHistoryMapper.MapBOToModel(this.DalSalesPersonQuotaHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Create(
			ApiSalesPersonQuotaHistoryRequestModel model)
		{
			CreateResponse<ApiSalesPersonQuotaHistoryResponseModel> response = new CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>(await this.SalesPersonQuotaHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSalesPersonQuotaHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.SalesPersonQuotaHistoryRepository.Create(this.DalSalesPersonQuotaHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesPersonQuotaHistoryMapper.MapBOToModel(this.DalSalesPersonQuotaHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Update(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel model)
		{
			var validationResult = await this.SalesPersonQuotaHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesPersonQuotaHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.SalesPersonQuotaHistoryRepository.Update(this.DalSalesPersonQuotaHistoryMapper.MapBOToEF(bo));

				var record = await this.SalesPersonQuotaHistoryRepository.Get(businessEntityID);

				return new UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>(this.BolSalesPersonQuotaHistoryMapper.MapBOToModel(this.DalSalesPersonQuotaHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.SalesPersonQuotaHistoryModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.SalesPersonQuotaHistoryRepository.Delete(businessEntityID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6e4bc75663ea13e26c852edb066eea52</Hash>
</Codenesium>*/