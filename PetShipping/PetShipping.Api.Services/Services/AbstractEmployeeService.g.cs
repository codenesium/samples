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

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractEmployeeService: AbstractService
	{
		private IEmployeeRepository employeeRepository;
		private IApiEmployeeRequestModelValidator employeeModelValidator;
		private IBOLEmployeeMapper bolEmployeeMapper;
		private IDALEmployeeMapper dalEmployeeMapper;
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
			this.bolEmployeeMapper = bolemployeeMapper;
			this.dalEmployeeMapper = dalemployeeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.employeeRepository.All(skip, take, orderClause);

			return this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeResponseModel> Get(int id)
		{
			var record = await employeeRepository.Get(id);

			return this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model)
		{
			CreateResponse<ApiEmployeeResponseModel> response = new CreateResponse<ApiEmployeeResponseModel>(await this.employeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolEmployeeMapper.MapModelToBO(default (int), model);
				var record = await this.employeeRepository.Create(this.dalEmployeeMapper.MapBOToEF(bo));

				response.SetRecord(this.bolEmployeeMapper.MapBOToModel(this.dalEmployeeMapper.MapEFToBO(record)));
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
				var bo = this.bolEmployeeMapper.MapModelToBO(id, model);
				await this.employeeRepository.Update(this.dalEmployeeMapper.MapBOToEF(bo));
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
    <Hash>ff205541e1e3f1ae1e64f84cf45c9999</Hash>
</Codenesium>*/