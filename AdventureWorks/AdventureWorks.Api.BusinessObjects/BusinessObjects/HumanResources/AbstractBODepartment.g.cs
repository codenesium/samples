using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBODepartment: AbstractBOManager
	{
		private IDepartmentRepository departmentRepository;
		private IApiDepartmentRequestModelValidator departmentModelValidator;
		private IBOLDepartmentMapper departmentMapper;
		private ILogger logger;

		public AbstractBODepartment(
			ILogger logger,
			IDepartmentRepository departmentRepository,
			IApiDepartmentRequestModelValidator departmentModelValidator,
			IBOLDepartmentMapper departmentMapper)
			: base()

		{
			this.departmentRepository = departmentRepository;
			this.departmentModelValidator = departmentModelValidator;
			this.departmentMapper = departmentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDepartmentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.departmentRepository.All(skip, take, orderClause);

			return this.departmentMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiDepartmentResponseModel> Get(short departmentID)
		{
			var record = await departmentRepository.Get(departmentID);

			return this.departmentMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiDepartmentResponseModel>> Create(
			ApiDepartmentRequestModel model)
		{
			CreateResponse<ApiDepartmentResponseModel> response = new CreateResponse<ApiDepartmentResponseModel>(await this.departmentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.departmentMapper.MapModelToDTO(default (short), model);
				var record = await this.departmentRepository.Create(dto);

				response.SetRecord(this.departmentMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short departmentID,
			ApiDepartmentRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateUpdateAsync(departmentID, model));

			if (response.Success)
			{
				var dto = this.departmentMapper.MapModelToDTO(departmentID, model);
				await this.departmentRepository.Update(departmentID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			short departmentID)
		{
			ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateDeleteAsync(departmentID));

			if (response.Success)
			{
				await this.departmentRepository.Delete(departmentID);
			}
			return response;
		}

		public async Task<ApiDepartmentResponseModel> GetName(string name)
		{
			DTODepartment record = await this.departmentRepository.GetName(name);

			return this.departmentMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>d7fc0b5a2784c2e3d417199d3603c600</Hash>
</Codenesium>*/