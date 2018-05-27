using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOPaymentType: AbstractBOManager
	{
		private IPaymentTypeRepository paymentTypeRepository;
		private IApiPaymentTypeRequestModelValidator paymentTypeModelValidator;
		private IBOLPaymentTypeMapper paymentTypeMapper;
		private ILogger logger;

		public AbstractBOPaymentType(
			ILogger logger,
			IPaymentTypeRepository paymentTypeRepository,
			IApiPaymentTypeRequestModelValidator paymentTypeModelValidator,
			IBOLPaymentTypeMapper paymentTypeMapper)
			: base()

		{
			this.paymentTypeRepository = paymentTypeRepository;
			this.paymentTypeModelValidator = paymentTypeModelValidator;
			this.paymentTypeMapper = paymentTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPaymentTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.paymentTypeRepository.All(skip, take, orderClause);

			return this.paymentTypeMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPaymentTypeResponseModel> Get(int id)
		{
			var record = await paymentTypeRepository.Get(id);

			return this.paymentTypeMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPaymentTypeResponseModel>> Create(
			ApiPaymentTypeRequestModel model)
		{
			CreateResponse<ApiPaymentTypeResponseModel> response = new CreateResponse<ApiPaymentTypeResponseModel>(await this.paymentTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.paymentTypeMapper.MapModelToDTO(default (int), model);
				var record = await this.paymentTypeRepository.Create(dto);

				response.SetRecord(this.paymentTypeMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPaymentTypeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.paymentTypeModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.paymentTypeMapper.MapModelToDTO(id, model);
				await this.paymentTypeRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.paymentTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.paymentTypeRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>225fba74276bb3f81cc1eee542360caf</Hash>
</Codenesium>*/