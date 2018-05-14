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
		private IApiStudentModelValidator studentModelValidator;
		private ILogger logger;

		public AbstractBOStudent(
			ILogger logger,
			IStudentRepository studentRepository,
			IApiStudentModelValidator studentModelValidator)

		{
			this.studentRepository = studentRepository;
			this.studentModelValidator = studentModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studentRepository.All(skip, take, orderClause);
		}

		public virtual POCOStudent Get(int id)
		{
			return this.studentRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOStudent>> Create(
			ApiStudentModel model)
		{
			CreateResponse<POCOStudent> response = new CreateResponse<POCOStudent>(await this.studentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOStudent record = this.studentRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudentModel model)
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
	}
}

/*<Codenesium>
    <Hash>1ba7dbf8ff221405c904ce37677479a5</Hash>
</Codenesium>*/