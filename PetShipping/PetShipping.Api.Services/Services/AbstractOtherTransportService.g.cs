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
	public abstract class AbstractOtherTransportService: AbstractService
	{
		private IOtherTransportRepository otherTransportRepository;
		private IApiOtherTransportRequestModelValidator otherTransportModelValidator;
		private IBOLOtherTransportMapper bolOtherTransportMapper;
		private IDALOtherTransportMapper dalOtherTransportMapper;
		private ILogger logger;

		public AbstractOtherTransportService(
			ILogger logger,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper bolotherTransportMapper,
			IDALOtherTransportMapper dalotherTransportMapper)
			: base()

		{
			this.otherTransportRepository = otherTransportRepository;
			this.otherTransportModelValidator = otherTransportModelValidator;
			this.bolOtherTransportMapper = bolotherTransportMapper;
			this.dalOtherTransportMapper = dalotherTransportMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiOtherTransportResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.otherTransportRepository.All(skip, take, orderClause);

			return this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiOtherTransportResponseModel> Get(int id)
		{
			var record = await otherTransportRepository.Get(id);

			return this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
			ApiOtherTransportRequestModel model)
		{
			CreateResponse<ApiOtherTransportResponseModel> response = new CreateResponse<ApiOtherTransportResponseModel>(await this.otherTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolOtherTransportMapper.MapModelToBO(default (int), model);
				var record = await this.otherTransportRepository.Create(this.dalOtherTransportMapper.MapBOToEF(bo));

				response.SetRecord(this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(record)));
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
				var bo = this.bolOtherTransportMapper.MapModelToBO(id, model);
				await this.otherTransportRepository.Update(this.dalOtherTransportMapper.MapBOToEF(bo));
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
    <Hash>6f37839b93c138795d8150bec79fe131</Hash>
</Codenesium>*/