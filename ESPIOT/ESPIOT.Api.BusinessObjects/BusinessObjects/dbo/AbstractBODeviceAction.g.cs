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
		private IApiDeviceActionModelValidator deviceActionModelValidator;
		private ILogger logger;

		public AbstractBODeviceAction(
			ILogger logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionModelValidator deviceActionModelValidator)

		{
			this.deviceActionRepository = deviceActionRepository;
			this.deviceActionModelValidator = deviceActionModelValidator;
			this.logger = logger;
		}

		public virtual List<POCODeviceAction> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.deviceActionRepository.All(skip, take, orderClause);
		}

		public virtual POCODeviceAction Get(int id)
		{
			return this.deviceActionRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCODeviceAction>> Create(
			ApiDeviceActionModel model)
		{
			CreateResponse<POCODeviceAction> response = new CreateResponse<POCODeviceAction>(await this.deviceActionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCODeviceAction record = this.deviceActionRepository.Create(model);
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
	}
}

/*<Codenesium>
    <Hash>e728d5c36a4bc179adc00a7003f4d1f7</Hash>
</Codenesium>*/