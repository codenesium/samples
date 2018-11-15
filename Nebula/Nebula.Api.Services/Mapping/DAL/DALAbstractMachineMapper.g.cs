using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractMachineMapper
	{
		public virtual Machine MapBOToEF(
			BOMachine bo)
		{
			Machine efMachine = new Machine();
			efMachine.SetProperties(
				bo.Description,
				bo.Id,
				bo.JwtKey,
				bo.LastIpAddress,
				bo.MachineGuid,
				bo.Name);
			return efMachine;
		}

		public virtual BOMachine MapEFToBO(
			Machine ef)
		{
			var bo = new BOMachine();

			bo.SetProperties(
				ef.Id,
				ef.Description,
				ef.JwtKey,
				ef.LastIpAddress,
				ef.MachineGuid,
				ef.Name);
			return bo;
		}

		public virtual List<BOMachine> MapEFToBO(
			List<Machine> records)
		{
			List<BOMachine> response = new List<BOMachine>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>52d38344a27fbffc5f093bb9db7cd4f3</Hash>
</Codenesium>*/