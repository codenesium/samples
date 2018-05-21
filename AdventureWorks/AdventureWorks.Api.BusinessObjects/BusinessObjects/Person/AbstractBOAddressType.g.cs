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
	public abstract class AbstractBOAddressType: AbstractBOManager
	{
		private IAddressTypeRepository addressTypeRepository;
		private IApiAddressTypeModelValidator addressTypeModelValidator;
		private ILogger logger;

		public AbstractBOAddressType(
			ILogger logger,
			IAddressTypeRepository addressTypeRepository,
			IApiAddressTypeModelValidator addressTypeModelValidator)
			: base()

		{
			this.addressTypeRepository = addressTypeRepository;
			this.addressTypeModelValidator = addressTypeModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOAddressType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.addressTypeRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOAddressType> Get(int addressTypeID)
		{
			return this.addressTypeRepository.Get(addressTypeID);
		}

		public virtual async Task<CreateResponse<POCOAddressType>> Create(
			ApiAddressTypeModel model)
		{
			CreateResponse<POCOAddressType> response = new CreateResponse<POCOAddressType>(await this.addressTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAddressType record = await this.addressTypeRepository.Create(model);

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
				await this.addressTypeRepository.Update(addressTypeID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int addressTypeID)
		{
			ActionResponse response = new ActionResponse(await this.addressTypeModelValidator.ValidateDeleteAsync(addressTypeID));

			if (response.Success)
			{
				await this.addressTypeRepository.Delete(addressTypeID);
			}
			return response;
		}

		public async Task<POCOAddressType> GetName(string name)
		{
			return await this.addressTypeRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>3abdded2d015db5aa171bde66be3df44</Hash>
</Codenesium>*/