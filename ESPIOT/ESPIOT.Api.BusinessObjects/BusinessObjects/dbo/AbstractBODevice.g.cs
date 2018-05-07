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
	public abstract class AbstractBODevice
	{
		private IDeviceRepository deviceRepository;
		private IDeviceModelValidator deviceModelValidator;
		private ILogger logger;

		public AbstractBODevice(
			ILogger logger,
			IDeviceRepository deviceRepository,
			IDeviceModelValidator deviceModelValidator)

		{
			this.deviceRepository = deviceRepository;
			this.deviceModelValidator = deviceModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			DeviceModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.deviceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.deviceRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			DeviceModel model)
		{
			ActionResponse response = new ActionResponse(await this.deviceModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.deviceRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.deviceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.deviceRepository.Delete(id);
			}
			return response;
		}

		public virtual POCODevice Get(int id)
		{
			return this.deviceRepository.Get(id);
		}

		public virtual List<POCODevice> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.deviceRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>c7d9774d067f0e85290ad4f2130fa5db</Hash>
</Codenesium>*/