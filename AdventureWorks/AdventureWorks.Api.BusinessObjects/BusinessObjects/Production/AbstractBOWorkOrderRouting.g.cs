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
	public abstract class AbstractBOWorkOrderRouting
	{
		private IWorkOrderRoutingRepository workOrderRoutingRepository;
		private IWorkOrderRoutingModelValidator workOrderRoutingModelValidator;
		private ILogger logger;

		public AbstractBOWorkOrderRouting(
			ILogger logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IWorkOrderRoutingModelValidator workOrderRoutingModelValidator)

		{
			this.workOrderRoutingRepository = workOrderRoutingRepository;
			this.workOrderRoutingModelValidator = workOrderRoutingModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			WorkOrderRoutingModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.workOrderRoutingModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.workOrderRoutingRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int workOrderID,
			WorkOrderRoutingModel model)
		{
			ActionResponse response = new ActionResponse(await this.workOrderRoutingModelValidator.ValidateUpdateAsync(workOrderID, model));

			if (response.Success)
			{
				this.workOrderRoutingRepository.Update(workOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int workOrderID)
		{
			ActionResponse response = new ActionResponse(await this.workOrderRoutingModelValidator.ValidateDeleteAsync(workOrderID));

			if (response.Success)
			{
				this.workOrderRoutingRepository.Delete(workOrderID);
			}
			return response;
		}

		public virtual POCOWorkOrderRouting Get(int workOrderID)
		{
			return this.workOrderRoutingRepository.Get(workOrderID);
		}

		public virtual List<POCOWorkOrderRouting> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRoutingRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>6083c73d4ecdbd1201409d5c09ee6b73</Hash>
</Codenesium>*/