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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDepartmentService: AbstractService
	{
		private IDepartmentRepository departmentRepository;
		private IApiDepartmentRequestModelValidator departmentModelValidator;
		private IBOLDepartmentMapper BOLDepartmentMapper;
		private IDALDepartmentMapper DALDepartmentMapper;
		private ILogger logger;

		public AbstractDepartmentService(
			ILogger logger,
			IDepartmentRepository departmentRepository,
			IApiDepartmentRequestModelValidator departmentModelValidator,
			IBOLDepartmentMapper boldepartmentMapper,
			IDALDepartmentMapper daldepartmentMapper)
			: base()

		{
			this.departmentRepository = departmentRepository;
			this.departmentModelValidator = departmentModelValidator;
			this.BOLDepartmentMapper = boldepartmentMapper;
			this.DALDepartmentMapper = daldepartmentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDepartmentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.departmentRepository.All(skip, take, orderClause);

			return this.BOLDepartmentMapper.MapBOToModel(this.DALDepartmentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDepartmentResponseModel> Get(short departmentID)
		{
			var record = await departmentRepository.Get(departmentID);

			return this.BOLDepartmentMapper.MapBOToModel(this.DALDepartmentMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiDepartmentResponseModel>> Create(
			ApiDepartmentRequestModel model)
		{
			CreateResponse<ApiDepartmentResponseModel> response = new CreateResponse<ApiDepartmentResponseModel>(await this.departmentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLDepartmentMapper.MapModelToBO(default (short), model);
				var record = await this.departmentRepository.Create(this.DALDepartmentMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLDepartmentMapper.MapBOToModel(this.DALDepartmentMapper.MapEFToBO(record)));
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
				var bo = this.BOLDepartmentMapper.MapModelToBO(departmentID, model);
				await this.departmentRepository.Update(this.DALDepartmentMapper.MapBOToEF(bo));
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
			Department record = await this.departmentRepository.GetName(name);

			return this.BOLDepartmentMapper.MapBOToModel(this.DALDepartmentMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>ca17ad4b6d056fc9df29f2055c696a71</Hash>
</Codenesium>*/