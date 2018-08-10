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
	public abstract class AbstractWorkOrderService : AbstractService
	{
		protected IWorkOrderRepository WorkOrderRepository { get; private set; }

		protected IApiWorkOrderRequestModelValidator WorkOrderModelValidator { get; private set; }

		protected IBOLWorkOrderMapper BolWorkOrderMapper { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		protected IBOLWorkOrderRoutingMapper BolWorkOrderRoutingMapper { get; private set; }

		protected IDALWorkOrderRoutingMapper DalWorkOrderRoutingMapper { get; private set; }

		private ILogger logger;

		public AbstractWorkOrderService(
			ILogger logger,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderRequestModelValidator workOrderModelValidator,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper,
			IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
			IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper)
			: base()
		{
			this.WorkOrderRepository = workOrderRepository;
			this.WorkOrderModelValidator = workOrderModelValidator;
			this.BolWorkOrderMapper = bolWorkOrderMapper;
			this.DalWorkOrderMapper = dalWorkOrderMapper;
			this.BolWorkOrderRoutingMapper = bolWorkOrderRoutingMapper;
			this.DalWorkOrderRoutingMapper = dalWorkOrderRoutingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.WorkOrderRepository.All(limit, offset);

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkOrderResponseModel> Get(int workOrderID)
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

		public virtual async Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
			ApiWorkOrderRequestModel model)
		{
			CreateResponse<ApiWorkOrderResponseModel> response = new CreateResponse<ApiWorkOrderResponseModel>(await this.WorkOrderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolWorkOrderMapper.MapModelToBO(default(int), model);
				var record = await this.WorkOrderRepository.Create(this.DalWorkOrderMapper.MapBOToEF(bo));

				response.SetRecord(this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiWorkOrderResponseModel>> Update(
			int workOrderID,
			ApiWorkOrderRequestModel model)
		{
			var validationResult = await this.WorkOrderModelValidator.ValidateUpdateAsync(workOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolWorkOrderMapper.MapModelToBO(workOrderID, model);
				await this.WorkOrderRepository.Update(this.DalWorkOrderMapper.MapBOToEF(bo));

				var record = await this.WorkOrderRepository.Get(workOrderID);

				return new UpdateResponse<ApiWorkOrderResponseModel>(this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiWorkOrderResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int workOrderID)
		{
			ActionResponse response = new ActionResponse(await this.WorkOrderModelValidator.ValidateDeleteAsync(workOrderID));
			if (response.Success)
			{
				await this.WorkOrderRepository.Delete(workOrderID);
			}

			return response;
		}

		public async Task<List<ApiWorkOrderResponseModel>> ByProductID(int productID)
		{
			List<WorkOrder> records = await this.WorkOrderRepository.ByProductID(productID);

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
		}

		public async Task<List<ApiWorkOrderResponseModel>> ByScrapReasonID(short? scrapReasonID)
		{
			List<WorkOrder> records = await this.WorkOrderRepository.ByScrapReasonID(scrapReasonID);

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrderRouting> records = await this.WorkOrderRepository.WorkOrderRoutings(workOrderID, limit, offset);

			return this.BolWorkOrderRoutingMapper.MapBOToModel(this.DalWorkOrderRoutingMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>7cf38e8a27a1f2d234885815dbe0ee5c</Hash>
</Codenesium>*/