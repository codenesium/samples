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
	public abstract class AbstractBOPassword: AbstractBOManager
	{
		private IPasswordRepository passwordRepository;
		private IApiPasswordModelValidator passwordModelValidator;
		private ILogger logger;

		public AbstractBOPassword(
			ILogger logger,
			IPasswordRepository passwordRepository,
			IApiPasswordModelValidator passwordModelValidator)
			: base()

		{
			this.passwordRepository = passwordRepository;
			this.passwordModelValidator = passwordModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPassword>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.passwordRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPassword> Get(int businessEntityID)
		{
			return this.passwordRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOPassword>> Create(
			ApiPasswordModel model)
		{
			CreateResponse<POCOPassword> response = new CreateResponse<POCOPassword>(await this.passwordModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPassword record = await this.passwordRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPasswordModel model)
		{
			ActionResponse response = new ActionResponse(await this.passwordModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				await this.passwordRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.passwordModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.passwordRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d9b5aa3f100dab9d4ab8aac76fa2011a</Hash>
</Codenesium>*/