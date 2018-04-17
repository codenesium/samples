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

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.businessEntityContactRepository.GetById(businessEntityID);
		}

		public virtual POCOBusinessEntityContact GetByIdDirect(int businessEntityID)
		{
			return this.businessEntityContactRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityContactRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityContactRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOBusinessEntityContact> GetWhereDirect(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityContactRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>da1b73b1676af84208b52b1d4ea92eaf</Hash>
</Codenesium>*/