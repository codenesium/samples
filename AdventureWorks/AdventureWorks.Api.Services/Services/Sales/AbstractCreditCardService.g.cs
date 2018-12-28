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

		protected IBOLCreditCardMapper BolCreditCardMapper { get; private set; }

		protected IDALCreditCardMapper DalCreditCardMapper { get; private set; }

		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCreditCardService(
			ILogger logger,
			IMediator mediator,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardServerRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper bolCreditCardMapper,
			IDALCreditCardMapper dalCreditCardMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.CreditCardRepository = creditCardRepository;
			this.CreditCardModelValidator = creditCardModelValidator;
			this.BolCreditCardMapper = bolCreditCardMapper;
			this.DalCreditCardMapper = dalCreditCardMapper;
			this.BolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCreditCardServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CreditCardRepository.All(limit, offset);

			return this.BolCreditCardMapper.MapBOToModel(this.DalCreditCardMapper.MapEFToBO(records));
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
				return this.BolCreditCardMapper.MapBOToModel(this.DalCreditCardMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCreditCardServerResponseModel>> Create(
			ApiCreditCardServerRequestModel model)
		{
			CreateResponse<ApiCreditCardServerResponseModel> response = ValidationResponseFactory<ApiCreditCardServerResponseModel>.CreateResponse(await this.CreditCardModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCreditCardMapper.MapModelToBO(default(int), model);
				var record = await this.CreditCardRepository.Create(this.DalCreditCardMapper.MapBOToEF(bo));

				var businessObject = this.DalCreditCardMapper.MapEFToBO(record);
				response.SetRecord(this.BolCreditCardMapper.MapBOToModel(businessObject));
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
				var bo = this.BolCreditCardMapper.MapModelToBO(creditCardID, model);
				await this.CreditCardRepository.Update(this.DalCreditCardMapper.MapBOToEF(bo));

				var record = await this.CreditCardRepository.Get(creditCardID);

				var businessObject = this.DalCreditCardMapper.MapEFToBO(record);
				var apiModel = this.BolCreditCardMapper.MapBOToModel(businessObject);
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
				return this.BolCreditCardMapper.MapBOToModel(this.DalCreditCardMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCreditCardID(int creditCardID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.CreditCardRepository.SalesOrderHeadersByCreditCardID(creditCardID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4c02a1f1b33e7ffa359b2e647b49e59d</Hash>
</Codenesium>*/