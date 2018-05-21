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
	public abstract class AbstractBOTeacher: AbstractBOManager
	{
		private ITeacherRepository teacherRepository;
		private IApiTeacherModelValidator teacherModelValidator;
		private ILogger logger;

		public AbstractBOTeacher(
			ILogger logger,
			ITeacherRepository teacherRepository,
			IApiTeacherModelValidator teacherModelValidator)
			: base()

		{
			this.teacherRepository = teacherRepository;
			this.teacherModelValidator = teacherModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOTeacher> Get(int id)
		{
			return this.teacherRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOTeacher>> Create(
			ApiTeacherModel model)
		{
			CreateResponse<POCOTeacher> response = new CreateResponse<POCOTeacher>(await this.teacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTeacher record = await this.teacherRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeacherModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.teacherRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.teacherRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1cc25ac4cd3bdd7fe8d354ef25af72ba</Hash>
</Codenesium>*/