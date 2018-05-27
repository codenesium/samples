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
	public abstract class AbstractBOEmployee: AbstractBOManager
	{
		private IEmployeeRepository employeeRepository;
		private IApiEmployeeRequestModelValidator employeeModelValidator;
		private IBOLEmployeeMapper employeeMapper;
		private ILogger logger;

		public AbstractBOEmployee(
			ILogger logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper employeeMapper)
			: base()

		{
			this.employeeRepository = employeeRepository;
			this.employeeModelValidator = employeeModelValidator;
			this.employeeMapper = employeeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.employeeRepository.All(skip, take, orderClause);

			return this.employeeMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiEmployeeResponseModel> Get(int businessEntityID)
		{
			var record = await employeeRepository.Get(businessEntityID);

			return this.employeeMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model)
		{
			CreateResponse<ApiEmployeeResponseModel> response = new CreateResponse<ApiEmployeeResponseModel>(await this.employeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.employeeMapper.MapModelToDTO(default (int), model);
				var record = await this.employeeRepository.Create(dto);

				response.SetRecord(this.employeeMapper.MapDTOToModel(record));
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
				var dto = this.employeeMapper.MapModelToDTO(businessEntityID, model);
				await this.employeeRepository.Update(businessEntityID, dto);
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
			DTOEmployee record = await this.employeeRepository.GetLoginID(loginID);

			return this.employeeMapper.MapDTOToModel(record);
		}
		public async Task<ApiEmployeeResponseModel> GetNationalIDNumber(string nationalIDNumber)
		{
			DTOEmployee record = await this.employeeRepository.GetNationalIDNumber(nationalIDNumber);

			return this.employeeMapper.MapDTOToModel(record);
		}
		public async Task<List<ApiEmployeeResponseModel>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode)
		{
			List<DTOEmployee> records = await this.employeeRepository.GetOrganizationLevelOrganizationNode(organizationLevel,organizationNode);

			return this.employeeMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiEmployeeResponseModel>> GetOrganizationNode(Nullable<Guid> organizationNode)
		{
			List<DTOEmployee> records = await this.employeeRepository.GetOrganizationNode(organizationNode);

			return this.employeeMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>acfcdce426177440b5d04a8f6d3a1cd6</Hash>
</Codenesium>*/