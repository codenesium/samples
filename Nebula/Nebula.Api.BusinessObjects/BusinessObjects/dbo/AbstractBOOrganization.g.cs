using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOOrganization
	{
		private IOrganizationRepository organizationRepository;
		private IOrganizationModelValidator organizationModelValidator;
		private ILogger logger;

		public AbstractBOOrganization(
			ILogger logger,
			IOrganizationRepository organizationRepository,
			IOrganizationModelValidator organizationModelValidator)

		{
			this.organizationRepository = organizationRepository;
			this.organizationModelValidator = organizationModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			OrganizationModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.organizationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.organizationRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			OrganizationModel model)
		{
			ActionResponse response = new ActionResponse(await this.organizationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.organizationRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.organizationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.organizationRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOOrganization Get(int id)
		{
			return this.organizationRepository.Get(id);
		}

		public virtual List<POCOOrganization> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.organizationRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>dc0c696d879c88cca2470f7fd52299ca</Hash>
</Codenesium>*/