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
	public abstract class AbstractBOStudent: AbstractBOManager
	{
		private IStudentRepository studentRepository;
		private IApiStudentRequestModelValidator studentModelValidator;
		private IBOLStudentMapper studentMapper;
		private ILogger logger;

		public AbstractBOStudent(
			ILogger logger,
			IStudentRepository studentRepository,
			IApiStudentRequestModelValidator studentModelValidator,
			IBOLStudentMapper studentMapper)
			: base()

		{
			this.studentRepository = studentRepository;
			this.studentModelValidator = studentModelValidator;
			this.studentMapper = studentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.studentRepository.All(skip, take, orderClause);

			return this.studentMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiStudentResponseModel> Get(int id)
		{
			var record = await studentRepository.Get(id);

			return this.studentMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiStudentResponseModel>> Create(
			ApiStudentRequestModel model)
		{
			CreateResponse<ApiStudentResponseModel> response = new CreateResponse<ApiStudentResponseModel>(await this.studentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.studentMapper.MapModelToDTO(default (int), model);
				var record = await this.studentRepository.Create(dto);

				response.SetRecord(this.studentMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudentRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.studentModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.studentMapper.MapModelToDTO(id, model);
				await this.studentRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.studentRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>87f967e82240da38ff554c7b77ffef33</Hash>
</Codenesium>*/