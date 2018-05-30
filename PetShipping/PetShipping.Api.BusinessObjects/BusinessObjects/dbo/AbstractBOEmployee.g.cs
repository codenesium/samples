using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
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

		public virtual async Task<ApiEmployeeResponseModel> Get(int id)
		{
			var record = await employeeRepository.Get(id);

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
			int id,
			ApiEmployeeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.employeeMapper.MapModelToDTO(id, model);
				await this.employeeRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.employeeRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1bdd8c174bb55d73bfef644d99938c20</Hash>
</Codenesium>*/