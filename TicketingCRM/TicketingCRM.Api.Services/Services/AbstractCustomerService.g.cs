using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractCustomerService : AbstractService
	{
		protected ICustomerRepository CustomerRepository { get; private set; }

		protected IApiCustomerRequestModelValidator CustomerModelValidator { get; private set; }

		protected IBOLCustomerMapper BolCustomerMapper { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		private ILogger logger;

		public AbstractCustomerService(
			ILogger logger,
			ICustomerRepository customerRepository,
			IApiCustomerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper)
			: base()
		{
			this.CustomerRepository = customerRepository;
			this.CustomerModelValidator = customerModelValidator;
			this.BolCustomerMapper = bolCustomerMapper;
			this.DalCustomerMapper = dalCustomerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCustomerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CustomerRepository.All(limit, offset);

			return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCustomerResponseModel> Get(int id)
		{
			var record = await this.CustomerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCustomerResponseModel>> Create(
			ApiCustomerRequestModel model)
		{
			CreateResponse<ApiCustomerResponseModel> response = new CreateResponse<ApiCustomerResponseModel>(await this.CustomerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCustomerMapper.MapModelToBO(default(int), model);
				var record = await this.CustomerRepository.Create(this.DalCustomerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCustomerResponseModel>> Update(
			int id,
			ApiCustomerRequestModel model)
		{
			var validationResult = await this.CustomerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCustomerMapper.MapModelToBO(id, model);
				await this.CustomerRepository.Update(this.DalCustomerMapper.MapBOToEF(bo));

				var record = await this.CustomerRepository.Get(id);

				return new UpdateResponse<ApiCustomerResponseModel>(this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCustomerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.CustomerModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CustomerRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d5e2181a79d2c4d1716cad406311bc42</Hash>
</Codenesium>*/