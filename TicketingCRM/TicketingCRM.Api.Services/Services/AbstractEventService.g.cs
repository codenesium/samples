using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractEventService : AbstractService
	{
		protected IEventRepository EventRepository { get; private set; }

		protected IApiEventRequestModelValidator EventModelValidator { get; private set; }

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractEventService(
			ILogger logger,
			IEventRepository eventRepository,
			IApiEventRequestModelValidator eventModelValidator,
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

		public virtual async Task<List<ApiEventResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventRepository.All(limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiEventResponseModel>> Create(
			ApiEventRequestModel model)
		{
			CreateResponse<ApiEventResponseModel> response = new CreateResponse<ApiEventResponseModel>(await this.EventModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEventMapper.MapModelToBO(default(int), model);
				var record = await this.EventRepository.Create(this.DalEventMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventResponseModel>> Update(
			int id,
			ApiEventRequestModel model)
		{
			var validationResult = await this.EventModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEventMapper.MapModelToBO(id, model);
				await this.EventRepository.Update(this.DalEventMapper.MapBOToEF(bo));

				var record = await this.EventRepository.Get(id);

				return new UpdateResponse<ApiEventResponseModel>(this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEventResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.EventModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.EventRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiEventResponseModel>> ByCityId(int cityId)
		{
			List<Event> records = await this.EventRepository.ByCityId(cityId);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>2d0e79840dd41b276bb276a909bcf5b6</Hash>
</Codenesium>*/