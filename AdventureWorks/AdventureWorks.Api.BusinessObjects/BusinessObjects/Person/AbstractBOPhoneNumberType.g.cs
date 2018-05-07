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
		private IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator;
		private ILogger logger;

		public AbstractBOPhoneNumberType(
			ILogger logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator)

		{
			this.phoneNumberTypeRepository = phoneNumberTypeRepository;
			this.phoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PhoneNumberTypeModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.phoneNumberTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.phoneNumberTypeRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int phoneNumberTypeID,
			PhoneNumberTypeModel model)
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

		public virtual POCOPhoneNumberType Get(int phoneNumberTypeID)
		{
			return this.phoneNumberTypeRepository.Get(phoneNumberTypeID);
		}

		public virtual List<POCOPhoneNumberType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.phoneNumberTypeRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>60b432e7d1b375a62eb29a47074a280e</Hash>
</Codenesium>*/