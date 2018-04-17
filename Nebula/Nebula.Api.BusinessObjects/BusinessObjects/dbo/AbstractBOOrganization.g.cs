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

		public virtual ApiResponse GetById(int id)
		{
			return this.organizationRepository.GetById(id);
		}

		public virtual POCOOrganization GetByIdDirect(int id)
		{
			return this.organizationRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFOrganization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.organizationRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.organizationRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOOrganization> GetWhereDirect(Expression<Func<EFOrganization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.organizationRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>908dea58b38c56a24755ba7b4e7df5d6</Hash>
</Codenesium>*/