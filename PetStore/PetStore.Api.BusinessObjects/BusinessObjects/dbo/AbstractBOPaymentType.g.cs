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

		public virtual async Task<CreateResponse<int>> Create(
			PaymentTypeModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.paymentTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.paymentTypeRepository.Create(model);
				response.SetId(id);
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

		public virtual POCOPaymentType Get(int id)
		{
			return this.paymentTypeRepository.Get(id);
		}

		public virtual List<POCOPaymentType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.paymentTypeRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>8fbfdbbe16f1b29ac05fe301f905f68e</Hash>
</Codenesium>*/