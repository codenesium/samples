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
	public abstract class AbstractBOEmailAddress
	{
		private IEmailAddressRepository emailAddressRepository;
		private IEmailAddressModelValidator emailAddressModelValidator;
		private ILogger logger;

		public AbstractBOEmailAddress(
			ILogger logger,
			IEmailAddressRepository emailAddressRepository,
			IEmailAddressModelValidator emailAddressModelValidator)

		{
			this.emailAddressRepository = emailAddressRepository;
			this.emailAddressModelValidator = emailAddressModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			EmailAddressModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.emailAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.emailAddressRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			EmailAddressModel model)
		{
			ActionResponse response = new ActionResponse(await this.emailAddressModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.emailAddressRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.emailAddressModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.emailAddressRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual POCOEmailAddress Get(int businessEntityID)
		{
			return this.emailAddressRepository.Get(businessEntityID);
		}

		public virtual List<POCOEmailAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.emailAddressRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>a31f74bf1c429fac490c1d0941c18468</Hash>
</Codenesium>*/