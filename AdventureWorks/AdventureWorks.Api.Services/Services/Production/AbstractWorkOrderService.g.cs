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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractWorkOrderService: AbstractService
	{
		private IWorkOrderRepository workOrderRepository;
		private IApiWorkOrderRequestModelValidator workOrderModelValidator;
		private IBOLWorkOrderMapper BOLWorkOrderMapper;
		private IDALWorkOrderMapper DALWorkOrderMapper;
		private ILogger logger;

		public AbstractWorkOrderService(
			ILogger logger,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderRequestModelValidator workOrderModelValidator,
			IBOLWorkOrderMapper bolworkOrderMapper,
			IDALWorkOrderMapper dalworkOrderMapper)
			: base()

		{
			this.workOrderRepository = workOrderRepository;
			this.workOrderModelValidator = workOrderModelValidator;
			this.BOLWorkOrderMapper = bolworkOrderMapper;
			this.DALWorkOrderMapper = dalworkOrderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkOrderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.workOrderRepository.All(skip, take, orderClause);

			return this.BOLWorkOrderMapper.MapBOToModel(this.DALWorkOrderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkOrderResponseModel> Get(int workOrderID)
		{
			var record = await workOrderRepository.Get(workOrderID);

			return this.BOLWorkOrderMapper.MapBOToModel(this.DALWorkOrderMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
			ApiWorkOrderRequestModel model)
		{
			CreateResponse<ApiWorkOrderResponseModel> response = new CreateResponse<ApiWorkOrderResponseModel>(await this.workOrderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLWorkOrderMapper.MapModelToBO(default (int), model);
				var record = await this.workOrderRepository.Create(this.DALWorkOrderMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLWorkOrderMapper.MapBOToModel(this.DALWorkOrderMapper.MapEFToBO(record)));
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
				var bo = this.BOLWorkOrderMapper.MapModelToBO(workOrderID, model);
				await this.workOrderRepository.Update(this.DALWorkOrderMapper.MapBOToEF(bo));
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
			List<WorkOrder> records = await this.workOrderRepository.GetProductID(productID);

			return this.BOLWorkOrderMapper.MapBOToModel(this.DALWorkOrderMapper.MapEFToBO(records));
		}
		public async Task<List<ApiWorkOrderResponseModel>> GetScrapReasonID(Nullable<short> scrapReasonID)
		{
			List<WorkOrder> records = await this.workOrderRepository.GetScrapReasonID(scrapReasonID);

			return this.BOLWorkOrderMapper.MapBOToModel(this.DALWorkOrderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>38f6e2d01634443f7d386db24cff0a7b</Hash>
</Codenesium>*/