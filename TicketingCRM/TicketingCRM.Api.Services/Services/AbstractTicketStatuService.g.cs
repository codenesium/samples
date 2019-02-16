using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractTicketStatuService : AbstractService
	{
		private IMediator mediator;

		protected ITicketStatuRepository TicketStatuRepository { get; private set; }

		protected IApiTicketStatuServerRequestModelValidator TicketStatuModelValidator { get; private set; }

		protected IDALTicketStatuMapper DalTicketStatuMapper { get; private set; }

		protected IDALTicketMapper DalTicketMapper { get; private set; }

		private ILogger logger;

		public AbstractTicketStatuService(
			ILogger logger,
			IMediator mediator,
			ITicketStatuRepository ticketStatuRepository,
			IApiTicketStatuServerRequestModelValidator ticketStatuModelValidator,
			IDALTicketStatuMapper dalTicketStatuMapper,
			IDALTicketMapper dalTicketMapper)
			: base()
		{
			this.TicketStatuRepository = ticketStatuRepository;
			this.TicketStatuModelValidator = ticketStatuModelValidator;
			this.DalTicketStatuMapper = dalTicketStatuMapper;
			this.DalTicketMapper = dalTicketMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTicketStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TicketStatu> records = await this.TicketStatuRepository.All(limit, offset, query);

			return this.DalTicketStatuMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTicketStatuServerResponseModel> Get(int id)
		{
			TicketStatu record = await this.TicketStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTicketStatuMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTicketStatuServerResponseModel>> Create(
			ApiTicketStatuServerRequestModel model)
		{
			CreateResponse<ApiTicketStatuServerResponseModel> response = ValidationResponseFactory<ApiTicketStatuServerResponseModel>.CreateResponse(await this.TicketStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TicketStatu record = this.DalTicketStatuMapper.MapModelToEntity(default(int), model);
				record = await this.TicketStatuRepository.Create(record);

				response.SetRecord(this.DalTicketStatuMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TicketStatuCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTicketStatuServerResponseModel>> Update(
			int id,
			ApiTicketStatuServerRequestModel model)
		{
			var validationResult = await this.TicketStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				TicketStatu record = this.DalTicketStatuMapper.MapModelToEntity(id, model);
				await this.TicketStatuRepository.Update(record);

				record = await this.TicketStatuRepository.Get(id);

				ApiTicketStatuServerResponseModel apiModel = this.DalTicketStatuMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TicketStatuUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTicketStatuServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTicketStatuServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TicketStatuModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TicketStatuRepository.Delete(id);

				await this.mediator.Publish(new TicketStatuDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiTicketServerResponseModel>> TicketsByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Ticket> records = await this.TicketStatuRepository.TicketsByTicketStatusId(ticketStatusId, limit, offset);

			return this.DalTicketMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>8bded00e54190160da9237ce52b4d336</Hash>
</Codenesium>*/