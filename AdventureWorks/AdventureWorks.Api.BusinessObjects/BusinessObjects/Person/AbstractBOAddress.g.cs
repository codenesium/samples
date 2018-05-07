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
	public abstract class AbstractBOAddress
	{
		private IAddressRepository addressRepository;
		private IAddressModelValidator addressModelValidator;
		private ILogger logger;

		public AbstractBOAddress(
			ILogger logger,
			IAddressRepository addressRepository,
			IAddressModelValidator addressModelValidator)

		{
			this.addressRepository = addressRepository;
			this.addressModelValidator = addressModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			AddressModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.addressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.addressRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int addressID,
			AddressModel model)
		{
			ActionResponse response = new ActionResponse(await this.addressModelValidator.ValidateUpdateAsync(addressID, model));

			if (response.Success)
			{
				this.addressRepository.Update(addressID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int addressID)
		{
			ActionResponse response = new ActionResponse(await this.addressModelValidator.ValidateDeleteAsync(addressID));

			if (response.Success)
			{
				this.addressRepository.Delete(addressID);
			}
			return response;
		}

		public virtual POCOAddress Get(int addressID)
		{
			return this.addressRepository.Get(addressID);
		}

		public virtual List<POCOAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>2ea9f24262061f494d1c05a9226715bb</Hash>
</Codenesium>*/