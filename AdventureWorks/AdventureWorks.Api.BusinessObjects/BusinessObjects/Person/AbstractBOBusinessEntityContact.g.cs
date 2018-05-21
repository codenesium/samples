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
	public abstract class AbstractBOBusinessEntityContact: AbstractBOManager
	{
		private IBusinessEntityContactRepository businessEntityContactRepository;
		private IApiBusinessEntityContactModelValidator businessEntityContactModelValidator;
		private ILogger logger;

		public AbstractBOBusinessEntityContact(
			ILogger logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactModelValidator businessEntityContactModelValidator)
			: base()

		{
			this.businessEntityContactRepository = businessEntityContactRepository;
			this.businessEntityContactModelValidator = businessEntityContactModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOBusinessEntityContact>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityContactRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOBusinessEntityContact> Get(int businessEntityID)
		{
			return this.businessEntityContactRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOBusinessEntityContact>> Create(
			ApiBusinessEntityContactModel model)
		{
			CreateResponse<POCOBusinessEntityContact> response = new CreateResponse<POCOBusinessEntityContact>(await this.businessEntityContactModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBusinessEntityContact record = await this.businessEntityContactRepository.Create(model);

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
				await this.businessEntityContactRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityContactModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.businessEntityContactRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<POCOBusinessEntityContact>> GetContactTypeID(int contactTypeID)
		{
			return await this.businessEntityContactRepository.GetContactTypeID(contactTypeID);
		}
		public async Task<List<POCOBusinessEntityContact>> GetPersonID(int personID)
		{
			return await this.businessEntityContactRepository.GetPersonID(personID);
		}
	}
}

/*<Codenesium>
    <Hash>8d52ba9b01aa2fa5dbebb7adeeac5b69</Hash>
</Codenesium>*/