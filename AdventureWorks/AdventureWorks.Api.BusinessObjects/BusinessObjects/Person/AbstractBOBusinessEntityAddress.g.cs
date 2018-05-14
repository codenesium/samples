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
		private IApiBusinessEntityAddressModelValidator businessEntityAddressModelValidator;
		private ILogger logger;

		public AbstractBOBusinessEntityAddress(
			ILogger logger,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IApiBusinessEntityAddressModelValidator businessEntityAddressModelValidator)

		{
			this.businessEntityAddressRepository = businessEntityAddressRepository;
			this.businessEntityAddressModelValidator = businessEntityAddressModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOBusinessEntityAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityAddressRepository.All(skip, take, orderClause);
		}

		public virtual POCOBusinessEntityAddress Get(int businessEntityID)
		{
			return this.businessEntityAddressRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOBusinessEntityAddress>> Create(
			ApiBusinessEntityAddressModel model)
		{
			CreateResponse<POCOBusinessEntityAddress> response = new CreateResponse<POCOBusinessEntityAddress>(await this.businessEntityAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBusinessEntityAddress record = this.businessEntityAddressRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiBusinessEntityAddressModel model)
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

		public List<POCOBusinessEntityAddress> GetAddressID(int addressID)
		{
			return this.businessEntityAddressRepository.GetAddressID(addressID);
		}
		public List<POCOBusinessEntityAddress> GetAddressTypeID(int addressTypeID)
		{
			return this.businessEntityAddressRepository.GetAddressTypeID(addressTypeID);
		}
	}
}

/*<Codenesium>
    <Hash>6ad8b5799fe7aaf4ead7f92486b97860</Hash>
</Codenesium>*/