using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class TicketStatusService : AbstractService, ITicketStatusService
	{
		private MediatR.IMediator mediator;

		protected ITicketStatusRepository TicketStatusRepository { get; private set; }

		protected IApiTicketStatusServerRequestModelValidator TicketStatusModelValidator { get; private set; }

		protected IDALTicketStatusMapper DalTicketStatusMapper { get; private set; }

		protected IDALTicketMapper DalTicketMapper { get; private set; }

		private ILogger logger;

		public TicketStatusService(
			ILogger<ITicketStatusService> logger,
			MediatR.IMediator mediator,
			ITicketStatusRepository ticketStatusRepository,
			IApiTicketStatusServerRequestModelValidator ticketStatusModelValidator,
			IDALTicketStatusMapper dalTicketStatusMapper,
			IDALTicketMapper dalTicketMapper)
			: base()
		{
			this.TicketStatusRepository = ticketStatusRepository;
			this.TicketStatusModelValidator = ticketStatusModelValidator;
			this.DalTicketStatusMapper = dalTicketStatusMapper;
			this.DalTicketMapper = dalTicketMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTicketStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TicketStatus> records = await this.TicketStatusRepository.All(limit, offset, query);

			return this.DalTicketStatusMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTicketStatusServerResponseModel> Get(int id)
		{
			TicketStatus record = await this.TicketStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTicketStatusMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTicketStatusServerResponseModel>> Create(
			ApiTicketStatusServerRequestModel model)
		{
			CreateResponse<ApiTicketStatusServerResponseModel> response = ValidationResponseFactory<ApiTicketStatusServerResponseModel>.CreateResponse(await this.TicketStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TicketStatus record = this.DalTicketStatusMapper.MapModelToEntity(default(int), model);
				record = await this.TicketStatusRepository.Create(record);

				response.SetRecord(this.DalTicketStatusMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TicketStatusCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTicketStatusServerResponseModel>> Update(
			int id,
			ApiTicketStatusServerRequestModel model)
		{
			var validationResult = await this.TicketStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				TicketStatus record = this.DalTicketStatusMapper.MapModelToEntity(id, model);
				await this.TicketStatusRepository.Update(record);

				record = await this.TicketStatusRepository.Get(id);

				ApiTicketStatusServerResponseModel apiModel = this.DalTicketStatusMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TicketStatusUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTicketStatusServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTicketStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TicketStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TicketStatusRepository.Delete(id);

				await this.mediator.Publish(new TicketStatusDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiTicketServerResponseModel>> TicketsByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Ticket> records = await this.TicketStatusRepository.TicketsByTicketStatusId(ticketStatusId, limit, offset);

			return this.DalTicketMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>485358c9e4d8c3bfcb471593ff911fed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/