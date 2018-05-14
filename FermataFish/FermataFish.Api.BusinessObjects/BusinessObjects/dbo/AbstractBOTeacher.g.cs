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
	public abstract class AbstractBOTeacher
	{
		private ITeacherRepository teacherRepository;
		private ITeacherModelValidator teacherModelValidator;
		private ILogger logger;

		public AbstractBOTeacher(
			ILogger logger,
			ITeacherRepository teacherRepository,
			ITeacherModelValidator teacherModelValidator)

		{
			this.teacherRepository = teacherRepository;
			this.teacherModelValidator = teacherModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teacherRepository.All(skip, take, orderClause);
		}

		public virtual POCOTeacher Get(int id)
		{
			return this.teacherRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOTeacher>> Create(
			TeacherModel model)
		{
			CreateResponse<POCOTeacher> response = new CreateResponse<POCOTeacher>(await this.teacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTeacher record = this.teacherRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			TeacherModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.teacherRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.teacherRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>15f9c0c9a2d6e752079c7efb3be324d4</Hash>
</Codenesium>*/