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
	public abstract class AbstractBOStudent
	{
		private IStudentRepository studentRepository;
		private IStudentModelValidator studentModelValidator;
		private ILogger logger;

		public AbstractBOStudent(
			ILogger logger,
			IStudentRepository studentRepository,
			IStudentModelValidator studentModelValidator)

		{
			this.studentRepository = studentRepository;
			this.studentModelValidator = studentModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			StudentModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.studentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.studentRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			StudentModel model)
		{
			ActionResponse response = new ActionResponse(await this.studentModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.studentRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.studentRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOStudent Get(int id)
		{
			return this.studentRepository.Get(id);
		}

		public virtual List<POCOStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studentRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>740c16141dbf6d052106eebef5efe460</Hash>
</Codenesium>*/