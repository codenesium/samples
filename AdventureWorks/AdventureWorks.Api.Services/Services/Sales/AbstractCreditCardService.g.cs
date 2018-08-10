using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCreditCardService : AbstractService
	{
		protected ICreditCardRepository CreditCardRepository { get; private set; }

		protected IApiCreditCardRequestModelValidator CreditCardModelValidator { get; private set; }

		protected IBOLCreditCardMapper BolCreditCardMapper { get; private set; }

		protected IDALCreditCardMapper DalCreditCardMapper { get; private set; }

		protected IBOLPersonCreditCardMapper BolPersonCreditCardMapper { get; private set; }

		protected IDALPersonCreditCardMapper DalPersonCreditCardMapper { get; private set; }
		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCreditCardService(
			ILogger logger,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper bolCreditCardMapper,
			IDALCreditCardMapper dalCreditCardMapper,
			IBOLPersonCreditCardMapper bolPersonCreditCardMapper,
			IDALPersonCreditCardMapper dalPersonCreditCardMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.CreditCardRepository = creditCardRepository;
			this.CreditCardModelValidator = creditCardModelValidator;
			this.BolCreditCardMapper = bolCreditCardMapper;
			this.DalCreditCardMapper = dalCreditCardMapper;
			this.BolPersonCreditCardMapper = bolPersonCreditCardMapper;
			this.DalPersonCreditCardMapper = dalPersonCreditCardMapper;
			this.BolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCreditCardResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CreditCardRepository.All(limit, offset);

			return this.BolCreditCardMapper.MapBOToModel(this.DalCreditCardMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCreditCardResponseModel> Get(int creditCardID)
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

		public virtual async Task<CreateResponse<ApiCreditCardResponseModel>> Create(
			ApiCreditCardRequestModel model)
		{
			CreateResponse<ApiCreditCardResponseModel> response = new CreateResponse<ApiCreditCardResponseModel>(await this.CreditCardModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCreditCardMapper.MapModelToBO(default(int), model);
				var record = await this.CreditCardRepository.Create(this.DalCreditCardMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCreditCardMapper.MapBOToModel(this.DalCreditCardMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCreditCardResponseModel>> Update(
			int creditCardID,
			ApiCreditCardRequestModel model)
		{
			var validationResult = await this.CreditCardModelValidator.ValidateUpdateAsync(creditCardID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCreditCardMapper.MapModelToBO(creditCardID, model);
				await this.CreditCardRepository.Update(this.DalCreditCardMapper.MapBOToEF(bo));

				var record = await this.CreditCardRepository.Get(creditCardID);

				return new UpdateResponse<ApiCreditCardResponseModel>(this.BolCreditCardMapper.MapBOToModel(this.DalCreditCardMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCreditCardResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int creditCardID)
		{
			ActionResponse response = new ActionResponse(await this.CreditCardModelValidator.ValidateDeleteAsync(creditCardID));
			if (response.Success)
			{
				await this.CreditCardRepository.Delete(creditCardID);
			}

			return response;
		}

		public async Task<ApiCreditCardResponseModel> ByCardNumber(string cardNumber)
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

		public async virtual Task<List<ApiPersonCreditCardResponseModel>> PersonCreditCards(int creditCardID, int limit = int.MaxValue, int offset = 0)
		{
			List<PersonCreditCard> records = await this.CreditCardRepository.PersonCreditCards(creditCardID, limit, offset);

			return this.BolPersonCreditCardMapper.MapBOToModel(this.DalPersonCreditCardMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int creditCardID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.CreditCardRepository.SalesOrderHeaders(creditCardID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1bf49201a3bdd907b4ebd63ceb7dbe1c</Hash>
</Codenesium>*/