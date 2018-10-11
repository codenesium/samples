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

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractEventStatusService(
			ILogger logger,
			IEventStatusRepository eventStatusRepository,
			IApiEventStatusRequestModelValidator eventStatusModelValidator,
			IBOLEventStatusMapper bolEventStatusMapper,
			IDALEventStatusMapper dalEventStatusMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.EventStatusRepository = eventStatusRepository;
			this.EventStatusModelValidator = eventStatusModelValidator;
			this.BolEventStatusMapper = bolEventStatusMapper;
			this.DalEventStatusMapper = dalEventStatusMapper;
			this.BolEventMapper = bolEventMapper;
			this.DalEventMapper = dalEventMapper;
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

		public async virtual Task<List<ApiEventResponseModel>> Events(int eventStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.EventStatusRepository.Events(eventStatusId, limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3a0a47b2a5f837fd776bfed28612c1f5</Hash>
</Codenesium>*/