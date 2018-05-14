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
		private IApiPersonModelValidator personModelValidator;
		private ILogger logger;

		public AbstractBOPerson(
			ILogger logger,
			IPersonRepository personRepository,
			IApiPersonModelValidator personModelValidator)

		{
			this.personRepository = personRepository;
			this.personModelValidator = personModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personRepository.All(skip, take, orderClause);
		}

		public virtual POCOPerson Get(int businessEntityID)
		{
			return this.personRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOPerson>> Create(
			ApiPersonModel model)
		{
			CreateResponse<POCOPerson> response = new CreateResponse<POCOPerson>(await this.personModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPerson record = this.personRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPersonModel model)
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

		public List<POCOPerson> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName)
		{
			return this.personRepository.GetLastNameFirstNameMiddleName(lastName,firstName,middleName);
		}
		public List<POCOPerson> GetAdditionalContactInfo(string additionalContactInfo)
		{
			return this.personRepository.GetAdditionalContactInfo(additionalContactInfo);
		}
		public List<POCOPerson> GetDemographics(string demographics)
		{
			return this.personRepository.GetDemographics(demographics);
		}
	}
}

/*<Codenesium>
    <Hash>0d5a7377875830f4e06f9ea48ebddf86</Hash>
</Codenesium>*/