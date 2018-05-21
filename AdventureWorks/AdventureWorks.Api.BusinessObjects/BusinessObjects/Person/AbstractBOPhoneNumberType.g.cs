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
	public abstract class AbstractBOPhoneNumberType: AbstractBOManager
	{
		private IPhoneNumberTypeRepository phoneNumberTypeRepository;
		private IApiPhoneNumberTypeModelValidator phoneNumberTypeModelValidator;
		private ILogger logger;

		public AbstractBOPhoneNumberType(
			ILogger logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeModelValidator phoneNumberTypeModelValidator)
			: base()

		{
			this.phoneNumberTypeRepository = phoneNumberTypeRepository;
			this.phoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPhoneNumberType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.phoneNumberTypeRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPhoneNumberType> Get(int phoneNumberTypeID)
		{
			return this.phoneNumberTypeRepository.Get(phoneNumberTypeID);
		}

		public virtual async Task<CreateResponse<POCOPhoneNumberType>> Create(
			ApiPhoneNumberTypeModel model)
		{
			CreateResponse<POCOPhoneNumberType> response = new CreateResponse<POCOPhoneNumberType>(await this.phoneNumberTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPhoneNumberType record = await this.phoneNumberTypeRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeModel model)
		{
			ActionResponse response = new ActionResponse(await this.phoneNumberTypeModelValidator.ValidateUpdateAsync(phoneNumberTypeID, model));

			if (response.Success)
			{
				await this.phoneNumberTypeRepository.Update(phoneNumberTypeID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int phoneNumberTypeID)
		{
			ActionResponse response = new ActionResponse(await this.phoneNumberTypeModelValidator.ValidateDeleteAsync(phoneNumberTypeID));

			if (response.Success)
			{
				await this.phoneNumberTypeRepository.Delete(phoneNumberTypeID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>24eaeeee4d23a870ecfbfa8b1ee1fa4b</Hash>
</Codenesium>*/