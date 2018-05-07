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
	public abstract class AbstractBOBusinessEntityContact
	{
		private IBusinessEntityContactRepository businessEntityContactRepository;
		private IBusinessEntityContactModelValidator businessEntityContactModelValidator;
		private ILogger logger;

		public AbstractBOBusinessEntityContact(
			ILogger logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IBusinessEntityContactModelValidator businessEntityContactModelValidator)

		{
			this.businessEntityContactRepository = businessEntityContactRepository;
			this.businessEntityContactModelValidator = businessEntityContactModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			BusinessEntityContactModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.businessEntityContactModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.businessEntityContactRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			BusinessEntityContactModel model)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityContactModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.businessEntityContactRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityContactModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.businessEntityContactRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual POCOBusinessEntityContact Get(int businessEntityID)
		{
			return this.businessEntityContactRepository.Get(businessEntityID);
		}

		public virtual List<POCOBusinessEntityContact> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityContactRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>58268dc5d6bb82ef14f3c1ad97c2e079</Hash>
</Codenesium>*/