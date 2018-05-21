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
	public abstract class AbstractBOIllustration: AbstractBOManager
	{
		private IIllustrationRepository illustrationRepository;
		private IApiIllustrationModelValidator illustrationModelValidator;
		private ILogger logger;

		public AbstractBOIllustration(
			ILogger logger,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationModelValidator illustrationModelValidator)
			: base()

		{
			this.illustrationRepository = illustrationRepository;
			this.illustrationModelValidator = illustrationModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.illustrationRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOIllustration> Get(int illustrationID)
		{
			return this.illustrationRepository.Get(illustrationID);
		}

		public virtual async Task<CreateResponse<POCOIllustration>> Create(
			ApiIllustrationModel model)
		{
			CreateResponse<POCOIllustration> response = new CreateResponse<POCOIllustration>(await this.illustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOIllustration record = await this.illustrationRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int illustrationID,
			ApiIllustrationModel model)
		{
			ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateUpdateAsync(illustrationID, model));

			if (response.Success)
			{
				await this.illustrationRepository.Update(illustrationID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int illustrationID)
		{
			ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateDeleteAsync(illustrationID));

			if (response.Success)
			{
				await this.illustrationRepository.Delete(illustrationID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8895e66efd02c0fa45a6e164ddb597a9</Hash>
</Codenesium>*/