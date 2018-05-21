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
	public abstract class AbstractBOEmailAddress: AbstractBOManager
	{
		private IEmailAddressRepository emailAddressRepository;
		private IApiEmailAddressModelValidator emailAddressModelValidator;
		private ILogger logger;

		public AbstractBOEmailAddress(
			ILogger logger,
			IEmailAddressRepository emailAddressRepository,
			IApiEmailAddressModelValidator emailAddressModelValidator)
			: base()

		{
			this.emailAddressRepository = emailAddressRepository;
			this.emailAddressModelValidator = emailAddressModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOEmailAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.emailAddressRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOEmailAddress> Get(int businessEntityID)
		{
			return this.emailAddressRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOEmailAddress>> Create(
			ApiEmailAddressModel model)
		{
			CreateResponse<POCOEmailAddress> response = new CreateResponse<POCOEmailAddress>(await this.emailAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOEmailAddress record = await this.emailAddressRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiEmailAddressModel model)
		{
			ActionResponse response = new ActionResponse(await this.emailAddressModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				await this.emailAddressRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.emailAddressModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.emailAddressRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<POCOEmailAddress>> GetEmailAddress(string emailAddress1)
		{
			return await this.emailAddressRepository.GetEmailAddress(emailAddress1);
		}
	}
}

/*<Codenesium>
    <Hash>d550a3145b28aa3f4830198f959f2f76</Hash>
</Codenesium>*/