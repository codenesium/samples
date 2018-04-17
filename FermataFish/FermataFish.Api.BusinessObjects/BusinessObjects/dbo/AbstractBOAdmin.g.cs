using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOAdmin
	{
		private IAdminRepository adminRepository;
		private IAdminModelValidator adminModelValidator;
		private ILogger logger;

		public AbstractBOAdmin(
			ILogger logger,
			IAdminRepository adminRepository,
			IAdminModelValidator adminModelValidator)

		{
			this.adminRepository = adminRepository;
			this.adminModelValidator = adminModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			AdminModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.adminModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.adminRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			AdminModel model)
		{
			ActionResponse response = new ActionResponse(await this.adminModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.adminRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.adminModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.adminRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.adminRepository.GetById(id);
		}

		public virtual POCOAdmin GetByIdDirect(int id)
		{
			return this.adminRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAdmin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.adminRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.adminRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOAdmin> GetWhereDirect(Expression<Func<EFAdmin, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.adminRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>d3854cc90aa19a24127c3fe8156dbafb</Hash>
</Codenesium>*/