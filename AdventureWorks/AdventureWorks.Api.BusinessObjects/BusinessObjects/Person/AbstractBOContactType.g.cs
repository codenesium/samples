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
	public abstract class AbstractBOContactType: AbstractBOManager
	{
		private IContactTypeRepository contactTypeRepository;
		private IApiContactTypeModelValidator contactTypeModelValidator;
		private ILogger logger;

		public AbstractBOContactType(
			ILogger logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeModelValidator contactTypeModelValidator)
			: base()

		{
			this.contactTypeRepository = contactTypeRepository;
			this.contactTypeModelValidator = contactTypeModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOContactType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.contactTypeRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOContactType> Get(int contactTypeID)
		{
			return this.contactTypeRepository.Get(contactTypeID);
		}

		public virtual async Task<CreateResponse<POCOContactType>> Create(
			ApiContactTypeModel model)
		{
			CreateResponse<POCOContactType> response = new CreateResponse<POCOContactType>(await this.contactTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOContactType record = await this.contactTypeRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int contactTypeID,
			ApiContactTypeModel model)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateUpdateAsync(contactTypeID, model));

			if (response.Success)
			{
				await this.contactTypeRepository.Update(contactTypeID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int contactTypeID)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateDeleteAsync(contactTypeID));

			if (response.Success)
			{
				await this.contactTypeRepository.Delete(contactTypeID);
			}
			return response;
		}

		public async Task<POCOContactType> GetName(string name)
		{
			return await this.contactTypeRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>cb55d6c95732bc9e73c4528c15b79575</Hash>
</Codenesium>*/