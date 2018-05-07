using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOOtherTransport
	{
		private IOtherTransportRepository otherTransportRepository;
		private IOtherTransportModelValidator otherTransportModelValidator;
		private ILogger logger;

		public AbstractBOOtherTransport(
			ILogger logger,
			IOtherTransportRepository otherTransportRepository,
			IOtherTransportModelValidator otherTransportModelValidator)

		{
			this.otherTransportRepository = otherTransportRepository;
			this.otherTransportModelValidator = otherTransportModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			OtherTransportModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.otherTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.otherTransportRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			OtherTransportModel model)
		{
			ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.otherTransportRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.otherTransportRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOOtherTransport Get(int id)
		{
			return this.otherTransportRepository.Get(id);
		}

		public virtual List<POCOOtherTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.otherTransportRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>c2b764eb78c6b26fc300099c09c51ad2</Hash>
</Codenesium>*/