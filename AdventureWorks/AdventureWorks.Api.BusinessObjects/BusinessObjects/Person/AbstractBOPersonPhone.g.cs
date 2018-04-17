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
	public abstract class AbstractBOPersonPhone
	{
		private IPersonPhoneRepository personPhoneRepository;
		private IPersonPhoneModelValidator personPhoneModelValidator;
		private ILogger logger;

		public AbstractBOPersonPhone(
			ILogger logger,
			IPersonPhoneRepository personPhoneRepository,
			IPersonPhoneModelValidator personPhoneModelValidator)

		{
			this.personPhoneRepository = personPhoneRepository;
			this.personPhoneModelValidator = personPhoneModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PersonPhoneModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.personPhoneModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.personPhoneRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			PersonPhoneModel model)
		{
			ActionResponse response = new ActionResponse(await this.personPhoneModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.personPhoneRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.personPhoneModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.personPhoneRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.personPhoneRepository.GetById(businessEntityID);
		}

		public virtual POCOPersonPhone GetByIdDirect(int businessEntityID)
		{
			return this.personPhoneRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personPhoneRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personPhoneRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPersonPhone> GetWhereDirect(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personPhoneRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>c0525a05ed5655a22304dd7e33eed387</Hash>
</Codenesium>*/