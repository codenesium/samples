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
	public abstract class AbstractBOWorkOrder
	{
		private IWorkOrderRepository workOrderRepository;
		private IWorkOrderModelValidator workOrderModelValidator;
		private ILogger logger;

		public AbstractBOWorkOrder(
			ILogger logger,
			IWorkOrderRepository workOrderRepository,
			IWorkOrderModelValidator workOrderModelValidator)

		{
			this.workOrderRepository = workOrderRepository;
			this.workOrderModelValidator = workOrderModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			WorkOrderModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.workOrderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.workOrderRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int workOrderID,
			WorkOrderModel model)
		{
			ActionResponse response = new ActionResponse(await this.workOrderModelValidator.ValidateUpdateAsync(workOrderID, model));

			if (response.Success)
			{
				this.workOrderRepository.Update(workOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int workOrderID)
		{
			ActionResponse response = new ActionResponse(await this.workOrderModelValidator.ValidateDeleteAsync(workOrderID));

			if (response.Success)
			{
				this.workOrderRepository.Delete(workOrderID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int workOrderID)
		{
			return this.workOrderRepository.GetById(workOrderID);
		}

		public virtual POCOWorkOrder GetByIdDirect(int workOrderID)
		{
			return this.workOrderRepository.GetByIdDirect(workOrderID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOWorkOrder> GetWhereDirect(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.workOrderRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>cc2c57fef4c80df5dade217fe4cd23fa</Hash>
</Codenesium>*/