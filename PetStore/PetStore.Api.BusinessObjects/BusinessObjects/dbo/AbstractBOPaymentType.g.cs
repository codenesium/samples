using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOPaymentType: AbstractBOManager
	{
		private IPaymentTypeRepository paymentTypeRepository;
		private IApiPaymentTypeModelValidator paymentTypeModelValidator;
		private ILogger logger;

		public AbstractBOPaymentType(
			ILogger logger,
			IPaymentTypeRepository paymentTypeRepository,
			IApiPaymentTypeModelValidator paymentTypeModelValidator)
			: base()

		{
			this.paymentTypeRepository = paymentTypeRepository;
			this.paymentTypeModelValidator = paymentTypeModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPaymentType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.paymentTypeRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPaymentType> Get(int id)
		{
			return this.paymentTypeRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPaymentType>> Create(
			ApiPaymentTypeModel model)
		{
			CreateResponse<POCOPaymentType> response = new CreateResponse<POCOPaymentType>(await this.paymentTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPaymentType record = await this.paymentTypeRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPaymentTypeModel model)
		{
			ActionResponse response = new ActionResponse(await this.paymentTypeModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.paymentTypeRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.paymentTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.paymentTypeRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0ae1125417e6280a2b57cce81a6d1ac0</Hash>
</Codenesium>*/