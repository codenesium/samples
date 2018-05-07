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
	public abstract class AbstractBOPassword
	{
		private IPasswordRepository passwordRepository;
		private IPasswordModelValidator passwordModelValidator;
		private ILogger logger;

		public AbstractBOPassword(
			ILogger logger,
			IPasswordRepository passwordRepository,
			IPasswordModelValidator passwordModelValidator)

		{
			this.passwordRepository = passwordRepository;
			this.passwordModelValidator = passwordModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PasswordModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.passwordModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.passwordRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			PasswordModel model)
		{
			ActionResponse response = new ActionResponse(await this.passwordModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.passwordRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.passwordModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.passwordRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual POCOPassword Get(int businessEntityID)
		{
			return this.passwordRepository.Get(businessEntityID);
		}

		public virtual List<POCOPassword> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.passwordRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>ea313870c5eb64d70e1e4e4a823fb1e1</Hash>
</Codenesium>*/