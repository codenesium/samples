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
		private IWorkOrderRoutingRepository workOrderRoutingRepository;

		private IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator;

		private IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper;

		private IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper;

		private ILogger logger;

		public AbstractWorkOrderRoutingService(
			ILogger logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator,
			IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
			IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper)
			: base()
		{
			this.workOrderRoutingRepository = workOrderRoutingRepository;
			this.workOrderRoutingModelValidator = workOrderRoutingModelValidator;
			this.bolWorkOrderRoutingMapper = bolWorkOrderRoutingMapper;
			this.dalWorkOrderRoutingMapper = dalWorkOrderRoutingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.workOrderRoutingRepository.All(limit, offset);

			return this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiWorkOrderRoutingResponseModel> Get(int workOrderID)
		{
			var record = await this.workOrderRoutingRepository.Get(workOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiWorkOrderRoutingResponseModel>> Create(
			ApiWorkOrderRoutingRequestModel model)
		{
			CreateResponse<ApiWorkOrderRoutingResponseModel> response = new CreateResponse<ApiWorkOrderRoutingResponseModel>(await this.workOrderRoutingModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolWorkOrderRoutingMapper.MapModelToBO(default(int), model);
				var record = await this.workOrderRoutingRepository.Create(this.dalWorkOrderRoutingMapper.MapBOToEF(bo));

				response.SetRecord(this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiWorkOrderRoutingResponseModel>> Update(
			int workOrderID,
			ApiWorkOrderRoutingRequestModel model)
		{
			var validationResult = await this.workOrderRoutingModelValidator.ValidateUpdateAsync(workOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolWorkOrderRoutingMapper.MapModelToBO(workOrderID, model);
				await this.workOrderRoutingRepository.Update(this.dalWorkOrderRoutingMapper.MapBOToEF(bo));

				var record = await this.workOrderRoutingRepository.Get(workOrderID);

				return new UpdateResponse<ApiWorkOrderRoutingResponseModel>(this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiWorkOrderRoutingResponseModel>(validationResult);
			}
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

		public async Task<List<ApiWorkOrderRoutingResponseModel>> ByProductID(int productID)
		{
			List<WorkOrderRouting> records = await this.workOrderRoutingRepository.ByProductID(productID);

			return this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1fd773824f0d16947c412dfb799b70b3</Hash>
</Codenesium>*/