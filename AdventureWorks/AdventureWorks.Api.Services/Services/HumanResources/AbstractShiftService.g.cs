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
	public abstract class AbstractShiftService: AbstractService
	{
		private IShiftRepository shiftRepository;
		private IApiShiftRequestModelValidator shiftModelValidator;
		private IBOLShiftMapper BOLShiftMapper;
		private IDALShiftMapper DALShiftMapper;
		private ILogger logger;

		public AbstractShiftService(
			ILogger logger,
			IShiftRepository shiftRepository,
			IApiShiftRequestModelValidator shiftModelValidator,
			IBOLShiftMapper bolshiftMapper,
			IDALShiftMapper dalshiftMapper)
			: base()

		{
			this.shiftRepository = shiftRepository;
			this.shiftModelValidator = shiftModelValidator;
			this.BOLShiftMapper = bolshiftMapper;
			this.DALShiftMapper = dalshiftMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShiftResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.shiftRepository.All(skip, take, orderClause);

			return this.BOLShiftMapper.MapBOToModel(this.DALShiftMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShiftResponseModel> Get(int shiftID)
		{
			var record = await shiftRepository.Get(shiftID);

			return this.BOLShiftMapper.MapBOToModel(this.DALShiftMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiShiftResponseModel>> Create(
			ApiShiftRequestModel model)
		{
			CreateResponse<ApiShiftResponseModel> response = new CreateResponse<ApiShiftResponseModel>(await this.shiftModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLShiftMapper.MapModelToBO(default (int), model);
				var record = await this.shiftRepository.Create(this.DALShiftMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLShiftMapper.MapBOToModel(this.DALShiftMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shiftID,
			ApiShiftRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.shiftModelValidator.ValidateUpdateAsync(shiftID, model));

			if (response.Success)
			{
				var bo = this.BOLShiftMapper.MapModelToBO(shiftID, model);
				await this.shiftRepository.Update(this.DALShiftMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int shiftID)
		{
			ActionResponse response = new ActionResponse(await this.shiftModelValidator.ValidateDeleteAsync(shiftID));

			if (response.Success)
			{
				await this.shiftRepository.Delete(shiftID);
			}
			return response;
		}

		public async Task<ApiShiftResponseModel> GetName(string name)
		{
			Shift record = await this.shiftRepository.GetName(name);

			return this.BOLShiftMapper.MapBOToModel(this.DALShiftMapper.MapEFToBO(record));
		}
		public async Task<ApiShiftResponseModel> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime)
		{
			Shift record = await this.shiftRepository.GetStartTimeEndTime(startTime,endTime);

			return this.BOLShiftMapper.MapBOToModel(this.DALShiftMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>36c439a29eb7d1d6e41f72cb143dde9c</Hash>
</Codenesium>*/