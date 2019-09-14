using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class SaleService : AbstractService, ISaleService
	{
		private MediatR.IMediator mediator;

		protected ISaleRepository SaleRepository { get; private set; }

		protected IApiSaleServerRequestModelValidator SaleModelValidator { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		private ILogger logger;

		public SaleService(
			ILogger<ISaleService> logger,
			MediatR.IMediator mediator,
			ISaleRepository saleRepository,
			IApiSaleServerRequestModelValidator saleModelValidator,
			IDALSaleMapper dalSaleMapper)
			: base()
		{
			this.SaleRepository = saleRepository;
			this.SaleModelValidator = saleModelValidator;
			this.DalSaleMapper = dalSaleMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSaleServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Sale> records = await this.SaleRepository.All(limit, offset, query);

			return this.DalSaleMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSaleServerResponseModel> Get(int id)
		{
			Sale record = await this.SaleRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSaleMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSaleServerResponseModel>> Create(
			ApiSaleServerRequestModel model)
		{
			CreateResponse<ApiSaleServerResponseModel> response = ValidationResponseFactory<ApiSaleServerResponseModel>.CreateResponse(await this.SaleModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Sale record = this.DalSaleMapper.MapModelToEntity(default(int), model);
				record = await this.SaleRepository.Create(record);

				response.SetRecord(this.DalSaleMapper.MapEntityToModel(record));
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
				Sale record = this.DalSaleMapper.MapModelToEntity(id, model);
				await this.SaleRepository.Update(record);

				record = await this.SaleRepository.Get(id);

				ApiSaleServerResponseModel apiModel = this.DalSaleMapper.MapEntityToModel(record);
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
	}
}

/*<Codenesium>
    <Hash>d685f36ec376b0268dcde7cb7e2a57dc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/