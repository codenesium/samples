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
	public abstract class AbstractBOWorkOrder: AbstractBOManager
	{
		private IWorkOrderRepository workOrderRepository;
		private IApiWorkOrderRequestModelValidator workOrderModelValidator;
		private IBOLWorkOrderMapper workOrderMapper;
		private ILogger logger;

		public AbstractBOWorkOrder(
			ILogger logger,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderRequestModelValidator workOrderModelValidator,
			IBOLWorkOrderMapper workOrderMapper)
			: base()

		{
			this.workOrderRepository = workOrderRepository;
			this.workOrderModelValidator = workOrderModelValidator;
			this.workOrderMapper = workOrderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.workOrderRepository.All(skip, take, orderClause);

			return this.workOrderMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiWorkOrderResponseModel> Get(int workOrderID)
		{
			var record = await workOrderRepository.Get(workOrderID);

			return this.workOrderMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
			ApiWorkOrderRequestModel model)
		{
			CreateResponse<ApiWorkOrderResponseModel> response = new CreateResponse<ApiWorkOrderResponseModel>(await this.workOrderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.workOrderMapper.MapModelToDTO(default (int), model);
				var record = await this.workOrderRepository.Create(dto);

				response.SetRecord(this.workOrderMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int workOrderID,
			ApiWorkOrderRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.workOrderModelValidator.ValidateUpdateAsync(workOrderID, model));

			if (response.Success)
			{
				var dto = this.workOrderMapper.MapModelToDTO(workOrderID, model);
				await this.workOrderRepository.Update(workOrderID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int workOrderID)
		{
			ActionResponse response = new ActionResponse(await this.workOrderModelValidator.ValidateDeleteAsync(workOrderID));

			if (response.Success)
			{
				await this.workOrderRepository.Delete(workOrderID);
			}
			return response;
		}

		public async Task<List<ApiWorkOrderResponseModel>> GetProductID(int productID)
		{
			List<DTOWorkOrder> records = await this.workOrderRepository.GetProductID(productID);

			return this.workOrderMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiWorkOrderResponseModel>> GetScrapReasonID(Nullable<short> scrapReasonID)
		{
			List<DTOWorkOrder> records = await this.workOrderRepository.GetScrapReasonID(scrapReasonID);

			return this.workOrderMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>124eb16b7900ceca6b9912bb4a589b09</Hash>
</Codenesium>*/