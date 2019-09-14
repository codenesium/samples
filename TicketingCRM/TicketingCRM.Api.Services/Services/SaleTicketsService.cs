using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class SaleTicketsService : AbstractService, ISaleTicketsService
	{
		private MediatR.IMediator mediator;

		protected ISaleTicketsRepository SaleTicketsRepository { get; private set; }

		protected IApiSaleTicketsServerRequestModelValidator SaleTicketsModelValidator { get; private set; }

		protected IDALSaleTicketsMapper DalSaleTicketsMapper { get; private set; }

		private ILogger logger;

		public SaleTicketsService(
			ILogger<ISaleTicketsService> logger,
			MediatR.IMediator mediator,
			ISaleTicketsRepository saleTicketsRepository,
			IApiSaleTicketsServerRequestModelValidator saleTicketsModelValidator,
			IDALSaleTicketsMapper dalSaleTicketsMapper)
			: base()
		{
			this.SaleTicketsRepository = saleTicketsRepository;
			this.SaleTicketsModelValidator = saleTicketsModelValidator;
			this.DalSaleTicketsMapper = dalSaleTicketsMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSaleTicketsServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<SaleTickets> records = await this.SaleTicketsRepository.All(limit, offset, query);

			return this.DalSaleTicketsMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSaleTicketsServerResponseModel> Get(int id)
		{
			SaleTickets record = await this.SaleTicketsRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSaleTicketsMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSaleTicketsServerResponseModel>> Create(
			ApiSaleTicketsServerRequestModel model)
		{
			CreateResponse<ApiSaleTicketsServerResponseModel> response = ValidationResponseFactory<ApiSaleTicketsServerResponseModel>.CreateResponse(await this.SaleTicketsModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				SaleTickets record = this.DalSaleTicketsMapper.MapModelToEntity(default(int), model);
				record = await this.SaleTicketsRepository.Create(record);

				response.SetRecord(this.DalSaleTicketsMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SaleTicketsCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSaleTicketsServerResponseModel>> Update(
			int id,
			ApiSaleTicketsServerRequestModel model)
		{
			var validationResult = await this.SaleTicketsModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				SaleTickets record = this.DalSaleTicketsMapper.MapModelToEntity(id, model);
				await this.SaleTicketsRepository.Update(record);

				record = await this.SaleTicketsRepository.Get(id);

				ApiSaleTicketsServerResponseModel apiModel = this.DalSaleTicketsMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SaleTicketsUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSaleTicketsServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSaleTicketsServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SaleTicketsModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SaleTicketsRepository.Delete(id);

				await this.mediator.Publish(new SaleTicketsDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiSaleTicketsServerResponseModel>> ByTicketId(int ticketId, int limit = 0, int offset = int.MaxValue)
		{
			List<SaleTickets> records = await this.SaleTicketsRepository.ByTicketId(ticketId, limit, offset);

			return this.DalSaleTicketsMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>0f6bb304dbaf37d61cd6989dfc3160e0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/