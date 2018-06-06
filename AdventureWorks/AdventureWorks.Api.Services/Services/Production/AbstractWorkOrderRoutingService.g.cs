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
		private IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper;
		private IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper;
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
			this.bolWorkOrderRoutingMapper = bolworkOrderRoutingMapper;
			this.dalWorkOrderRoutingMapper = dalworkOrderRoutingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.workOrderRoutingRepository.All(skip, take, orderClause);

			return this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkOrderRoutingResponseModel> Get(int workOrderID)
		{
			var record = await workOrderRoutingRepository.Get(workOrderID);

			return this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiWorkOrderRoutingResponseModel>> Create(
			ApiWorkOrderRoutingRequestModel model)
		{
			CreateResponse<ApiWorkOrderRoutingResponseModel> response = new CreateResponse<ApiWorkOrderRoutingResponseModel>(await this.workOrderRoutingModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolWorkOrderRoutingMapper.MapModelToBO(default (int), model);
				var record = await this.workOrderRoutingRepository.Create(this.dalWorkOrderRoutingMapper.MapBOToEF(bo));

				response.SetRecord(this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(record)));
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
				var bo = this.bolWorkOrderRoutingMapper.MapModelToBO(workOrderID, model);
				await this.workOrderRoutingRepository.Update(this.dalWorkOrderRoutingMapper.MapBOToEF(bo));
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

			return this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1c967ef0ba72239a17f5c20b8e3b569b</Hash>
</Codenesium>*/