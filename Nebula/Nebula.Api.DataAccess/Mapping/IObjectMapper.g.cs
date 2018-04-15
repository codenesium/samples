using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void ChainMapModelToEF(
			int id,
			ChainModel model,
			EFChain efChain);

		void ChainMapEFToPOCO(
			EFChain efChain,
			ApiResponse response);

		void ChainStatusMapModelToEF(
			int id,
			ChainStatusModel model,
			EFChainStatus efChainStatus);

		void ChainStatusMapEFToPOCO(
			EFChainStatus efChainStatus,
			ApiResponse response);

		void ClaspMapModelToEF(
			int id,
			ClaspModel model,
			EFClasp efClasp);

		void ClaspMapEFToPOCO(
			EFClasp efClasp,
			ApiResponse response);

		void LinkMapModelToEF(
			int id,
			LinkModel model,
			EFLink efLink);

		void LinkMapEFToPOCO(
			EFLink efLink,
			ApiResponse response);

		void LinkLogMapModelToEF(
			int id,
			LinkLogModel model,
			EFLinkLog efLinkLog);

		void LinkLogMapEFToPOCO(
			EFLinkLog efLinkLog,
			ApiResponse response);

		void LinkStatusMapModelToEF(
			int id,
			LinkStatusModel model,
			EFLinkStatus efLinkStatus);

		void LinkStatusMapEFToPOCO(
			EFLinkStatus efLinkStatus,
			ApiResponse response);

		void MachineMapModelToEF(
			int id,
			MachineModel model,
			EFMachine efMachine);

		void MachineMapEFToPOCO(
			EFMachine efMachine,
			ApiResponse response);

		void MachineRefTeamMapModelToEF(
			int id,
			MachineRefTeamModel model,
			EFMachineRefTeam efMachineRefTeam);

		void MachineRefTeamMapEFToPOCO(
			EFMachineRefTeam efMachineRefTeam,
			ApiResponse response);

		void OrganizationMapModelToEF(
			int id,
			OrganizationModel model,
			EFOrganization efOrganization);

		void OrganizationMapEFToPOCO(
			EFOrganization efOrganization,
			ApiResponse response);

		void TeamMapModelToEF(
			int id,
			TeamModel model,
			EFTeam efTeam);

		void TeamMapEFToPOCO(
			EFTeam efTeam,
			ApiResponse response);
	}
}

/*<Codenesium>
    <Hash>9c5b8d36fcd105f4d8a6fdddefcb0b17</Hash>
</Codenesium>*/