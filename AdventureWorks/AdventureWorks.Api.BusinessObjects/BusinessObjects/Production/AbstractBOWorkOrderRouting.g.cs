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
		private IApiWorkOrderRoutingModelValidator workOrderRoutingModelValidator;
		private ILogger logger;

		public AbstractBOWorkOrderRouting(
			ILogger logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IApiWorkOrderRoutingModelValidator workOrderRoutingModelValidator)

		{
			this.workOrderRoutingRepository = workOrderRoutingRepository;
			this.workOrderRoutingModelValidator = workOrderRoutingModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOWorkOrderRouting> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRoutingRepository.All(skip, take, orderClause);
		}

		public virtual POCOWorkOrderRouting Get(int workOrderID)
		{
			return this.workOrderRoutingRepository.Get(workOrderID);
		}

		public virtual async Task<CreateResponse<POCOWorkOrderRouting>> Create(
			ApiWorkOrderRoutingModel model)
		{
			CreateResponse<POCOWorkOrderRouting> response = new CreateResponse<POCOWorkOrderRouting>(await this.workOrderRoutingModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOWorkOrderRouting record = this.workOrderRoutingRepository.Create(model);
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

		public List<POCOWorkOrderRouting> GetProductID(int productID)
		{
			return this.workOrderRoutingRepository.GetProductID(productID);
		}
	}
}

/*<Codenesium>
    <Hash>da20f68ed8358e332316b4cb83ca7cf5</Hash>
</Codenesium>*/