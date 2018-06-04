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
	public abstract class AbstractWorkOrderRoutingService: AbstractService
	{
		private IWorkOrderRoutingRepository workOrderRoutingRepository;
		private IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator;
		private IBOLWorkOrderRoutingMapper BOLWorkOrderRoutingMapper;
		private IDALWorkOrderRoutingMapper DALWorkOrderRoutingMapper;
		private ILogger logger;

		public AbstractWorkOrderRoutingService(
			ILogger logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator,
			IBOLWorkOrderRoutingMapper bolworkOrderRoutingMapper,
			IDALWorkOrderRoutingMapper dalworkOrderRoutingMapper)
			: base()

		{
			this.workOrderRoutingRepository = workOrderRoutingRepository;
			this.workOrderRoutingModelValidator = workOrderRoutingModelValidator;
			this.BOLWorkOrderRoutingMapper = bolworkOrderRoutingMapper;
			this.DALWorkOrderRoutingMapper = dalworkOrderRoutingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.workOrderRoutingRepository.All(skip, take, orderClause);

			return this.BOLWorkOrderRoutingMapper.MapBOToModel(this.DALWorkOrderRoutingMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkOrderRoutingResponseModel> Get(int workOrderID)
		{
			var record = await workOrderRoutingRepository.Get(workOrderID);

			return this.BOLWorkOrderRoutingMapper.MapBOToModel(this.DALWorkOrderRoutingMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiWorkOrderRoutingResponseModel>> Create(
			ApiWorkOrderRoutingRequestModel model)
		{
			CreateResponse<ApiWorkOrderRoutingResponseModel> response = new CreateResponse<ApiWorkOrderRoutingResponseModel>(await this.workOrderRoutingModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLWorkOrderRoutingMapper.MapModelToBO(default (int), model);
				var record = await this.workOrderRoutingRepository.Create(this.DALWorkOrderRoutingMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLWorkOrderRoutingMapper.MapBOToModel(this.DALWorkOrderRoutingMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int workOrderID,
			ApiWorkOrderRoutingRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.workOrderRoutingModelValidator.ValidateUpdateAsync(workOrderID, model));

			if (response.Success)
			{
				var bo = this.BOLWorkOrderRoutingMapper.MapModelToBO(workOrderID, model);
				await this.workOrderRoutingRepository.Update(this.DALWorkOrderRoutingMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int workOrderID)
		{
			ActionResponse response = new ActionResponse(await this.workOrderRoutingModelValidator.ValidateDeleteAsync(workOrderID));

			if (response.Success)
			{
				await this.workOrderRoutingRepository.Delete(workOrderID);
			}
			return response;
		}

		public async Task<List<ApiWorkOrderRoutingResponseModel>> GetProductID(int productID)
		{
			List<WorkOrderRouting> records = await this.workOrderRoutingRepository.GetProductID(productID);

			return this.BOLWorkOrderRoutingMapper.MapBOToModel(this.DALWorkOrderRoutingMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>98917b884d168985fe21ebd5a395e0d0</Hash>
</Codenesium>*/