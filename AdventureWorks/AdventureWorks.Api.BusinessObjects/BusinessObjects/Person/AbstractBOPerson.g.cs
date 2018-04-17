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
	public abstract class AbstractBOPerson
	{
		private IPersonRepository personRepository;
		private IPersonModelValidator personModelValidator;
		private ILogger logger;

		public AbstractBOPerson(
			ILogger logger,
			IPersonRepository personRepository,
			IPersonModelValidator personModelValidator)

		{
			this.personRepository = personRepository;
			this.personModelValidator = personModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PersonModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.personModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.personRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			PersonModel model)
		{
			ActionResponse response = new ActionResponse(await this.personModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.personRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.personModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.personRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.personRepository.GetById(businessEntityID);
		}

		public virtual POCOPerson GetByIdDirect(int businessEntityID)
		{
			return this.personRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPerson> GetWhereDirect(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>8ea4d61ac0b8d94c623d17742834eb98</Hash>
</Codenesium>*/