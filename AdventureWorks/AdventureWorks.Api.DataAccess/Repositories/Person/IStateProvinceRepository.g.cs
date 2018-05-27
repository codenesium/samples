using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStateProvinceRepository
	{
		Task<DTOStateProvince> Create(DTOStateProvince dto);

		Task Update(int stateProvinceID,
		            DTOStateProvince dto);

		Task Delete(int stateProvinceID);

		Task<DTOStateProvince> Get(int stateProvinceID);

		Task<List<DTOStateProvince>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOStateProvince> GetName(string name);
		Task<DTOStateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>74afb125ff683550e434dc43f6b8345b</Hash>
</Codenesium>*/