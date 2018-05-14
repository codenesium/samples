using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOClasp
	{
		private IClaspRepository claspRepository;
		private IApiClaspModelValidator claspModelValidator;
		private ILogger logger;

		public AbstractBOClasp(
			ILogger logger,
			IClaspRepository claspRepository,
			IApiClaspModelValidator claspModelValidator)

		{
			this.claspRepository = claspRepository;
			this.claspModelValidator = claspModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOClasp> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.claspRepository.All(skip, take, orderClause);
		}

		public virtual POCOClasp Get(int id)
		{
			return this.claspRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOClasp>> Create(
			ApiClaspModel model)
		{
			CreateResponse<POCOClasp> response = new CreateResponse<POCOClasp>(await this.claspModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOClasp record = this.claspRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiClaspModel model)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.claspRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.claspRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aad48e05d44ae3760b7c32a5f5251537</Hash>
</Codenesium>*/