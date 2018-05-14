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
	public abstract class AbstractBOIllustration
	{
		private IIllustrationRepository illustrationRepository;
		private IApiIllustrationModelValidator illustrationModelValidator;
		private ILogger logger;

		public AbstractBOIllustration(
			ILogger logger,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationModelValidator illustrationModelValidator)

		{
			this.illustrationRepository = illustrationRepository;
			this.illustrationModelValidator = illustrationModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.illustrationRepository.All(skip, take, orderClause);
		}

		public virtual POCOIllustration Get(int illustrationID)
		{
			return this.illustrationRepository.Get(illustrationID);
		}

		public virtual async Task<CreateResponse<POCOIllustration>> Create(
			ApiIllustrationModel model)
		{
			CreateResponse<POCOIllustration> response = new CreateResponse<POCOIllustration>(await this.illustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOIllustration record = this.illustrationRepository.Create(model);
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
				this.illustrationRepository.Update(illustrationID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int illustrationID)
		{
			ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateDeleteAsync(illustrationID));

			if (response.Success)
			{
				this.illustrationRepository.Delete(illustrationID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8309891895fe9b746dd442a5e04e9c85</Hash>
</Codenesium>*/