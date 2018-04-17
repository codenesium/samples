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
	public abstract class AbstractBOAddressType
	{
		private IAddressTypeRepository addressTypeRepository;
		private IAddressTypeModelValidator addressTypeModelValidator;
		private ILogger logger;

		public AbstractBOAddressType(
			ILogger logger,
			IAddressTypeRepository addressTypeRepository,
			IAddressTypeModelValidator addressTypeModelValidator)

		{
			this.addressTypeRepository = addressTypeRepository;
			this.addressTypeModelValidator = addressTypeModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			AddressTypeModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.addressTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.addressTypeRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int addressTypeID,
			AddressTypeModel model)
		{
			ActionResponse response = new ActionResponse(await this.addressTypeModelValidator.ValidateUpdateAsync(addressTypeID, model));

			if (response.Success)
			{
				this.addressTypeRepository.Update(addressTypeID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int addressTypeID)
		{
			ActionResponse response = new ActionResponse(await this.addressTypeModelValidator.ValidateDeleteAsync(addressTypeID));

			if (response.Success)
			{
				this.addressTypeRepository.Delete(addressTypeID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int addressTypeID)
		{
			return this.addressTypeRepository.GetById(addressTypeID);
		}

		public virtual POCOAddressType GetByIdDirect(int addressTypeID)
		{
			return this.addressTypeRepository.GetByIdDirect(addressTypeID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressTypeRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressTypeRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOAddressType> GetWhereDirect(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressTypeRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>515215f6753bdb49a8beca8c061b4483</Hash>
</Codenesium>*/