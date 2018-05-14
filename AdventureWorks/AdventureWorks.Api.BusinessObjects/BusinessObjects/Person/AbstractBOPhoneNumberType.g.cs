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
	public abstract class AbstractBOPhoneNumberType
	{
		private IPhoneNumberTypeRepository phoneNumberTypeRepository;
		private IApiPhoneNumberTypeModelValidator phoneNumberTypeModelValidator;
		private ILogger logger;

		public AbstractBOPhoneNumberType(
			ILogger logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IApiPhoneNumberTypeModelValidator phoneNumberTypeModelValidator)

		{
			this.phoneNumberTypeRepository = phoneNumberTypeRepository;
			this.phoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPhoneNumberType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.phoneNumberTypeRepository.All(skip, take, orderClause);
		}

		public virtual POCOPhoneNumberType Get(int phoneNumberTypeID)
		{
			return this.phoneNumberTypeRepository.Get(phoneNumberTypeID);
		}

		public virtual async Task<CreateResponse<POCOPhoneNumberType>> Create(
			ApiPhoneNumberTypeModel model)
		{
			CreateResponse<POCOPhoneNumberType> response = new CreateResponse<POCOPhoneNumberType>(await this.phoneNumberTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPhoneNumberType record = this.phoneNumberTypeRepository.Create(model);
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
				this.phoneNumberTypeRepository.Update(phoneNumberTypeID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int phoneNumberTypeID)
		{
			ActionResponse response = new ActionResponse(await this.phoneNumberTypeModelValidator.ValidateDeleteAsync(phoneNumberTypeID));

			if (response.Success)
			{
				this.phoneNumberTypeRepository.Delete(phoneNumberTypeID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>417c549ccc23e7235ebddec4843bd38f</Hash>
</Codenesium>*/