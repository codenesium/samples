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
	public abstract class AbstractBOOtherTransport: AbstractBOManager
	{
		private IOtherTransportRepository otherTransportRepository;
		private IApiOtherTransportModelValidator otherTransportModelValidator;
		private ILogger logger;

		public AbstractBOOtherTransport(
			ILogger logger,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportModelValidator otherTransportModelValidator)
			: base()

		{
			this.otherTransportRepository = otherTransportRepository;
			this.otherTransportModelValidator = otherTransportModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOOtherTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.otherTransportRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOOtherTransport> Get(int id)
		{
			return this.otherTransportRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOOtherTransport>> Create(
			ApiOtherTransportModel model)
		{
			CreateResponse<POCOOtherTransport> response = new CreateResponse<POCOOtherTransport>(await this.otherTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOOtherTransport record = await this.otherTransportRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiOtherTransportModel model)
		{
			ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.otherTransportRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.otherTransportRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cd38fdc2db1bfe0a44bd79c2e6c360aa</Hash>
</Codenesium>*/