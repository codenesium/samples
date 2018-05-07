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
	public abstract class AbstractBOContactType
	{
		private IContactTypeRepository contactTypeRepository;
		private IContactTypeModelValidator contactTypeModelValidator;
		private ILogger logger;

		public AbstractBOContactType(
			ILogger logger,
			IContactTypeRepository contactTypeRepository,
			IContactTypeModelValidator contactTypeModelValidator)

		{
			this.contactTypeRepository = contactTypeRepository;
			this.contactTypeModelValidator = contactTypeModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ContactTypeModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.contactTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.contactTypeRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int contactTypeID,
			ContactTypeModel model)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateUpdateAsync(contactTypeID, model));

			if (response.Success)
			{
				this.contactTypeRepository.Update(contactTypeID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int contactTypeID)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateDeleteAsync(contactTypeID));

			if (response.Success)
			{
				this.contactTypeRepository.Delete(contactTypeID);
			}
			return response;
		}

		public virtual POCOContactType Get(int contactTypeID)
		{
			return this.contactTypeRepository.Get(contactTypeID);
		}

		public virtual List<POCOContactType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.contactTypeRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>4604d504c8b15134abeed2167296f6a4</Hash>
</Codenesium>*/