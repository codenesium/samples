using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractSaleService : AbstractService
	{
		private IMediator mediator;

		protected ISaleRepository SaleRepository { get; private set; }

		protected IApiSaleServerRequestModelValidator SaleModelValidator { get; private set; }

		protected IBOLSaleMapper BolSaleMapper { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		private ILogger logger;

		public AbstractSaleService(
			ILogger logger,
			IMediator mediator,
			ISaleRepository saleRepository,
			IApiSaleServerRequestModelValidator saleModelValidator,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base()
		{
			this.SaleRepository = saleRepository;
			this.SaleModelValidator = saleModelValidator;
			this.BolSaleMapper = bolSaleMapper;
			this.DalSaleMapper = dalSaleMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSaleServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SaleRepository.All(limit, offset);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSaleServerResponseModel> Get(int id)
		{
			var record = await this.SaleRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSaleServerResponseModel>> Create(
			ApiSaleServerRequestModel model)
		{
			CreateResponse<ApiSaleServerResponseModel> response = ValidationResponseFactory<ApiSaleServerResponseModel>.CreateResponse(await this.SaleModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSaleMapper.MapModelToBO(default(int), model);
				var record = await this.SaleRepository.Create(this.DalSaleMapper.MapBOToEF(bo));

				var businessObject = this.DalSaleMapper.MapEFToBO(record);
				response.SetRecord(this.BolSaleMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new SaleCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSaleServerResponseModel>> Update(
			int id,
			ApiSaleServerRequestModel model)
		{
			var validationResult = await this.SaleModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSaleMapper.MapModelToBO(id, model);
				await this.SaleRepository.Update(this.DalSaleMapper.MapBOToEF(bo));

				var record = await this.SaleRepository.Get(id);

				var businessObject = this.DalSaleMapper.MapEFToBO(record);
				var apiModel = this.BolSaleMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new SaleUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSaleServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSaleServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SaleModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SaleRepository.Delete(id);

				await this.mediator.Publish(new SaleDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiSaleServerResponseModel>> ByTransactionId(int transactionId, int limit = 0, int offset = int.MaxValue)
		{
			List<Sale> records = await this.SaleRepository.ByTransactionId(transactionId, limit, offset);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSaleServerResponseModel>> BySaleId(int saleId, int limit = int.MaxValue, int offset = 0)
		{
			List<Sale> records = await this.SaleRepository.BySaleId(saleId, limit, offset);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>f48e62de4f41eeb08e902bd8d5c1c64c</Hash>
</Codenesium>*/