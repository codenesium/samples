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
		private IApiPersonPhoneModelValidator personPhoneModelValidator;
		private ILogger logger;

		public AbstractBOPersonPhone(
			ILogger logger,
			IPersonPhoneRepository personPhoneRepository,
			IApiPersonPhoneModelValidator personPhoneModelValidator)

		{
			this.personPhoneRepository = personPhoneRepository;
			this.personPhoneModelValidator = personPhoneModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPersonPhone> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.personPhoneRepository.All(skip, take, orderClause);
		}

		public virtual POCOPersonPhone Get(int businessEntityID)
		{
			return this.personPhoneRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOPersonPhone>> Create(
			ApiPersonPhoneModel model)
		{
			CreateResponse<POCOPersonPhone> response = new CreateResponse<POCOPersonPhone>(await this.personPhoneModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPersonPhone record = this.personPhoneRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPersonPhoneModel model)
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

		public List<POCOPersonPhone> GetPhoneNumber(string phoneNumber)
		{
			return this.personPhoneRepository.GetPhoneNumber(phoneNumber);
		}
	}
}

/*<Codenesium>
    <Hash>396b7502abe1be9fc5d38abad5a47dea</Hash>
</Codenesium>*/