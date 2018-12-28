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

		protected IBOLWorkOrderMapper BolWorkOrderMapper { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		private ILogger logger;

		public AbstractWorkOrderService(
			ILogger logger,
			IMediator mediator,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderServerRequestModelValidator workOrderModelValidator,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base()
		{
			this.WorkOrderRepository = workOrderRepository;
			this.WorkOrderModelValidator = workOrderModelValidator;
			this.BolWorkOrderMapper = bolWorkOrderMapper;
			this.DalWorkOrderMapper = dalWorkOrderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiWorkOrderServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.WorkOrderRepository.All(limit, offset);

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
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
				return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiWorkOrderServerResponseModel>> Create(
			ApiWorkOrderServerRequestModel model)
		{
			CreateResponse<ApiWorkOrderServerResponseModel> response = ValidationResponseFactory<ApiWorkOrderServerResponseModel>.CreateResponse(await this.WorkOrderModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolWorkOrderMapper.MapModelToBO(default(int), model);
				var record = await this.WorkOrderRepository.Create(this.DalWorkOrderMapper.MapBOToEF(bo));

				var businessObject = this.DalWorkOrderMapper.MapEFToBO(record);
				response.SetRecord(this.BolWorkOrderMapper.MapBOToModel(businessObject));
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
				var bo = this.BolWorkOrderMapper.MapModelToBO(workOrderID, model);
				await this.WorkOrderRepository.Update(this.DalWorkOrderMapper.MapBOToEF(bo));

				var record = await this.WorkOrderRepository.Get(workOrderID);

				var businessObject = this.DalWorkOrderMapper.MapEFToBO(record);
				var apiModel = this.BolWorkOrderMapper.MapBOToModel(businessObject);
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

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiWorkOrderServerResponseModel>> ByScrapReasonID(short? scrapReasonID, int limit = 0, int offset = int.MaxValue)
		{
			List<WorkOrder> records = await this.WorkOrderRepository.ByScrapReasonID(scrapReasonID, limit, offset);

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d87497b3d5814358e664cbeb5cd4c140</Hash>
</Codenesium>*/