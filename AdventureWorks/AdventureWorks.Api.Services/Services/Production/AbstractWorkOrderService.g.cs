using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractWorkOrderService : AbstractService
	{
		private IMediator mediator;

		protected IWorkOrderRepository WorkOrderRepository { get; private set; }

		protected IApiWorkOrderServerRequestModelValidator WorkOrderModelValidator { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		private ILogger logger;

		public AbstractWorkOrderService(
			ILogger logger,
			IMediator mediator,
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
			var records = await this.WorkOrderRepository.All(limit, offset, query);

			return this.DalWorkOrderMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiWorkOrderServerResponseModel> Get(int workOrderID)
		{
			var record = await this.WorkOrderRepository.Get(workOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalWorkOrderMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiWorkOrderServerResponseModel>> Create(
			ApiWorkOrderServerRequestModel model)
		{
			CreateResponse<ApiWorkOrderServerResponseModel> response = ValidationResponseFactory<ApiWorkOrderServerResponseModel>.CreateResponse(await this.WorkOrderModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalWorkOrderMapper.MapModelToBO(default(int), model);
				var record = await this.WorkOrderRepository.Create(bo);

				response.SetRecord(this.DalWorkOrderMapper.MapBOToModel(record));
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
				var bo = this.DalWorkOrderMapper.MapModelToBO(workOrderID, model);
				await this.WorkOrderRepository.Update(bo);

				var record = await this.WorkOrderRepository.Get(workOrderID);

				var apiModel = this.DalWorkOrderMapper.MapBOToModel(record);
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

			return this.DalWorkOrderMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiWorkOrderServerResponseModel>> ByScrapReasonID(short? scrapReasonID, int limit = 0, int offset = int.MaxValue)
		{
			List<WorkOrder> records = await this.WorkOrderRepository.ByScrapReasonID(scrapReasonID, limit, offset);

			return this.DalWorkOrderMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>97672c0f660a360635a4f469e6d623cb</Hash>
</Codenesium>*/