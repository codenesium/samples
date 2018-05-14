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
		private IApiContactTypeModelValidator contactTypeModelValidator;
		private ILogger logger;

		public AbstractBOContactType(
			ILogger logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeModelValidator contactTypeModelValidator)

		{
			this.contactTypeRepository = contactTypeRepository;
			this.contactTypeModelValidator = contactTypeModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOContactType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.contactTypeRepository.All(skip, take, orderClause);
		}

		public virtual POCOContactType Get(int contactTypeID)
		{
			return this.contactTypeRepository.Get(contactTypeID);
		}

		public virtual async Task<CreateResponse<POCOContactType>> Create(
			ApiContactTypeModel model)
		{
			CreateResponse<POCOContactType> response = new CreateResponse<POCOContactType>(await this.contactTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOContactType record = this.contactTypeRepository.Create(model);
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

		public POCOContactType GetName(string name)
		{
			return this.contactTypeRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>dafcc226c2dcce43b8dd874c36cf5d39</Hash>
</Codenesium>*/