using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class TicketService : AbstractService, ITicketService
	{
		private MediatR.IMediator mediator;

		protected ITicketRepository TicketRepository { get; private set; }

		protected IApiTicketServerRequestModelValidator TicketModelValidator { get; private set; }

		protected IDALTicketMapper DalTicketMapper { get; private set; }

		protected IDALSaleTicketsMapper DalSaleTicketsMapper { get; private set; }

		private ILogger logger;

		public TicketService(
			ILogger<ITicketService> logger,
			MediatR.IMediator mediator,
			ITicketRepository ticketRepository,
			IApiTicketServerRequestModelValidator ticketModelValidator,
			IDALTicketMapper dalTicketMapper,
			IDALSaleTicketsMapper dalSaleTicketsMapper)
			: base()
		{
			this.TicketRepository = ticketRepository;
			this.TicketModelValidator = ticketModelValidator;
			this.DalTicketMapper = dalTicketMapper;
			this.DalSaleTicketsMapper = dalSaleTicketsMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTicketServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Ticket> records = await this.TicketRepository.All(limit, offset, query);

			return this.DalTicketMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTicketServerResponseModel> Get(int id)
		{
			Ticket record = await this.TicketRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTicketMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTicketServerResponseModel>> Create(
			ApiTicketServerRequestModel model)
		{
			CreateResponse<ApiTicketServerResponseModel> response = ValidationResponseFactory<ApiTicketServerResponseModel>.CreateResponse(await this.TicketModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Ticket record = this.DalTicketMapper.MapModelToEntity(default(int), model);
				record = await this.TicketRepository.Create(record);

				response.SetRecord(this.DalTicketMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TicketCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTicketServerResponseModel>> Update(
			int id,
			ApiTicketServerRequestModel model)
		{
			var validationResult = await this.TicketModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Ticket record = this.DalTicketMapper.MapModelToEntity(id, model);
				await this.TicketRepository.Update(record);

				record = await this.TicketRepository.Get(id);

				ApiTicketServerResponseModel apiModel = this.DalTicketMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TicketUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTicketServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTicketServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TicketModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TicketRepository.Delete(id);

				await this.mediator.Publish(new TicketDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiTicketServerResponseModel>> ByTicketStatusId(int ticketStatusId, int limit = 0, int offset = int.MaxValue)
		{
			List<Ticket> records = await this.TicketRepository.ByTicketStatusId(ticketStatusId, limit, offset);

			return this.DalTicketMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiSaleTicketsServerResponseModel>> SaleTicketsByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0)
		{
			List<SaleTickets> records = await this.TicketRepository.SaleTicketsByTicketId(ticketId, limit, offset);

			return this.DalSaleTicketsMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>acfbe3c584a31d60cbcb8a7d73833642</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/