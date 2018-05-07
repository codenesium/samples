using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOFamily
	{
		private IFamilyRepository familyRepository;
		private IFamilyModelValidator familyModelValidator;
		private ILogger logger;

		public AbstractBOFamily(
			ILogger logger,
			IFamilyRepository familyRepository,
			IFamilyModelValidator familyModelValidator)

		{
			this.familyRepository = familyRepository;
			this.familyModelValidator = familyModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			FamilyModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.familyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.familyRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			FamilyModel model)
		{
			ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.familyRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.familyRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOFamily Get(int id)
		{
			return this.familyRepository.Get(id);
		}

		public virtual List<POCOFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.familyRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>7f8f22fb0189515ca95e90b06299ffbd</Hash>
</Codenesium>*/