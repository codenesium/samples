using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractWorkOrderService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IWorkOrderRepository WorkOrderRepository { get; private set; }

		protected IApiWorkOrderServerRequestModelValidator WorkOrderModelValidator { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		private ILogger logger;

		public AbstractWorkOrderService(
			ILogger logger,
			MediatR.IMediator mediator,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderServerRequestModelValidator workOrderModelValidator,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base()
		{
			this.WorkOrderRepository = workOrderRepository;
			this.WorkOrderModelValidator = workOrderModelValidator;
			this.DalWorkOrderMapper = dalWorkOrderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiWorkOrderServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<WorkOrder> records = await this.WorkOrderRepository.All(limit, offset, query);

			return this.DalWorkOrderMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiWorkOrderServerResponseModel> Get(int workOrderID)
		{
			WorkOrder record = await this.WorkOrderRepository.Get(workOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalWorkOrderMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiWorkOrderServerResponseModel>> Create(
			ApiWorkOrderServerRequestModel model)
		{
			CreateResponse<ApiWorkOrderServerResponseModel> response = ValidationResponseFactory<ApiWorkOrderServerResponseModel>.CreateResponse(await this.WorkOrderModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				WorkOrder record = this.DalWorkOrderMapper.MapModelToEntity(default(int), model);
				record = await this.WorkOrderRepository.Create(record);

				response.SetRecord(this.DalWorkOrderMapper.MapEntityToModel(record));
				await this.mediator.Publish(new WorkOrderCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiWorkOrderServerResponseModel>> Update(
			int workOrderID,
			ApiWorkOrderServerRequestModel model)
		{
			var validationResult = await this.WorkOrderModelValidator.ValidateUpdateAsync(workOrderID, model);

			if (validationResult.IsValid)
			{
				WorkOrder record = this.DalWorkOrderMapper.MapModelToEntity(workOrderID, model);
				await this.WorkOrderRepository.Update(record);

				record = await this.WorkOrderRepository.Get(workOrderID);

				ApiWorkOrderServerResponseModel apiModel = this.DalWorkOrderMapper.MapEntityToModel(record);
				await this.mediator.Publish(new WorkOrderUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiWorkOrderServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiWorkOrderServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int workOrderID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.WorkOrderModelValidator.ValidateDeleteAsync(workOrderID));

			if (response.Success)
			{
				await this.WorkOrderRepository.Delete(workOrderID);

				await this.mediator.Publish(new WorkOrderDeletedNotification(workOrderID));
			}

			return response;
		}

		public async virtual Task<List<ApiWorkOrderServerResponseModel>> ByProductID(int productID, int limit = 0, int offset = int.MaxValue)
		{
			List<WorkOrder> records = await this.WorkOrderRepository.ByProductID(productID, limit, offset);

			return this.DalWorkOrderMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiWorkOrderServerResponseModel>> ByScrapReasonID(short? scrapReasonID, int limit = 0, int offset = int.MaxValue)
		{
			List<WorkOrder> records = await this.WorkOrderRepository.ByScrapReasonID(scrapReasonID, limit, offset);

			return this.DalWorkOrderMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>d8cdc71187e75e10eb51c0219cc8ac80</Hash>
</Codenesium>*/