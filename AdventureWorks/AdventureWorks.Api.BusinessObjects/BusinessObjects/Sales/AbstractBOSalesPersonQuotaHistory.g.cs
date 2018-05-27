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
	public abstract class AbstractBOSalesPersonQuotaHistory: AbstractBOManager
	{
		private ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository;
		private IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator;
		private IBOLSalesPersonQuotaHistoryMapper salesPersonQuotaHistoryMapper;
		private ILogger logger;

		public AbstractBOSalesPersonQuotaHistory(
			ILogger logger,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator,
			IBOLSalesPersonQuotaHistoryMapper salesPersonQuotaHistoryMapper)
			: base()

		{
			this.salesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
			this.salesPersonQuotaHistoryModelValidator = salesPersonQuotaHistoryModelValidator;
			this.salesPersonQuotaHistoryMapper = salesPersonQuotaHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesPersonQuotaHistoryRepository.All(skip, take, orderClause);

			return this.salesPersonQuotaHistoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await salesPersonQuotaHistoryRepository.Get(businessEntityID);

			return this.salesPersonQuotaHistoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Create(
			ApiSalesPersonQuotaHistoryRequestModel model)
		{
			CreateResponse<ApiSalesPersonQuotaHistoryResponseModel> response = new CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>(await this.salesPersonQuotaHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.salesPersonQuotaHistoryMapper.MapModelToDTO(default (int), model);
				var record = await this.salesPersonQuotaHistoryRepository.Create(dto);

				response.SetRecord(this.salesPersonQuotaHistoryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.salesPersonQuotaHistoryMapper.MapModelToDTO(businessEntityID, model);
				await this.salesPersonQuotaHistoryRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.salesPersonQuotaHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f3ce11cc9d03bb7b679d4082dfa12c98</Hash>
</Codenesium>*/