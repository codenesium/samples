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
		private IApiWorkOrderRoutingModelValidator workOrderRoutingModelValidator;
		private ILogger logger;

		public AbstractBOWorkOrderRouting(
			ILogger logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IApiWorkOrderRoutingModelValidator workOrderRoutingModelValidator)
			: base()

		{
			this.workOrderRoutingRepository = workOrderRoutingRepository;
			this.workOrderRoutingModelValidator = workOrderRoutingModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOWorkOrderRouting>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRoutingRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOWorkOrderRouting> Get(int workOrderID)
		{
			return this.workOrderRoutingRepository.Get(workOrderID);
		}

		public virtual async Task<CreateResponse<POCOWorkOrderRouting>> Create(
			ApiWorkOrderRoutingModel model)
		{
			CreateResponse<POCOWorkOrderRouting> response = new CreateResponse<POCOWorkOrderRouting>(await this.workOrderRoutingModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOWorkOrderRouting record = await this.workOrderRoutingRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int workOrderID,
			ApiWorkOrderRoutingModel model)
		{
			ActionResponse response = new ActionResponse(await this.workOrderRoutingModelValidator.ValidateUpdateAsync(workOrderID, model));

			if (response.Success)
			{
				await this.workOrderRoutingRepository.Update(workOrderID, model);
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

		public async Task<List<POCOWorkOrderRouting>> GetProductID(int productID)
		{
			return await this.workOrderRoutingRepository.GetProductID(productID);
		}
	}
}

/*<Codenesium>
    <Hash>cd7ed482447a6de4ffe9435657d62166</Hash>
</Codenesium>*/