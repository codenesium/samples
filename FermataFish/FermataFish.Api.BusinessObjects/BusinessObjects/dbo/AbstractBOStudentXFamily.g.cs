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
	public abstract class AbstractBOStudentXFamily: AbstractBOManager
	{
		private IStudentXFamilyRepository studentXFamilyRepository;
		private IApiStudentXFamilyModelValidator studentXFamilyModelValidator;
		private ILogger logger;

		public AbstractBOStudentXFamily(
			ILogger logger,
			IStudentXFamilyRepository studentXFamilyRepository,
			IApiStudentXFamilyModelValidator studentXFamilyModelValidator)
			: base()

		{
			this.studentXFamilyRepository = studentXFamilyRepository;
			this.studentXFamilyModelValidator = studentXFamilyModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOStudentXFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studentXFamilyRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOStudentXFamily> Get(int id)
		{
			return this.studentXFamilyRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOStudentXFamily>> Create(
			ApiStudentXFamilyModel model)
		{
			CreateResponse<POCOStudentXFamily> response = new CreateResponse<POCOStudentXFamily>(await this.studentXFamilyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOStudentXFamily record = await this.studentXFamilyRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudentXFamilyModel model)
		{
			ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.studentXFamilyRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.studentXFamilyRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dd8b2b79768ce174235d99eba6d38c53</Hash>
</Codenesium>*/