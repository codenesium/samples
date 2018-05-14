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
	public abstract class AbstractBOPaymentType
	{
		private IPaymentTypeRepository paymentTypeRepository;
		private IPaymentTypeModelValidator paymentTypeModelValidator;
		private ILogger logger;

		public AbstractBOPaymentType(
			ILogger logger,
			IPaymentTypeRepository paymentTypeRepository,
			IPaymentTypeModelValidator paymentTypeModelValidator)

		{
			this.paymentTypeRepository = paymentTypeRepository;
			this.paymentTypeModelValidator = paymentTypeModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPaymentType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.paymentTypeRepository.All(skip, take, orderClause);
		}

		public virtual POCOPaymentType Get(int id)
		{
			return this.paymentTypeRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPaymentType>> Create(
			PaymentTypeModel model)
		{
			CreateResponse<POCOPaymentType> response = new CreateResponse<POCOPaymentType>(await this.paymentTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPaymentType record = this.paymentTypeRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PaymentTypeModel model)
		{
			ActionResponse response = new ActionResponse(await this.paymentTypeModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.paymentTypeRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.paymentTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.paymentTypeRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ee2140d8dacf3529047fbfa38b413504</Hash>
</Codenesium>*/