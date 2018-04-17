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

		public virtual ApiResponse GetById(int addressID)
		{
			return this.addressRepository.GetById(addressID);
		}

		public virtual POCOAddress GetByIdDirect(int addressID)
		{
			return this.addressRepository.GetByIdDirect(addressID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOAddress> GetWhereDirect(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>f534f7cb262a4bd5d17248f92045a4e9</Hash>
</Codenesium>*/