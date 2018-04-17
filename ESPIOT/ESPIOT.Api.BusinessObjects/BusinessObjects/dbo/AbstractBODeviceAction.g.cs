using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public abstract class AbstractBODeviceAction
	{
		private IDeviceActionRepository deviceActionRepository;
		private IDeviceActionModelValidator deviceActionModelValidator;
		private ILogger logger;

		public AbstractBODeviceAction(
			ILogger logger,
			IDeviceActionRepository deviceActionRepository,
			IDeviceActionModelValidator deviceActionModelValidator)

		{
			this.deviceActionRepository = deviceActionRepository;
			this.deviceActionModelValidator = deviceActionModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			DeviceActionModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.deviceActionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.deviceActionRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			DeviceActionModel model)
		{
			ActionResponse response = new ActionResponse(await this.deviceActionModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.deviceActionRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.deviceActionModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.deviceActionRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.deviceActionRepository.GetById(id);
		}

		public virtual POCODeviceAction GetByIdDirect(int id)
		{
			return this.deviceActionRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFDeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.deviceActionRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.deviceActionRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCODeviceAction> GetWhereDirect(Expression<Func<EFDeviceAction, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.deviceActionRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>14c8b7913482fe0902c1978c15fe8738</Hash>
</Codenesium>*/