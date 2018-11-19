using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractEventService : AbstractService
	{
		protected IEventRepository EventRepository { get; private set; }

		protected IApiEventServerRequestModelValidator EventModelValidator { get; private set; }

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractEventService(
			ILogger logger,
			IEventRepository eventRepository,
			IApiEventServerRequestModelValidator eventModelValidator,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.EventRepository = eventRepository;
			this.EventModelValidator = eventModelValidator;
			this.BolEventMapper = bolEventMapper;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEventServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventRepository.All(limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventServerResponseModel> Get(int id)
		{
			var record = await this.EventRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEventServerResponseModel>> Create(
			ApiEventServerRequestModel model)
		{
			CreateResponse<ApiEventServerResponseModel> response = ValidationResponseFactory<ApiEventServerResponseModel>.CreateResponse(await this.EventModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolEventMapper.MapModelToBO(default(int), model);
				var record = await this.EventRepository.Create(this.DalEventMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventServerResponseModel>> Update(
			int id,
			ApiEventServerRequestModel model)
		{
			var validationResult = await this.EventModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEventMapper.MapModelToBO(id, model);
				await this.EventRepository.Update(this.DalEventMapper.MapBOToEF(bo));

				var record = await this.EventRepository.Get(id);

				return ValidationResponseFactory<ApiEventServerResponseModel>.UpdateResponse(this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiEventServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EventModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.EventRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiEventServerResponseModel>> ByEventStatusId(int eventStatusId, int limit = 0, int offset = int.MaxValue)
		{
			List<Event> records = await this.EventRepository.ByEventStatusId(eventStatusId, limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEventServerResponseModel>> ByStudentId(int studentId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.EventRepository.ByStudentId(studentId, limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEventServerResponseModel>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.EventRepository.ByTeacherId(teacherId, limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>f9157ccde6dba3c682b9a2a13f2bd841</Hash>
</Codenesium>*/