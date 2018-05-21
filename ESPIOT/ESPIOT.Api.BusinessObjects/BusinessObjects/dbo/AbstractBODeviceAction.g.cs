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
	public abstract class AbstractBODeviceAction: AbstractBOManager
	{
		private IDeviceActionRepository deviceActionRepository;
		private IApiDeviceActionModelValidator deviceActionModelValidator;
		private ILogger logger;

		public AbstractBODeviceAction(
			ILogger logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionModelValidator deviceActionModelValidator)
			: base()

		{
			this.deviceActionRepository = deviceActionRepository;
			this.deviceActionModelValidator = deviceActionModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCODeviceAction>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.deviceActionRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCODeviceAction> Get(int id)
		{
			return this.deviceActionRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCODeviceAction>> Create(
			ApiDeviceActionModel model)
		{
			CreateResponse<POCODeviceAction> response = new CreateResponse<POCODeviceAction>(await this.deviceActionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCODeviceAction record = await this.deviceActionRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiDeviceActionModel model)
		{
			ActionResponse response = new ActionResponse(await this.deviceActionModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.deviceActionRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.deviceActionModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.deviceActionRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9cf6e09acff628f196de2b2e6bef0509</Hash>
</Codenesium>*/