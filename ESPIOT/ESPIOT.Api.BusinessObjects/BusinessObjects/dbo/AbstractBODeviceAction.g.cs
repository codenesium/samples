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

		public virtual POCODeviceAction Get(int id)
		{
			return this.deviceActionRepository.Get(id);
		}

		public virtual List<POCODeviceAction> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.deviceActionRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>4e6d2f67d1ed2299dd7663b7d21d8a31</Hash>
</Codenesium>*/