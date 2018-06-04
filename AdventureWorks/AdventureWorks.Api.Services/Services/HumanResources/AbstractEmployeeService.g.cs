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
	public abstract class AbstractEmployeeService: AbstractService
	{
		private IEmployeeRepository employeeRepository;
		private IApiEmployeeRequestModelValidator employeeModelValidator;
		private IBOLEmployeeMapper BOLEmployeeMapper;
		private IDALEmployeeMapper DALEmployeeMapper;
		private ILogger logger;

		public AbstractEmployeeService(
			ILogger logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper bolemployeeMapper,
			IDALEmployeeMapper dalemployeeMapper)
			: base()

		{
			this.employeeRepository = employeeRepository;
			this.employeeModelValidator = employeeModelValidator;
			this.BOLEmployeeMapper = bolemployeeMapper;
			this.DALEmployeeMapper = dalemployeeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.employeeRepository.All(skip, take, orderClause);

			return this.BOLEmployeeMapper.MapBOToModel(this.DALEmployeeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeResponseModel> Get(int businessEntityID)
		{
			var record = await employeeRepository.Get(businessEntityID);

			return this.BOLEmployeeMapper.MapBOToModel(this.DALEmployeeMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model)
		{
			CreateResponse<ApiEmployeeResponseModel> response = new CreateResponse<ApiEmployeeResponseModel>(await this.employeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLEmployeeMapper.MapModelToBO(default (int), model);
				var record = await this.employeeRepository.Create(this.DALEmployeeMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLEmployeeMapper.MapBOToModel(this.DALEmployeeMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiEmployeeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.BOLEmployeeMapper.MapModelToBO(businessEntityID, model);
				await this.employeeRepository.Update(this.DALEmployeeMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.employeeRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<ApiEmployeeResponseModel> GetLoginID(string loginID)
		{
			Employee record = await this.employeeRepository.GetLoginID(loginID);

			return this.BOLEmployeeMapper.MapBOToModel(this.DALEmployeeMapper.MapEFToBO(record));
		}
		public async Task<ApiEmployeeResponseModel> GetNationalIDNumber(string nationalIDNumber)
		{
			Employee record = await this.employeeRepository.GetNationalIDNumber(nationalIDNumber);

			return this.BOLEmployeeMapper.MapBOToModel(this.DALEmployeeMapper.MapEFToBO(record));
		}
		public async Task<List<ApiEmployeeResponseModel>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode)
		{
			List<Employee> records = await this.employeeRepository.GetOrganizationLevelOrganizationNode(organizationLevel,organizationNode);

			return this.BOLEmployeeMapper.MapBOToModel(this.DALEmployeeMapper.MapEFToBO(records));
		}
		public async Task<List<ApiEmployeeResponseModel>> GetOrganizationNode(Nullable<Guid> organizationNode)
		{
			List<Employee> records = await this.employeeRepository.GetOrganizationNode(organizationNode);

			return this.BOLEmployeeMapper.MapBOToModel(this.DALEmployeeMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>7761ad4899ae9a9084fe3edbdca1247b</Hash>
</Codenesium>*/