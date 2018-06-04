using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCreditCardService: AbstractService
	{
		private ICreditCardRepository creditCardRepository;
		private IApiCreditCardRequestModelValidator creditCardModelValidator;
		private IBOLCreditCardMapper BOLCreditCardMapper;
		private IDALCreditCardMapper DALCreditCardMapper;
		private ILogger logger;

		public AbstractCreditCardService(
			ILogger logger,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper bolcreditCardMapper,
			IDALCreditCardMapper dalcreditCardMapper)
			: base()

		{
			this.creditCardRepository = creditCardRepository;
			this.creditCardModelValidator = creditCardModelValidator;
			this.BOLCreditCardMapper = bolcreditCardMapper;
			this.DALCreditCardMapper = dalcreditCardMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCreditCardResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.creditCardRepository.All(skip, take, orderClause);

			return this.BOLCreditCardMapper.MapBOToModel(this.DALCreditCardMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCreditCardResponseModel> Get(int creditCardID)
		{
			var record = await creditCardRepository.Get(creditCardID);

			return this.BOLCreditCardMapper.MapBOToModel(this.DALCreditCardMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCreditCardResponseModel>> Create(
			ApiCreditCardRequestModel model)
		{
			CreateResponse<ApiCreditCardResponseModel> response = new CreateResponse<ApiCreditCardResponseModel>(await this.creditCardModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLCreditCardMapper.MapModelToBO(default (int), model);
				var record = await this.creditCardRepository.Create(this.DALCreditCardMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLCreditCardMapper.MapBOToModel(this.DALCreditCardMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int creditCardID,
			ApiCreditCardRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.creditCardModelValidator.ValidateUpdateAsync(creditCardID, model));

			if (response.Success)
			{
				var bo = this.BOLCreditCardMapper.MapModelToBO(creditCardID, model);
				await this.creditCardRepository.Update(this.DALCreditCardMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int creditCardID)
		{
			ActionResponse response = new ActionResponse(await this.creditCardModelValidator.ValidateDeleteAsync(creditCardID));

			if (response.Success)
			{
				await this.creditCardRepository.Delete(creditCardID);
			}
			return response;
		}

		public async Task<ApiCreditCardResponseModel> GetCardNumber(string cardNumber)
		{
			CreditCard record = await this.creditCardRepository.GetCardNumber(cardNumber);

			return this.BOLCreditCardMapper.MapBOToModel(this.DALCreditCardMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>d9848fcfbcff6441fd01128fa291aeed</Hash>
</Codenesium>*/