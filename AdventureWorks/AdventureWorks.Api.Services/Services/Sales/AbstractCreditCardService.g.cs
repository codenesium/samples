using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCreditCardService : AbstractService
	{
		protected ICreditCardRepository CreditCardRepository { get; private set; }

		protected IApiCreditCardServerRequestModelValidator CreditCardModelValidator { get; private set; }

		protected IBOLCreditCardMapper BolCreditCardMapper { get; private set; }

		protected IDALCreditCardMapper DalCreditCardMapper { get; private set; }

		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCreditCardService(
			ILogger logger,
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

				response.SetRecord(this.BolCreditCardMapper.MapBOToModel(this.DalCreditCardMapper.MapEFToBO(record)));
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

				return ValidationResponseFactory<ApiCreditCardServerResponseModel>.UpdateResponse(this.BolCreditCardMapper.MapBOToModel(this.DalCreditCardMapper.MapEFToBO(record)));
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
    <Hash>d8516250d1cb1523d9131aafa3569e93</Hash>
</Codenesium>*/