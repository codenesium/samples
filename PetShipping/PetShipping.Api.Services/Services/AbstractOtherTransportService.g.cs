using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractOtherTransportService : AbstractService
	{
		protected IOtherTransportRepository OtherTransportRepository { get; private set; }

		protected IApiOtherTransportRequestModelValidator OtherTransportModelValidator { get; private set; }

		protected IBOLOtherTransportMapper BolOtherTransportMapper { get; private set; }

		protected IDALOtherTransportMapper DalOtherTransportMapper { get; private set; }

		private ILogger logger;

		public AbstractOtherTransportService(
			ILogger logger,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base()
		{
			this.OtherTransportRepository = otherTransportRepository;
			this.OtherTransportModelValidator = otherTransportModelValidator;
			this.BolOtherTransportMapper = bolOtherTransportMapper;
			this.DalOtherTransportMapper = dalOtherTransportMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiOtherTransportResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.OtherTransportRepository.All(limit, offset);

			return this.BolOtherTransportMapper.MapBOToModel(this.DalOtherTransportMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiOtherTransportResponseModel> Get(int id)
		{
			var record = await this.OtherTransportRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolOtherTransportMapper.MapBOToModel(this.DalOtherTransportMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
			ApiOtherTransportRequestModel model)
		{
			CreateResponse<ApiOtherTransportResponseModel> response = new CreateResponse<ApiOtherTransportResponseModel>(await this.OtherTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolOtherTransportMapper.MapModelToBO(default(int), model);
				var record = await this.OtherTransportRepository.Create(this.DalOtherTransportMapper.MapBOToEF(bo));

				response.SetRecord(this.BolOtherTransportMapper.MapBOToModel(this.DalOtherTransportMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOtherTransportResponseModel>> Update(
			int id,
			ApiOtherTransportRequestModel model)
		{
			var validationResult = await this.OtherTransportModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolOtherTransportMapper.MapModelToBO(id, model);
				await this.OtherTransportRepository.Update(this.DalOtherTransportMapper.MapBOToEF(bo));

				var record = await this.OtherTransportRepository.Get(id);

				return new UpdateResponse<ApiOtherTransportResponseModel>(this.BolOtherTransportMapper.MapBOToModel(this.DalOtherTransportMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiOtherTransportResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.OtherTransportModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.OtherTransportRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c7fd285083860d9cc7f79dd909d1f79d</Hash>
</Codenesium>*/