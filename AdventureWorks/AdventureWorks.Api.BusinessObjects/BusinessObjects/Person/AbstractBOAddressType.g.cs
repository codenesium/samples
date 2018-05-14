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
		private IApiAddressTypeModelValidator addressTypeModelValidator;
		private ILogger logger;

		public AbstractBOAddressType(
			ILogger logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeModelValidator addressTypeModelValidator)

		{
			this.addressTypeRepository = addressTypeRepository;
			this.addressTypeModelValidator = addressTypeModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOAddressType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressTypeRepository.All(skip, take, orderClause);
		}

		public virtual POCOAddressType Get(int addressTypeID)
		{
			return this.addressTypeRepository.Get(addressTypeID);
		}

		public virtual async Task<CreateResponse<POCOAddressType>> Create(
			ApiAddressTypeModel model)
		{
			CreateResponse<POCOAddressType> response = new CreateResponse<POCOAddressType>(await this.addressTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAddressType record = this.addressTypeRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int addressTypeID,
			ApiAddressTypeModel model)
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

		public POCOAddressType GetName(string name)
		{
			return this.addressTypeRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>abd56e79d0d2e50571adfcba1a08cfd5</Hash>
</Codenesium>*/