using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractEventStatuService : AbstractService
	{
		protected IEventStatuRepository EventStatuRepository { get; private set; }

		protected IApiEventStatuServerRequestModelValidator EventStatuModelValidator { get; private set; }

		protected IBOLEventStatuMapper BolEventStatuMapper { get; private set; }

		protected IDALEventStatuMapper DalEventStatuMapper { get; private set; }

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractEventStatuService(
			ILogger logger,
			IEventStatuRepository eventStatuRepository,
			IApiEventStatuServerRequestModelValidator eventStatuModelValidator,
			IBOLEventStatuMapper bolEventStatuMapper,
			IDALEventStatuMapper dalEventStatuMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.EventStatuRepository = eventStatuRepository;
			this.EventStatuModelValidator = eventStatuModelValidator;
			this.BolEventStatuMapper = bolEventStatuMapper;
			this.DalEventStatuMapper = dalEventStatuMapper;
			this.BolEventMapper = bolEventMapper;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEventStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventStatuRepository.All(limit, offset);

			return this.BolEventStatuMapper.MapBOToModel(this.DalEventStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventStatuServerResponseModel> Get(int id)
		{
			var record = await this.EventStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEventStatuMapper.MapBOToModel(this.DalEventStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEventStatuServerResponseModel>> Create(
			ApiEventStatuServerRequestModel model)
		{
			CreateResponse<ApiEventStatuServerResponseModel> response = ValidationResponseFactory<ApiEventStatuServerResponseModel>.CreateResponse(await this.EventStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolEventStatuMapper.MapModelToBO(default(int), model);
				var record = await this.EventStatuRepository.Create(this.DalEventStatuMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEventStatuMapper.MapBOToModel(this.DalEventStatuMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventStatuServerResponseModel>> Update(
			int id,
			ApiEventStatuServerRequestModel model)
		{
			var validationResult = await this.EventStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEventStatuMapper.MapModelToBO(id, model);
				await this.EventStatuRepository.Update(this.DalEventStatuMapper.MapBOToEF(bo));

				var record = await this.EventStatuRepository.Get(id);

				return ValidationResponseFactory<ApiEventStatuServerResponseModel>.UpdateResponse(this.BolEventStatuMapper.MapBOToModel(this.DalEventStatuMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiEventStatuServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EventStatuModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.EventStatuRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiEventServerResponseModel>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.EventStatuRepository.EventsByEventStatusId(eventStatusId, limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e8e70b1a783472063466782cd3162953</Hash>
</Codenesium>*/