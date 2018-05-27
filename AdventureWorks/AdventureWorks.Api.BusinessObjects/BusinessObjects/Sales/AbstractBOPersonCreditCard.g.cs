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
	public abstract class AbstractBOPersonCreditCard: AbstractBOManager
	{
		private IPersonCreditCardRepository personCreditCardRepository;
		private IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator;
		private IBOLPersonCreditCardMapper personCreditCardMapper;
		private ILogger logger;

		public AbstractBOPersonCreditCard(
			ILogger logger,
			IPersonCreditCardRepository personCreditCardRepository,
			IApiPersonCreditCardRequestModelValidator personCreditCardModelValidator,
			IBOLPersonCreditCardMapper personCreditCardMapper)
			: base()

		{
			this.personCreditCardRepository = personCreditCardRepository;
			this.personCreditCardModelValidator = personCreditCardModelValidator;
			this.personCreditCardMapper = personCreditCardMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonCreditCardResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.personCreditCardRepository.All(skip, take, orderClause);

			return this.personCreditCardMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPersonCreditCardResponseModel> Get(int businessEntityID)
		{
			var record = await personCreditCardRepository.Get(businessEntityID);

			return this.personCreditCardMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPersonCreditCardResponseModel>> Create(
			ApiPersonCreditCardRequestModel model)
		{
			CreateResponse<ApiPersonCreditCardResponseModel> response = new CreateResponse<ApiPersonCreditCardResponseModel>(await this.personCreditCardModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.personCreditCardMapper.MapModelToDTO(default (int), model);
				var record = await this.personCreditCardRepository.Create(dto);

				response.SetRecord(this.personCreditCardMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPersonCreditCardRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.personCreditCardModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.personCreditCardMapper.MapModelToDTO(businessEntityID, model);
				await this.personCreditCardRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.personCreditCardModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.personCreditCardRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>08a0d168667742f053a4ef096f4a7e51</Hash>
</Codenesium>*/