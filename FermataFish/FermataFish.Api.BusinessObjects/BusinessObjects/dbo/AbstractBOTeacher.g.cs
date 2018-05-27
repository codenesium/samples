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
		private IApiTeacherRequestModelValidator teacherModelValidator;
		private IBOLTeacherMapper teacherMapper;
		private ILogger logger;

		public AbstractBOTeacher(
			ILogger logger,
			ITeacherRepository teacherRepository,
			IApiTeacherRequestModelValidator teacherModelValidator,
			IBOLTeacherMapper teacherMapper)
			: base()

		{
			this.teacherRepository = teacherRepository;
			this.teacherModelValidator = teacherModelValidator;
			this.teacherMapper = teacherMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeacherResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.teacherRepository.All(skip, take, orderClause);

			return this.teacherMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiTeacherResponseModel> Get(int id)
		{
			var record = await teacherRepository.Get(id);

			return this.teacherMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiTeacherResponseModel>> Create(
			ApiTeacherRequestModel model)
		{
			CreateResponse<ApiTeacherResponseModel> response = new CreateResponse<ApiTeacherResponseModel>(await this.teacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.teacherMapper.MapModelToDTO(default (int), model);
				var record = await this.teacherRepository.Create(dto);

				response.SetRecord(this.teacherMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeacherRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.teacherModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.teacherMapper.MapModelToDTO(id, model);
				await this.teacherRepository.Update(id, dto);
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
    <Hash>d73973cec2554e8f452526e182ea79af</Hash>
</Codenesium>*/