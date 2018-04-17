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

		public virtual ApiResponse GetById(int workOrderID)
		{
			return this.workOrderRoutingRepository.GetById(workOrderID);
		}

		public virtual POCOWorkOrderRouting GetByIdDirect(int workOrderID)
		{
			return this.workOrderRoutingRepository.GetByIdDirect(workOrderID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRoutingRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRoutingRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOWorkOrderRouting> GetWhereDirect(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRoutingRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>56ba1c7f24bb08f54d81c8899ec3f2a7</Hash>
</Codenesium>*/