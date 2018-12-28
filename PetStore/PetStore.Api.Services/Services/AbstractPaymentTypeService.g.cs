using MediatR;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractPaymentTypeService : AbstractService
	{
		private IMediator mediator;

		protected IPaymentTypeRepository PaymentTypeRepository { get; private set; }

		protected IApiPaymentTypeServerRequestModelValidator PaymentTypeModelValidator { get; private set; }

		protected IBOLPaymentTypeMapper BolPaymentTypeMapper { get; private set; }

		protected IDALPaymentTypeMapper DalPaymentTypeMapper { get; private set; }

		protected IBOLSaleMapper BolSaleMapper { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		private ILogger logger;

		public AbstractPaymentTypeService(
			ILogger logger,
			IMediator mediator,
			IPaymentTypeRepository paymentTypeRepository,
			IApiPaymentTypeServerRequestModelValidator paymentTypeModelValidator,
			IBOLPaymentTypeMapper bolPaymentTypeMapper,
			IDALPaymentTypeMapper dalPaymentTypeMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base()
		{
			this.PaymentTypeRepository = paymentTypeRepository;
			this.PaymentTypeModelValidator = paymentTypeModelValidator;
			this.BolPaymentTypeMapper = bolPaymentTypeMapper;
			this.DalPaymentTypeMapper = dalPaymentTypeMapper;
			this.BolSaleMapper = bolSaleMapper;
			this.DalSaleMapper = dalSaleMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPaymentTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PaymentTypeRepository.All(limit, offset);

			return this.BolPaymentTypeMapper.MapBOToModel(this.DalPaymentTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPaymentTypeServerResponseModel> Get(int id)
		{
			var record = await this.PaymentTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPaymentTypeMapper.MapBOToModel(this.DalPaymentTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPaymentTypeServerResponseModel>> Create(
			ApiPaymentTypeServerRequestModel model)
		{
			CreateResponse<ApiPaymentTypeServerResponseModel> response = ValidationResponseFactory<ApiPaymentTypeServerResponseModel>.CreateResponse(await this.PaymentTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPaymentTypeMapper.MapModelToBO(default(int), model);
				var record = await this.PaymentTypeRepository.Create(this.DalPaymentTypeMapper.MapBOToEF(bo));

				var businessObject = this.DalPaymentTypeMapper.MapEFToBO(record);
				response.SetRecord(this.BolPaymentTypeMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new PaymentTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPaymentTypeServerResponseModel>> Update(
			int id,
			ApiPaymentTypeServerRequestModel model)
		{
			var validationResult = await this.PaymentTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPaymentTypeMapper.MapModelToBO(id, model);
				await this.PaymentTypeRepository.Update(this.DalPaymentTypeMapper.MapBOToEF(bo));

				var record = await this.PaymentTypeRepository.Get(id);

				var businessObject = this.DalPaymentTypeMapper.MapEFToBO(record);
				var apiModel = this.BolPaymentTypeMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new PaymentTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPaymentTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPaymentTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PaymentTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PaymentTypeRepository.Delete(id);

				await this.mediator.Publish(new PaymentTypeDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiSaleServerResponseModel>> SalesByPaymentTypeId(int paymentTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<Sale> records = await this.PaymentTypeRepository.SalesByPaymentTypeId(paymentTypeId, limit, offset);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>f0069c2636e1ade7613cece3daaa607e</Hash>
</Codenesium>*/