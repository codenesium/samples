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
	public abstract class AbstractBODevice: AbstractBOManager
	{
		private IDeviceRepository deviceRepository;
		private IApiDeviceModelValidator deviceModelValidator;
		private ILogger logger;

		public AbstractBODevice(
			ILogger logger,
			IDeviceRepository deviceRepository,
			IApiDeviceModelValidator deviceModelValidator)
			: base()

		{
			this.deviceRepository = deviceRepository;
			this.deviceModelValidator = deviceModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCODevice>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.deviceRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCODevice> Get(int id)
		{
			return this.deviceRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCODevice>> Create(
			ApiDeviceModel model)
		{
			CreateResponse<POCODevice> response = new CreateResponse<POCODevice>(await this.deviceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCODevice record = await this.deviceRepository.Create(model);

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
				await this.deviceRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.deviceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.deviceRepository.Delete(id);
			}
			return response;
		}

		public async Task<POCODevice> PublicId(Guid publicId)
		{
			return await this.deviceRepository.PublicId(publicId);
		}
	}
}

/*<Codenesium>
    <Hash>2db08f6492482283f1690dda2b5cd48e</Hash>
</Codenesium>*/