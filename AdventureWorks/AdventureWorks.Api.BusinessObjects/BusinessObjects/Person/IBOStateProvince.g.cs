using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOStateProvince
	{
		Task<CreateResponse<POCOStateProvince>> Create(
			ApiStateProvinceModel model);

		Task<ActionResponse> Update(int stateProvinceID,
		                            ApiStateProvinceModel model);

		Task<ActionResponse> Delete(int stateProvinceID);

		Task<POCOStateProvince> Get(int stateProvinceID);

		Task<List<POCOStateProvince>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOStateProvince> GetName(string name);
		Task<POCOStateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>ca68751c5daab12b0e0be720d354c33d</Hash>
</Codenesium>*/