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
		private IApiDeviceModelValidator deviceModelValidator;
		private ILogger logger;

		public AbstractBODevice(
			ILogger logger,
			IDeviceRepository deviceRepository,
			IApiDeviceModelValidator deviceModelValidator)

		{
			this.deviceRepository = deviceRepository;
			this.deviceModelValidator = deviceModelValidator;
			this.logger = logger;
		}

		public virtual List<POCODevice> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.deviceRepository.All(skip, take, orderClause);
		}

		public virtual POCODevice Get(int id)
		{
			return this.deviceRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCODevice>> Create(
			ApiDeviceModel model)
		{
			CreateResponse<POCODevice> response = new CreateResponse<POCODevice>(await this.deviceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCODevice record = this.deviceRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiDeviceModel model)
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

		public POCODevice PublicId(Guid publicId)
		{
			return this.deviceRepository.PublicId(publicId);
		}
	}
}

/*<Codenesium>
    <Hash>ebe3d6ed464945d488c1122ed160e855</Hash>
</Codenesium>*/