using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractEventStatusService : AbstractService
	{
		protected IEventStatusRepository EventStatusRepository { get; private set; }

		protected IApiEventStatusRequestModelValidator EventStatusModelValidator { get; private set; }

		protected IBOLEventStatusMapper BolEventStatusMapper { get; private set; }

		protected IDALEventStatusMapper DalEventStatusMapper { get; private set; }

		private ILogger logger;

		public AbstractEventStatusService(
			ILogger logger,
			IEventStatusRepository eventStatusRepository,
			IApiEventStatusRequestModelValidator eventStatusModelValidator,
			IBOLEventStatusMapper bolEventStatusMapper,
			IDALEventStatusMapper dalEventStatusMapper)
			: base()
		{
			this.EventStatusRepository = eventStatusRepository;
			this.EventStatusModelValidator = eventStatusModelValidator;
			this.BolEventStatusMapper = bolEventStatusMapper;
			this.DalEventStatusMapper = dalEventStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEventStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventStatusRepository.All(limit, offset);

			return this.BolEventStatusMapper.MapBOToModel(this.DalEventStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventStatusResponseModel> Get(int id)
		{
			var record = await this.EventStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEventStatusMapper.MapBOToModel(this.DalEventStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEventStatusResponseModel>> Create(
			ApiEventStatusRequestModel model)
		{
			CreateResponse<ApiEventStatusResponseModel> response = new CreateResponse<ApiEventStatusResponseModel>(await this.EventStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEventStatusMapper.MapModelToBO(default(int), model);
				var record = await this.EventStatusRepository.Create(this.DalEventStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEventStatusMapper.MapBOToModel(this.DalEventStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventStatusResponseModel>> Update(
			int id,
			ApiEventStatusRequestModel model)
		{
			var validationResult = await this.EventStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEventStatusMapper.MapModelToBO(id, model);
				await this.EventStatusRepository.Update(this.DalEventStatusMapper.MapBOToEF(bo));

				var record = await this.EventStatusRepository.Get(id);

				return new UpdateResponse<ApiEventStatusResponseModel>(this.BolEventStatusMapper.MapBOToModel(this.DalEventStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEventStatusResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.EventStatusModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.EventStatusRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1cf87b334086219867b305b4f0c4061d</Hash>
</Codenesium>*/