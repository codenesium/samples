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
	public abstract class AbstractBOOtherTransport: AbstractBOManager
	{
		private IOtherTransportRepository otherTransportRepository;
		private IApiOtherTransportRequestModelValidator otherTransportModelValidator;
		private IBOLOtherTransportMapper otherTransportMapper;
		private ILogger logger;

		public AbstractBOOtherTransport(
			ILogger logger,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper otherTransportMapper)
			: base()

		{
			this.otherTransportRepository = otherTransportRepository;
			this.otherTransportModelValidator = otherTransportModelValidator;
			this.otherTransportMapper = otherTransportMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiOtherTransportResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.otherTransportRepository.All(skip, take, orderClause);

			return this.otherTransportMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiOtherTransportResponseModel> Get(int id)
		{
			var record = await otherTransportRepository.Get(id);

			return this.otherTransportMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
			ApiOtherTransportRequestModel model)
		{
			CreateResponse<ApiOtherTransportResponseModel> response = new CreateResponse<ApiOtherTransportResponseModel>(await this.otherTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.otherTransportMapper.MapModelToDTO(default (int), model);
				var record = await this.otherTransportRepository.Create(dto);

				response.SetRecord(this.otherTransportMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiOtherTransportRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.otherTransportMapper.MapModelToDTO(id, model);
				await this.otherTransportRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.otherTransportRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c8e0588d5eaa29f70653c57ef1d8c376</Hash>
</Codenesium>*/