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
		private IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator;
		private IBOLStudentXFamilyMapper studentXFamilyMapper;
		private ILogger logger;

		public AbstractBOStudentXFamily(
			ILogger logger,
			IStudentXFamilyRepository studentXFamilyRepository,
			IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator,
			IBOLStudentXFamilyMapper studentXFamilyMapper)
			: base()

		{
			this.studentXFamilyRepository = studentXFamilyRepository;
			this.studentXFamilyModelValidator = studentXFamilyModelValidator;
			this.studentXFamilyMapper = studentXFamilyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudentXFamilyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.studentXFamilyRepository.All(skip, take, orderClause);

			return this.studentXFamilyMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiStudentXFamilyResponseModel> Get(int id)
		{
			var record = await studentXFamilyRepository.Get(id);

			return this.studentXFamilyMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiStudentXFamilyResponseModel>> Create(
			ApiStudentXFamilyRequestModel model)
		{
			CreateResponse<ApiStudentXFamilyResponseModel> response = new CreateResponse<ApiStudentXFamilyResponseModel>(await this.studentXFamilyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.studentXFamilyMapper.MapModelToDTO(default (int), model);
				var record = await this.studentXFamilyRepository.Create(dto);

				response.SetRecord(this.studentXFamilyMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudentXFamilyRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.studentXFamilyMapper.MapModelToDTO(id, model);
				await this.studentXFamilyRepository.Update(id, dto);
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
    <Hash>778c6e6c68b99b2a664b7a4069eab2d5</Hash>
</Codenesium>*/