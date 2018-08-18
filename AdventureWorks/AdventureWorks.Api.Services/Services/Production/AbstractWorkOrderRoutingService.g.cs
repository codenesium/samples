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
	public abstract class AbstractWorkOrderRoutingService : AbstractService
	{
		protected IWorkOrderRoutingRepository WorkOrderRoutingRepository { get; private set; }

		protected IApiWorkOrderRoutingRequestModelValidator WorkOrderRoutingModelValidator { get; private set; }

		protected IBOLWorkOrderRoutingMapper BolWorkOrderRoutingMapper { get; private set; }

		protected IDALWorkOrderRoutingMapper DalWorkOrderRoutingMapper { get; private set; }

		private ILogger logger;

		public AbstractWorkOrderRoutingService(
			ILogger logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator,
			IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
			IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper)
			: base()
		{
			this.WorkOrderRoutingRepository = workOrderRoutingRepository;
			this.WorkOrderRoutingModelValidator = workOrderRoutingModelValidator;
			this.BolWorkOrderRoutingMapper = bolWorkOrderRoutingMapper;
			this.DalWorkOrderRoutingMapper = dalWorkOrderRoutingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.WorkOrderRoutingRepository.All(limit, offset);

			return this.BolWorkOrderRoutingMapper.MapBOToModel(this.DalWorkOrderRoutingMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkOrderRoutingResponseModel> Get(int workOrderID)
		{
			var record = await this.WorkOrderRoutingRepository.Get(workOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolWorkOrderRoutingMapper.MapBOToModel(this.DalWorkOrderRoutingMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiWorkOrderRoutingResponseModel>> Create(
			ApiWorkOrderRoutingRequestModel model)
		{
			CreateResponse<ApiWorkOrderRoutingResponseModel> response = new CreateResponse<ApiWorkOrderRoutingResponseModel>(await this.WorkOrderRoutingModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolWorkOrderRoutingMapper.MapModelToBO(default(int), model);
				var record = await this.WorkOrderRoutingRepository.Create(this.DalWorkOrderRoutingMapper.MapBOToEF(bo));

				response.SetRecord(this.BolWorkOrderRoutingMapper.MapBOToModel(this.DalWorkOrderRoutingMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiWorkOrderRoutingResponseModel>> Update(
			int workOrderID,
			ApiWorkOrderRoutingRequestModel model)
		{
			var validationResult = await this.WorkOrderRoutingModelValidator.ValidateUpdateAsync(workOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolWorkOrderRoutingMapper.MapModelToBO(workOrderID, model);
				await this.WorkOrderRoutingRepository.Update(this.DalWorkOrderRoutingMapper.MapBOToEF(bo));

				var record = await this.WorkOrderRoutingRepository.Get(workOrderID);

				return new UpdateResponse<ApiWorkOrderRoutingResponseModel>(this.BolWorkOrderRoutingMapper.MapBOToModel(this.DalWorkOrderRoutingMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiWorkOrderRoutingResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int workOrderID)
		{
			ActionResponse response = new ActionResponse(await this.WorkOrderRoutingModelValidator.ValidateDeleteAsync(workOrderID));
			if (response.Success)
			{
				await this.WorkOrderRoutingRepository.Delete(workOrderID);
			}

			return response;
		}

		public async Task<List<ApiWorkOrderRoutingResponseModel>> ByProductID(int productID, int limit = 0, int offset = int.MaxValue)
		{
			List<WorkOrderRouting> records = await this.WorkOrderRoutingRepository.ByProductID(productID, limit, offset);

			return this.BolWorkOrderRoutingMapper.MapBOToModel(this.DalWorkOrderRoutingMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>76b7da4acba3d86f66af9788c6c3fae3</Hash>
</Codenesium>*/