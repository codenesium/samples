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
		private IApiBusinessEntityContactModelValidator businessEntityContactModelValidator;
		private ILogger logger;

		public AbstractBOBusinessEntityContact(
			ILogger logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactModelValidator businessEntityContactModelValidator)

		{
			this.businessEntityContactRepository = businessEntityContactRepository;
			this.businessEntityContactModelValidator = businessEntityContactModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOBusinessEntityContact> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityContactRepository.All(skip, take, orderClause);
		}

		public virtual POCOBusinessEntityContact Get(int businessEntityID)
		{
			return this.businessEntityContactRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOBusinessEntityContact>> Create(
			ApiBusinessEntityContactModel model)
		{
			CreateResponse<POCOBusinessEntityContact> response = new CreateResponse<POCOBusinessEntityContact>(await this.businessEntityContactModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBusinessEntityContact record = this.businessEntityContactRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiBusinessEntityContactModel model)
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

		public List<POCOBusinessEntityContact> GetContactTypeID(int contactTypeID)
		{
			return this.businessEntityContactRepository.GetContactTypeID(contactTypeID);
		}
		public List<POCOBusinessEntityContact> GetPersonID(int personID)
		{
			return this.businessEntityContactRepository.GetPersonID(personID);
		}
	}
}

/*<Codenesium>
    <Hash>ffadd98af3a9ccadee991b56c27eaf88</Hash>
</Codenesium>*/