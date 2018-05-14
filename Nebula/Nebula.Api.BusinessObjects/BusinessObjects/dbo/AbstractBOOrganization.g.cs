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
		private IApiOrganizationModelValidator organizationModelValidator;
		private ILogger logger;

		public AbstractBOOrganization(
			ILogger logger,
			IOrganizationRepository organizationRepository,
			IApiOrganizationModelValidator organizationModelValidator)

		{
			this.organizationRepository = organizationRepository;
			this.organizationModelValidator = organizationModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOOrganization> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.organizationRepository.All(skip, take, orderClause);
		}

		public virtual POCOOrganization Get(int id)
		{
			return this.organizationRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOOrganization>> Create(
			ApiOrganizationModel model)
		{
			CreateResponse<POCOOrganization> response = new CreateResponse<POCOOrganization>(await this.organizationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOOrganization record = this.organizationRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiOrganizationModel model)
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

		public POCOOrganization Name(string name)
		{
			return this.organizationRepository.Name(name);
		}
	}
}

/*<Codenesium>
    <Hash>eb8b0e6457cbf118bfbbfae49b28829b</Hash>
</Codenesium>*/