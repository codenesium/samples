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
	public abstract class AbstractBOBusinessEntityAddress
	{
		private IBusinessEntityAddressRepository businessEntityAddressRepository;
		private IBusinessEntityAddressModelValidator businessEntityAddressModelValidator;
		private ILogger logger;

		public AbstractBOBusinessEntityAddress(
			ILogger logger,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IBusinessEntityAddressModelValidator businessEntityAddressModelValidator)

		{
			this.businessEntityAddressRepository = businessEntityAddressRepository;
			this.businessEntityAddressModelValidator = businessEntityAddressModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			BusinessEntityAddressModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.businessEntityAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.businessEntityAddressRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			BusinessEntityAddressModel model)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.businessEntityAddressRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.businessEntityAddressRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual POCOBusinessEntityAddress Get(int businessEntityID)
		{
			return this.businessEntityAddressRepository.Get(businessEntityID);
		}

		public virtual List<POCOBusinessEntityAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityAddressRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>42777b434aa15c5f031ebdf078891800</Hash>
</Codenesium>*/