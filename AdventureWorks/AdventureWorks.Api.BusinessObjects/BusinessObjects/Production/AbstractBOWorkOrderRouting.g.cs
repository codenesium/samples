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
	public abstract class AbstractBOWorkOrderRouting: AbstractBOManager
	{
		private IWorkOrderRoutingRepository workOrderRoutingRepository;
		private IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator;
		private IBOLWorkOrderRoutingMapper workOrderRoutingMapper;
		private ILogger logger;

		public AbstractBOWorkOrderRouting(
			ILogger logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator,
			IBOLWorkOrderRoutingMapper workOrderRoutingMapper)
			: base()

		{
			this.workOrderRoutingRepository = workOrderRoutingRepository;
			this.workOrderRoutingModelValidator = workOrderRoutingModelValidator;
			this.workOrderRoutingMapper = workOrderRoutingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiWorkOrderRoutingResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.workOrderRoutingRepository.All(skip, take, orderClause);

			return this.workOrderRoutingMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiWorkOrderRoutingResponseModel> Get(int workOrderID)
		{
			var record = await workOrderRoutingRepository.Get(workOrderID);

			return this.workOrderRoutingMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiWorkOrderRoutingResponseModel>> Create(
			ApiWorkOrderRoutingRequestModel model)
		{
			CreateResponse<ApiWorkOrderRoutingResponseModel> response = new CreateResponse<ApiWorkOrderRoutingResponseModel>(await this.workOrderRoutingModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.workOrderRoutingMapper.MapModelToDTO(default (int), model);
				var record = await this.workOrderRoutingRepository.Create(dto);

				response.SetRecord(this.workOrderRoutingMapper.MapDTOToModel(record));
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
				var dto = this.workOrderRoutingMapper.MapModelToDTO(workOrderID, model);
				await this.workOrderRoutingRepository.Update(workOrderID, dto);
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
			List<DTOWorkOrderRouting> records = await this.workOrderRoutingRepository.GetProductID(productID);

			return this.workOrderRoutingMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>52e5236175b2fcf0bb0e7429c1f8234c</Hash>
</Codenesium>*/