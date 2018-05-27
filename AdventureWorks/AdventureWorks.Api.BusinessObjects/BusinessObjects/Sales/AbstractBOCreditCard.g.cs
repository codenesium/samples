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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOCreditCard: AbstractBOManager
	{
		private ICreditCardRepository creditCardRepository;
		private IApiCreditCardRequestModelValidator creditCardModelValidator;
		private IBOLCreditCardMapper creditCardMapper;
		private ILogger logger;

		public AbstractBOCreditCard(
			ILogger logger,
			ICreditCardRepository creditCardRepository,
			IApiCreditCardRequestModelValidator creditCardModelValidator,
			IBOLCreditCardMapper creditCardMapper)
			: base()

		{
			this.creditCardRepository = creditCardRepository;
			this.creditCardModelValidator = creditCardModelValidator;
			this.creditCardMapper = creditCardMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCreditCardResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.creditCardRepository.All(skip, take, orderClause);

			return this.creditCardMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiCreditCardResponseModel> Get(int creditCardID)
		{
			var record = await creditCardRepository.Get(creditCardID);

			return this.creditCardMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiCreditCardResponseModel>> Create(
			ApiCreditCardRequestModel model)
		{
			CreateResponse<ApiCreditCardResponseModel> response = new CreateResponse<ApiCreditCardResponseModel>(await this.creditCardModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.creditCardMapper.MapModelToDTO(default (int), model);
				var record = await this.creditCardRepository.Create(dto);

				response.SetRecord(this.creditCardMapper.MapDTOToModel(record));
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
				var dto = this.creditCardMapper.MapModelToDTO(creditCardID, model);
				await this.creditCardRepository.Update(creditCardID, dto);
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
			DTOCreditCard record = await this.creditCardRepository.GetCardNumber(cardNumber);

			return this.creditCardMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>8bca3b43ac54c75bbeda54a6100d2ffc</Hash>
</Codenesium>*/