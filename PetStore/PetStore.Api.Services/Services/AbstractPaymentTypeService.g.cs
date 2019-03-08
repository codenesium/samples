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
		private MediatR.IMediator mediator;

		protected IPaymentTypeRepository PaymentTypeRepository { get; private set; }

		protected IApiPaymentTypeServerRequestModelValidator PaymentTypeModelValidator { get; private set; }

		protected IDALPaymentTypeMapper DalPaymentTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractPaymentTypeService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPaymentTypeRepository paymentTypeRepository,
			IApiPaymentTypeServerRequestModelValidator paymentTypeModelValidator,
			IDALPaymentTypeMapper dalPaymentTypeMapper)
			: base()
		{
			this.PaymentTypeRepository = paymentTypeRepository;
			this.PaymentTypeModelValidator = paymentTypeModelValidator;
			this.DalPaymentTypeMapper = dalPaymentTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPaymentTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PaymentType> records = await this.PaymentTypeRepository.All(limit, offset, query);

			return this.DalPaymentTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPaymentTypeServerResponseModel> Get(int id)
		{
			PaymentType record = await this.PaymentTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPaymentTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPaymentTypeServerResponseModel>> Create(
			ApiPaymentTypeServerRequestModel model)
		{
			CreateResponse<ApiPaymentTypeServerResponseModel> response = ValidationResponseFactory<ApiPaymentTypeServerResponseModel>.CreateResponse(await this.PaymentTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PaymentType record = this.DalPaymentTypeMapper.MapModelToEntity(default(int), model);
				record = await this.PaymentTypeRepository.Create(record);

				response.SetRecord(this.DalPaymentTypeMapper.MapEntityToModel(record));
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
				PaymentType record = this.DalPaymentTypeMapper.MapModelToEntity(id, model);
				await this.PaymentTypeRepository.Update(record);

				record = await this.PaymentTypeRepository.Get(id);

				ApiPaymentTypeServerResponseModel apiModel = this.DalPaymentTypeMapper.MapEntityToModel(record);
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
	}
}

/*<Codenesium>
    <Hash>253587b3629241a8936c4076822fd399</Hash>
</Codenesium>*/