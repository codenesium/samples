using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractSaleTicketService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ISaleTicketRepository SaleTicketRepository { get; private set; }

		protected IApiSaleTicketServerRequestModelValidator SaleTicketModelValidator { get; private set; }

		protected IDALSaleTicketMapper DalSaleTicketMapper { get; private set; }

		private ILogger logger;

		public AbstractSaleTicketService(
			ILogger logger,
			MediatR.IMediator mediator,
			ISaleTicketRepository saleTicketRepository,
			IApiSaleTicketServerRequestModelValidator saleTicketModelValidator,
			IDALSaleTicketMapper dalSaleTicketMapper)
			: base()
		{
			this.SaleTicketRepository = saleTicketRepository;
			this.SaleTicketModelValidator = saleTicketModelValidator;
			this.DalSaleTicketMapper = dalSaleTicketMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSaleTicketServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<SaleTicket> records = await this.SaleTicketRepository.All(limit, offset, query);

			return this.DalSaleTicketMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSaleTicketServerResponseModel> Get(int id)
		{
			SaleTicket record = await this.SaleTicketRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSaleTicketMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSaleTicketServerResponseModel>> Create(
			ApiSaleTicketServerRequestModel model)
		{
			CreateResponse<ApiSaleTicketServerResponseModel> response = ValidationResponseFactory<ApiSaleTicketServerResponseModel>.CreateResponse(await this.SaleTicketModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				SaleTicket record = this.DalSaleTicketMapper.MapModelToEntity(default(int), model);
				record = await this.SaleTicketRepository.Create(record);

				response.SetRecord(this.DalSaleTicketMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SaleTicketCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSaleTicketServerResponseModel>> Update(
			int id,
			ApiSaleTicketServerRequestModel model)
		{
			var validationResult = await this.SaleTicketModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				SaleTicket record = this.DalSaleTicketMapper.MapModelToEntity(id, model);
				await this.SaleTicketRepository.Update(record);

				record = await this.SaleTicketRepository.Get(id);

				ApiSaleTicketServerResponseModel apiModel = this.DalSaleTicketMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SaleTicketUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSaleTicketServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSaleTicketServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SaleTicketModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SaleTicketRepository.Delete(id);

				await this.mediator.Publish(new SaleTicketDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiSaleTicketServerResponseModel>> ByTicketId(int ticketId, int limit = 0, int offset = int.MaxValue)
		{
			List<SaleTicket> records = await this.SaleTicketRepository.ByTicketId(ticketId, limit, offset);

			return this.DalSaleTicketMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>6bc699fba8adc4b8a89003329a3efde7</Hash>
</Codenesium>*/