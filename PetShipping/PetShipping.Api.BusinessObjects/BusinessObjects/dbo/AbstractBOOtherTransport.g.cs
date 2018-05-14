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

		public virtual List<POCOOtherTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.otherTransportRepository.All(skip, take, orderClause);
		}

		public virtual POCOOtherTransport Get(int id)
		{
			return this.otherTransportRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOOtherTransport>> Create(
			OtherTransportModel model)
		{
			CreateResponse<POCOOtherTransport> response = new CreateResponse<POCOOtherTransport>(await this.otherTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOOtherTransport record = this.otherTransportRepository.Create(model);
				response.SetRecord(record);
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
	}
}

/*<Codenesium>
    <Hash>3864699035a8519e555c40169be85e3e</Hash>
</Codenesium>*/