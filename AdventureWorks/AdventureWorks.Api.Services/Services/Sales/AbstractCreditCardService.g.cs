using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCreditCardService : AbstractService
	{
		private IMediator mediator;

		protected ICreditCardRepository CreditCardRepository { get; private set; }

		protected IApiCreditCardServerRequestModelValidator CreditCardModelValidator { get; private set; }

		protected IDALCreditCardMapper DalCreditCardMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCreditCardService(
			ILogger logger,
			IMediator mediator,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardServerRequestModelValidator creditCardModelValidator,
			IDALCreditCardMapper dalCreditCardMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.CreditCardRepository = creditCardRepository;
			this.CreditCardModelValidator = creditCardModelValidator;
			this.DalCreditCardMapper = dalCreditCardMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCreditCardServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.CreditCardRepository.All(limit, offset, query);

			return this.DalCreditCardMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiCreditCardServerResponseModel> Get(int creditCardID)
		{
			var record = await this.CreditCardRepository.Get(creditCardID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCreditCardMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCreditCardServerResponseModel>> Create(
			ApiCreditCardServerRequestModel model)
		{
			CreateResponse<ApiCreditCardServerResponseModel> response = ValidationResponseFactory<ApiCreditCardServerResponseModel>.CreateResponse(await this.CreditCardModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalCreditCardMapper.MapModelToBO(default(int), model);
				var record = await this.CreditCardRepository.Create(bo);

				response.SetRecord(this.DalCreditCardMapper.MapBOToModel(record));
				await this.mediator.Publish(new CreditCardCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCreditCardServerResponseModel>> Update(
			int creditCardID,
			ApiCreditCardServerRequestModel model)
		{
			var validationResult = await this.CreditCardModelValidator.ValidateUpdateAsync(creditCardID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalCreditCardMapper.MapModelToBO(creditCardID, model);
				await this.CreditCardRepository.Update(bo);

				var record = await this.CreditCardRepository.Get(creditCardID);

				var apiModel = this.DalCreditCardMapper.MapBOToModel(record);
				await this.mediator.Publish(new CreditCardUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCreditCardServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCreditCardServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int creditCardID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CreditCardModelValidator.ValidateDeleteAsync(creditCardID));

			if (response.Success)
			{
				await this.CreditCardRepository.Delete(creditCardID);

				await this.mediator.Publish(new CreditCardDeletedNotification(creditCardID));
			}

			return response;
		}

		public async virtual Task<ApiCreditCardServerResponseModel> ByCardNumber(string cardNumber)
		{
			CreditCard record = await this.CreditCardRepository.ByCardNumber(cardNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCreditCardMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCreditCardID(int creditCardID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.CreditCardRepository.SalesOrderHeadersByCreditCardID(creditCardID, limit, offset);

			return this.DalSalesOrderHeaderMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>1ed88ae77da29f7c8ea3bb765a4d446b</Hash>
</Codenesium>*/