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
	public abstract class AbstractBOStudentXFamily
	{
		private IStudentXFamilyRepository studentXFamilyRepository;
		private IStudentXFamilyModelValidator studentXFamilyModelValidator;
		private ILogger logger;

		public AbstractBOStudentXFamily(
			ILogger logger,
			IStudentXFamilyRepository studentXFamilyRepository,
			IStudentXFamilyModelValidator studentXFamilyModelValidator)

		{
			this.studentXFamilyRepository = studentXFamilyRepository;
			this.studentXFamilyModelValidator = studentXFamilyModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			StudentXFamilyModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.studentXFamilyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.studentXFamilyRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			StudentXFamilyModel model)
		{
			ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.studentXFamilyRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.studentXFamilyRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOStudentXFamily Get(int id)
		{
			return this.studentXFamilyRepository.Get(id);
		}

		public virtual List<POCOStudentXFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studentXFamilyRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>a03547e63406ba005cbdc3f4f3a73678</Hash>
</Codenesium>*/