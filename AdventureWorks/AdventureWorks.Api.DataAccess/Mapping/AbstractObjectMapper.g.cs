using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void AWBuildVersionMapModelToEF(
			int systemInformationID,
			AWBuildVersionModel model,
			EFAWBuildVersion efAWBuildVersion)
		{
			efAWBuildVersion.SetProperties(
				systemInformationID,
				model.Database_Version,
				model.VersionDate,
				model.ModifiedDate);
		}

		public virtual void AWBuildVersionMapEFToPOCO(
			EFAWBuildVersion efAWBuildVersion,
			ApiResponse response)
		{
			if (efAWBuildVersion == null)
			{
				return;
			}

			response.AddAWBuildVersion(new POCOAWBuildVersion(efAWBuildVersion.SystemInformationID, efAWBuildVersion.Database_Version, efAWBuildVersion.VersionDate, efAWBuildVersion.ModifiedDate));
		}

		public virtual void DatabaseLogMapModelToEF(
			int databaseLogID,
			DatabaseLogModel model,
			EFDatabaseLog efDatabaseLog)
		{
			efDatabaseLog.SetProperties(
				databaseLogID,
				model.PostTime,
				model.DatabaseUser,
				model.@Event,
				model.Schema,
				model.@Object,
				model.TSQL,
				model.XmlEvent);
		}

		public virtual void DatabaseLogMapEFToPOCO(
			EFDatabaseLog efDatabaseLog,
			ApiResponse response)
		{
			if (efDatabaseLog == null)
			{
				return;
			}

			response.AddDatabaseLog(new POCODatabaseLog(efDatabaseLog.DatabaseLogID, efDatabaseLog.PostTime, efDatabaseLog.DatabaseUser, efDatabaseLog.@Event, efDatabaseLog.Schema, efDatabaseLog.@Object, efDatabaseLog.TSQL, efDatabaseLog.XmlEvent));
		}

		public virtual void ErrorLogMapModelToEF(
			int errorLogID,
			ErrorLogModel model,
			EFErrorLog efErrorLog)
		{
			efErrorLog.SetProperties(
				errorLogID,
				model.ErrorTime,
				model.UserName,
				model.ErrorNumber,
				model.ErrorSeverity,
				model.ErrorState,
				model.ErrorProcedure,
				model.ErrorLine,
				model.ErrorMessage);
		}

		public virtual void ErrorLogMapEFToPOCO(
			EFErrorLog efErrorLog,
			ApiResponse response)
		{
			if (efErrorLog == null)
			{
				return;
			}

			response.AddErrorLog(new POCOErrorLog(efErrorLog.ErrorLogID, efErrorLog.ErrorTime, efErrorLog.UserName, efErrorLog.ErrorNumber, efErrorLog.ErrorSeverity, efErrorLog.ErrorState, efErrorLog.ErrorProcedure, efErrorLog.ErrorLine, efErrorLog.ErrorMessage));
		}

		public virtual void DepartmentMapModelToEF(
			short departmentID,
			DepartmentModel model,
			EFDepartment efDepartment)
		{
			efDepartment.SetProperties(
				departmentID,
				model.Name,
				model.GroupName,
				model.ModifiedDate);
		}

		public virtual void DepartmentMapEFToPOCO(
			EFDepartment efDepartment,
			ApiResponse response)
		{
			if (efDepartment == null)
			{
				return;
			}

			response.AddDepartment(new POCODepartment(efDepartment.DepartmentID, efDepartment.Name, efDepartment.GroupName, efDepartment.ModifiedDate));
		}

		public virtual void EmployeeMapModelToEF(
			int businessEntityID,
			EmployeeModel model,
			EFEmployee efEmployee)
		{
			efEmployee.SetProperties(
				businessEntityID,
				model.NationalIDNumber,
				model.LoginID,
				model.OrganizationNode,
				model.OrganizationLevel,
				model.JobTitle,
				model.BirthDate,
				model.MaritalStatus,
				model.Gender,
				model.HireDate,
				model.SalariedFlag,
				model.VacationHours,
				model.SickLeaveHours,
				model.CurrentFlag,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void EmployeeMapEFToPOCO(
			EFEmployee efEmployee,
			ApiResponse response)
		{
			if (efEmployee == null)
			{
				return;
			}

			response.AddEmployee(new POCOEmployee(efEmployee.BusinessEntityID, efEmployee.NationalIDNumber, efEmployee.LoginID, efEmployee.OrganizationNode, efEmployee.OrganizationLevel, efEmployee.JobTitle, efEmployee.BirthDate, efEmployee.MaritalStatus, efEmployee.Gender, efEmployee.HireDate, efEmployee.SalariedFlag, efEmployee.VacationHours, efEmployee.SickLeaveHours, efEmployee.CurrentFlag, efEmployee.Rowguid, efEmployee.ModifiedDate));

			this.PersonMapEFToPOCO(efEmployee.Person, response);
		}

		public virtual void EmployeeDepartmentHistoryMapModelToEF(
			int businessEntityID,
			EmployeeDepartmentHistoryModel model,
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory)
		{
			efEmployeeDepartmentHistory.SetProperties(
				businessEntityID,
				model.DepartmentID,
				model.ShiftID,
				model.StartDate,
				model.EndDate,
				model.ModifiedDate);
		}

		public virtual void EmployeeDepartmentHistoryMapEFToPOCO(
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory,
			ApiResponse response)
		{
			if (efEmployeeDepartmentHistory == null)
			{
				return;
			}

			response.AddEmployeeDepartmentHistory(new POCOEmployeeDepartmentHistory(efEmployeeDepartmentHistory.BusinessEntityID, efEmployeeDepartmentHistory.DepartmentID, efEmployeeDepartmentHistory.ShiftID, efEmployeeDepartmentHistory.StartDate, efEmployeeDepartmentHistory.EndDate, efEmployeeDepartmentHistory.ModifiedDate));

			this.EmployeeMapEFToPOCO(efEmployeeDepartmentHistory.Employee, response);

			this.DepartmentMapEFToPOCO(efEmployeeDepartmentHistory.Department, response);

			this.ShiftMapEFToPOCO(efEmployeeDepartmentHistory.Shift, response);
		}

		public virtual void EmployeePayHistoryMapModelToEF(
			int businessEntityID,
			EmployeePayHistoryModel model,
			EFEmployeePayHistory efEmployeePayHistory)
		{
			efEmployeePayHistory.SetProperties(
				businessEntityID,
				model.RateChangeDate,
				model.Rate,
				model.PayFrequency,
				model.ModifiedDate);
		}

		public virtual void EmployeePayHistoryMapEFToPOCO(
			EFEmployeePayHistory efEmployeePayHistory,
			ApiResponse response)
		{
			if (efEmployeePayHistory == null)
			{
				return;
			}

			response.AddEmployeePayHistory(new POCOEmployeePayHistory(efEmployeePayHistory.BusinessEntityID, efEmployeePayHistory.RateChangeDate, efEmployeePayHistory.Rate, efEmployeePayHistory.PayFrequency, efEmployeePayHistory.ModifiedDate));

			this.EmployeeMapEFToPOCO(efEmployeePayHistory.Employee, response);
		}

		public virtual void JobCandidateMapModelToEF(
			int jobCandidateID,
			JobCandidateModel model,
			EFJobCandidate efJobCandidate)
		{
			efJobCandidate.SetProperties(
				jobCandidateID,
				model.BusinessEntityID,
				model.Resume,
				model.ModifiedDate);
		}

		public virtual void JobCandidateMapEFToPOCO(
			EFJobCandidate efJobCandidate,
			ApiResponse response)
		{
			if (efJobCandidate == null)
			{
				return;
			}

			response.AddJobCandidate(new POCOJobCandidate(efJobCandidate.JobCandidateID, efJobCandidate.BusinessEntityID, efJobCandidate.Resume, efJobCandidate.ModifiedDate));

			this.EmployeeMapEFToPOCO(efJobCandidate.Employee, response);
		}

		public virtual void ShiftMapModelToEF(
			int shiftID,
			ShiftModel model,
			EFShift efShift)
		{
			efShift.SetProperties(
				shiftID,
				model.Name,
				model.StartTime,
				model.EndTime,
				model.ModifiedDate);
		}

		public virtual void ShiftMapEFToPOCO(
			EFShift efShift,
			ApiResponse response)
		{
			if (efShift == null)
			{
				return;
			}

			response.AddShift(new POCOShift(efShift.ShiftID, efShift.Name, efShift.StartTime, efShift.EndTime, efShift.ModifiedDate));
		}

		public virtual void AddressMapModelToEF(
			int addressID,
			AddressModel model,
			EFAddress efAddress)
		{
			efAddress.SetProperties(
				addressID,
				model.AddressLine1,
				model.AddressLine2,
				model.City,
				model.StateProvinceID,
				model.PostalCode,
				model.SpatialLocation,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void AddressMapEFToPOCO(
			EFAddress efAddress,
			ApiResponse response)
		{
			if (efAddress == null)
			{
				return;
			}

			response.AddAddress(new POCOAddress(efAddress.AddressID, efAddress.AddressLine1, efAddress.AddressLine2, efAddress.City, efAddress.StateProvinceID, efAddress.PostalCode, efAddress.SpatialLocation, efAddress.Rowguid, efAddress.ModifiedDate));

			this.StateProvinceMapEFToPOCO(efAddress.StateProvince, response);
		}

		public virtual void AddressTypeMapModelToEF(
			int addressTypeID,
			AddressTypeModel model,
			EFAddressType efAddressType)
		{
			efAddressType.SetProperties(
				addressTypeID,
				model.Name,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void AddressTypeMapEFToPOCO(
			EFAddressType efAddressType,
			ApiResponse response)
		{
			if (efAddressType == null)
			{
				return;
			}

			response.AddAddressType(new POCOAddressType(efAddressType.AddressTypeID, efAddressType.Name, efAddressType.Rowguid, efAddressType.ModifiedDate));
		}

		public virtual void BusinessEntityMapModelToEF(
			int businessEntityID,
			BusinessEntityModel model,
			EFBusinessEntity efBusinessEntity)
		{
			efBusinessEntity.SetProperties(
				businessEntityID,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void BusinessEntityMapEFToPOCO(
			EFBusinessEntity efBusinessEntity,
			ApiResponse response)
		{
			if (efBusinessEntity == null)
			{
				return;
			}

			response.AddBusinessEntity(new POCOBusinessEntity(efBusinessEntity.BusinessEntityID, efBusinessEntity.Rowguid, efBusinessEntity.ModifiedDate));
		}

		public virtual void BusinessEntityAddressMapModelToEF(
			int businessEntityID,
			BusinessEntityAddressModel model,
			EFBusinessEntityAddress efBusinessEntityAddress)
		{
			efBusinessEntityAddress.SetProperties(
				businessEntityID,
				model.AddressID,
				model.AddressTypeID,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void BusinessEntityAddressMapEFToPOCO(
			EFBusinessEntityAddress efBusinessEntityAddress,
			ApiResponse response)
		{
			if (efBusinessEntityAddress == null)
			{
				return;
			}

			response.AddBusinessEntityAddress(new POCOBusinessEntityAddress(efBusinessEntityAddress.BusinessEntityID, efBusinessEntityAddress.AddressID, efBusinessEntityAddress.AddressTypeID, efBusinessEntityAddress.Rowguid, efBusinessEntityAddress.ModifiedDate));

			this.BusinessEntityMapEFToPOCO(efBusinessEntityAddress.BusinessEntity, response);

			this.AddressMapEFToPOCO(efBusinessEntityAddress.Address, response);

			this.AddressTypeMapEFToPOCO(efBusinessEntityAddress.AddressType, response);
		}

		public virtual void BusinessEntityContactMapModelToEF(
			int businessEntityID,
			BusinessEntityContactModel model,
			EFBusinessEntityContact efBusinessEntityContact)
		{
			efBusinessEntityContact.SetProperties(
				businessEntityID,
				model.PersonID,
				model.ContactTypeID,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void BusinessEntityContactMapEFToPOCO(
			EFBusinessEntityContact efBusinessEntityContact,
			ApiResponse response)
		{
			if (efBusinessEntityContact == null)
			{
				return;
			}

			response.AddBusinessEntityContact(new POCOBusinessEntityContact(efBusinessEntityContact.BusinessEntityID, efBusinessEntityContact.PersonID, efBusinessEntityContact.ContactTypeID, efBusinessEntityContact.Rowguid, efBusinessEntityContact.ModifiedDate));

			this.BusinessEntityMapEFToPOCO(efBusinessEntityContact.BusinessEntity, response);

			this.PersonMapEFToPOCO(efBusinessEntityContact.Person, response);

			this.ContactTypeMapEFToPOCO(efBusinessEntityContact.ContactType, response);
		}

		public virtual void ContactTypeMapModelToEF(
			int contactTypeID,
			ContactTypeModel model,
			EFContactType efContactType)
		{
			efContactType.SetProperties(
				contactTypeID,
				model.Name,
				model.ModifiedDate);
		}

		public virtual void ContactTypeMapEFToPOCO(
			EFContactType efContactType,
			ApiResponse response)
		{
			if (efContactType == null)
			{
				return;
			}

			response.AddContactType(new POCOContactType(efContactType.ContactTypeID, efContactType.Name, efContactType.ModifiedDate));
		}

		public virtual void CountryRegionMapModelToEF(
			string countryRegionCode,
			CountryRegionModel model,
			EFCountryRegion efCountryRegion)
		{
			efCountryRegion.SetProperties(
				countryRegionCode,
				model.Name,
				model.ModifiedDate);
		}

		public virtual void CountryRegionMapEFToPOCO(
			EFCountryRegion efCountryRegion,
			ApiResponse response)
		{
			if (efCountryRegion == null)
			{
				return;
			}

			response.AddCountryRegion(new POCOCountryRegion(efCountryRegion.CountryRegionCode, efCountryRegion.Name, efCountryRegion.ModifiedDate));
		}

		public virtual void EmailAddressMapModelToEF(
			int businessEntityID,
			EmailAddressModel model,
			EFEmailAddress efEmailAddress)
		{
			efEmailAddress.SetProperties(
				businessEntityID,
				model.EmailAddressID,
				model.EmailAddress1,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void EmailAddressMapEFToPOCO(
			EFEmailAddress efEmailAddress,
			ApiResponse response)
		{
			if (efEmailAddress == null)
			{
				return;
			}

			response.AddEmailAddress(new POCOEmailAddress(efEmailAddress.BusinessEntityID, efEmailAddress.EmailAddressID, efEmailAddress.EmailAddress1, efEmailAddress.Rowguid, efEmailAddress.ModifiedDate));

			this.PersonMapEFToPOCO(efEmailAddress.Person, response);
		}

		public virtual void PasswordMapModelToEF(
			int businessEntityID,
			PasswordModel model,
			EFPassword efPassword)
		{
			efPassword.SetProperties(
				businessEntityID,
				model.PasswordHash,
				model.PasswordSalt,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void PasswordMapEFToPOCO(
			EFPassword efPassword,
			ApiResponse response)
		{
			if (efPassword == null)
			{
				return;
			}

			response.AddPassword(new POCOPassword(efPassword.BusinessEntityID, efPassword.PasswordHash, efPassword.PasswordSalt, efPassword.Rowguid, efPassword.ModifiedDate));

			this.PersonMapEFToPOCO(efPassword.Person, response);
		}

		public virtual void PersonMapModelToEF(
			int businessEntityID,
			PersonModel model,
			EFPerson efPerson)
		{
			efPerson.SetProperties(
				businessEntityID,
				model.PersonType,
				model.NameStyle,
				model.Title,
				model.FirstName,
				model.MiddleName,
				model.LastName,
				model.Suffix,
				model.EmailPromotion,
				model.AdditionalContactInfo,
				model.Demographics,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void PersonMapEFToPOCO(
			EFPerson efPerson,
			ApiResponse response)
		{
			if (efPerson == null)
			{
				return;
			}

			response.AddPerson(new POCOPerson(efPerson.BusinessEntityID, efPerson.PersonType, efPerson.NameStyle, efPerson.Title, efPerson.FirstName, efPerson.MiddleName, efPerson.LastName, efPerson.Suffix, efPerson.EmailPromotion, efPerson.AdditionalContactInfo, efPerson.Demographics, efPerson.Rowguid, efPerson.ModifiedDate));

			this.BusinessEntityMapEFToPOCO(efPerson.BusinessEntity, response);
		}

		public virtual void PersonPhoneMapModelToEF(
			int businessEntityID,
			PersonPhoneModel model,
			EFPersonPhone efPersonPhone)
		{
			efPersonPhone.SetProperties(
				businessEntityID,
				model.PhoneNumber,
				model.PhoneNumberTypeID,
				model.ModifiedDate);
		}

		public virtual void PersonPhoneMapEFToPOCO(
			EFPersonPhone efPersonPhone,
			ApiResponse response)
		{
			if (efPersonPhone == null)
			{
				return;
			}

			response.AddPersonPhone(new POCOPersonPhone(efPersonPhone.BusinessEntityID, efPersonPhone.PhoneNumber, efPersonPhone.PhoneNumberTypeID, efPersonPhone.ModifiedDate));

			this.PersonMapEFToPOCO(efPersonPhone.Person, response);

			this.PhoneNumberTypeMapEFToPOCO(efPersonPhone.PhoneNumberType, response);
		}

		public virtual void PhoneNumberTypeMapModelToEF(
			int phoneNumberTypeID,
			PhoneNumberTypeModel model,
			EFPhoneNumberType efPhoneNumberType)
		{
			efPhoneNumberType.SetProperties(
				phoneNumberTypeID,
				model.Name,
				model.ModifiedDate);
		}

		public virtual void PhoneNumberTypeMapEFToPOCO(
			EFPhoneNumberType efPhoneNumberType,
			ApiResponse response)
		{
			if (efPhoneNumberType == null)
			{
				return;
			}

			response.AddPhoneNumberType(new POCOPhoneNumberType(efPhoneNumberType.PhoneNumberTypeID, efPhoneNumberType.Name, efPhoneNumberType.ModifiedDate));
		}

		public virtual void StateProvinceMapModelToEF(
			int stateProvinceID,
			StateProvinceModel model,
			EFStateProvince efStateProvince)
		{
			efStateProvince.SetProperties(
				stateProvinceID,
				model.StateProvinceCode,
				model.CountryRegionCode,
				model.IsOnlyStateProvinceFlag,
				model.Name,
				model.TerritoryID,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void StateProvinceMapEFToPOCO(
			EFStateProvince efStateProvince,
			ApiResponse response)
		{
			if (efStateProvince == null)
			{
				return;
			}

			response.AddStateProvince(new POCOStateProvince(efStateProvince.StateProvinceID, efStateProvince.StateProvinceCode, efStateProvince.CountryRegionCode, efStateProvince.IsOnlyStateProvinceFlag, efStateProvince.Name, efStateProvince.TerritoryID, efStateProvince.Rowguid, efStateProvince.ModifiedDate));

			this.CountryRegionMapEFToPOCO(efStateProvince.CountryRegion, response);

			this.SalesTerritoryMapEFToPOCO(efStateProvince.SalesTerritory, response);
		}

		public virtual void BillOfMaterialsMapModelToEF(
			int billOfMaterialsID,
			BillOfMaterialsModel model,
			EFBillOfMaterials efBillOfMaterials)
		{
			efBillOfMaterials.SetProperties(
				billOfMaterialsID,
				model.ProductAssemblyID,
				model.ComponentID,
				model.StartDate,
				model.EndDate,
				model.UnitMeasureCode,
				model.BOMLevel,
				model.PerAssemblyQty,
				model.ModifiedDate);
		}

		public virtual void BillOfMaterialsMapEFToPOCO(
			EFBillOfMaterials efBillOfMaterials,
			ApiResponse response)
		{
			if (efBillOfMaterials == null)
			{
				return;
			}

			response.AddBillOfMaterials(new POCOBillOfMaterials(efBillOfMaterials.BillOfMaterialsID, efBillOfMaterials.ProductAssemblyID, efBillOfMaterials.ComponentID, efBillOfMaterials.StartDate, efBillOfMaterials.EndDate, efBillOfMaterials.UnitMeasureCode, efBillOfMaterials.BOMLevel, efBillOfMaterials.PerAssemblyQty, efBillOfMaterials.ModifiedDate));

			this.ProductMapEFToPOCO(efBillOfMaterials.Product, response);

			this.ProductMapEFToPOCO(efBillOfMaterials.Product1, response);

			this.UnitMeasureMapEFToPOCO(efBillOfMaterials.UnitMeasure, response);
		}

		public virtual void CultureMapModelToEF(
			string cultureID,
			CultureModel model,
			EFCulture efCulture)
		{
			efCulture.SetProperties(
				cultureID,
				model.Name,
				model.ModifiedDate);
		}

		public virtual void CultureMapEFToPOCO(
			EFCulture efCulture,
			ApiResponse response)
		{
			if (efCulture == null)
			{
				return;
			}

			response.AddCulture(new POCOCulture(efCulture.CultureID, efCulture.Name, efCulture.ModifiedDate));
		}

		public virtual void DocumentMapModelToEF(
			Guid documentNode,
			DocumentModel model,
			EFDocument efDocument)
		{
			efDocument.SetProperties(
				documentNode,
				model.DocumentLevel,
				model.Title,
				model.Owner,
				model.FolderFlag,
				model.FileName,
				model.FileExtension,
				model.Revision,
				model.ChangeNumber,
				model.Status,
				model.DocumentSummary,
				model.Document1,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void DocumentMapEFToPOCO(
			EFDocument efDocument,
			ApiResponse response)
		{
			if (efDocument == null)
			{
				return;
			}

			response.AddDocument(new POCODocument(efDocument.DocumentNode, efDocument.DocumentLevel, efDocument.Title, efDocument.Owner, efDocument.FolderFlag, efDocument.FileName, efDocument.FileExtension, efDocument.Revision, efDocument.ChangeNumber, efDocument.Status, efDocument.DocumentSummary, efDocument.Document1, efDocument.Rowguid, efDocument.ModifiedDate));

			this.EmployeeMapEFToPOCO(efDocument.Employee, response);
		}

		public virtual void IllustrationMapModelToEF(
			int illustrationID,
			IllustrationModel model,
			EFIllustration efIllustration)
		{
			efIllustration.SetProperties(
				illustrationID,
				model.Diagram,
				model.ModifiedDate);
		}

		public virtual void IllustrationMapEFToPOCO(
			EFIllustration efIllustration,
			ApiResponse response)
		{
			if (efIllustration == null)
			{
				return;
			}

			response.AddIllustration(new POCOIllustration(efIllustration.IllustrationID, efIllustration.Diagram, efIllustration.ModifiedDate));
		}

		public virtual void LocationMapModelToEF(
			short locationID,
			LocationModel model,
			EFLocation efLocation)
		{
			efLocation.SetProperties(
				locationID,
				model.Name,
				model.CostRate,
				model.Availability,
				model.ModifiedDate);
		}

		public virtual void LocationMapEFToPOCO(
			EFLocation efLocation,
			ApiResponse response)
		{
			if (efLocation == null)
			{
				return;
			}

			response.AddLocation(new POCOLocation(efLocation.LocationID, efLocation.Name, efLocation.CostRate, efLocation.Availability, efLocation.ModifiedDate));
		}

		public virtual void ProductMapModelToEF(
			int productID,
			ProductModel model,
			EFProduct efProduct)
		{
			efProduct.SetProperties(
				productID,
				model.Name,
				model.ProductNumber,
				model.MakeFlag,
				model.FinishedGoodsFlag,
				model.Color,
				model.SafetyStockLevel,
				model.ReorderPoint,
				model.StandardCost,
				model.ListPrice,
				model.Size,
				model.SizeUnitMeasureCode,
				model.WeightUnitMeasureCode,
				model.Weight,
				model.DaysToManufacture,
				model.ProductLine,
				model.@Class,
				model.Style,
				model.ProductSubcategoryID,
				model.ProductModelID,
				model.SellStartDate,
				model.SellEndDate,
				model.DiscontinuedDate,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void ProductMapEFToPOCO(
			EFProduct efProduct,
			ApiResponse response)
		{
			if (efProduct == null)
			{
				return;
			}

			response.AddProduct(new POCOProduct(efProduct.ProductID, efProduct.Name, efProduct.ProductNumber, efProduct.MakeFlag, efProduct.FinishedGoodsFlag, efProduct.Color, efProduct.SafetyStockLevel, efProduct.ReorderPoint, efProduct.StandardCost, efProduct.ListPrice, efProduct.Size, efProduct.SizeUnitMeasureCode, efProduct.WeightUnitMeasureCode, efProduct.Weight, efProduct.DaysToManufacture, efProduct.ProductLine, efProduct.@Class, efProduct.Style, efProduct.ProductSubcategoryID, efProduct.ProductModelID, efProduct.SellStartDate, efProduct.SellEndDate, efProduct.DiscontinuedDate, efProduct.Rowguid, efProduct.ModifiedDate));

			this.UnitMeasureMapEFToPOCO(efProduct.UnitMeasure, response);

			this.UnitMeasureMapEFToPOCO(efProduct.UnitMeasure1, response);

			this.ProductSubcategoryMapEFToPOCO(efProduct.ProductSubcategory, response);

			this.ProductModelMapEFToPOCO(efProduct.ProductModel, response);
		}

		public virtual void ProductCategoryMapModelToEF(
			int productCategoryID,
			ProductCategoryModel model,
			EFProductCategory efProductCategory)
		{
			efProductCategory.SetProperties(
				productCategoryID,
				model.Name,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void ProductCategoryMapEFToPOCO(
			EFProductCategory efProductCategory,
			ApiResponse response)
		{
			if (efProductCategory == null)
			{
				return;
			}

			response.AddProductCategory(new POCOProductCategory(efProductCategory.ProductCategoryID, efProductCategory.Name, efProductCategory.Rowguid, efProductCategory.ModifiedDate));
		}

		public virtual void ProductCostHistoryMapModelToEF(
			int productID,
			ProductCostHistoryModel model,
			EFProductCostHistory efProductCostHistory)
		{
			efProductCostHistory.SetProperties(
				productID,
				model.StartDate,
				model.EndDate,
				model.StandardCost,
				model.ModifiedDate);
		}

		public virtual void ProductCostHistoryMapEFToPOCO(
			EFProductCostHistory efProductCostHistory,
			ApiResponse response)
		{
			if (efProductCostHistory == null)
			{
				return;
			}

			response.AddProductCostHistory(new POCOProductCostHistory(efProductCostHistory.ProductID, efProductCostHistory.StartDate, efProductCostHistory.EndDate, efProductCostHistory.StandardCost, efProductCostHistory.ModifiedDate));

			this.ProductMapEFToPOCO(efProductCostHistory.Product, response);
		}

		public virtual void ProductDescriptionMapModelToEF(
			int productDescriptionID,
			ProductDescriptionModel model,
			EFProductDescription efProductDescription)
		{
			efProductDescription.SetProperties(
				productDescriptionID,
				model.Description,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void ProductDescriptionMapEFToPOCO(
			EFProductDescription efProductDescription,
			ApiResponse response)
		{
			if (efProductDescription == null)
			{
				return;
			}

			response.AddProductDescription(new POCOProductDescription(efProductDescription.ProductDescriptionID, efProductDescription.Description, efProductDescription.Rowguid, efProductDescription.ModifiedDate));
		}

		public virtual void ProductDocumentMapModelToEF(
			int productID,
			ProductDocumentModel model,
			EFProductDocument efProductDocument)
		{
			efProductDocument.SetProperties(
				productID,
				model.DocumentNode,
				model.ModifiedDate);
		}

		public virtual void ProductDocumentMapEFToPOCO(
			EFProductDocument efProductDocument,
			ApiResponse response)
		{
			if (efProductDocument == null)
			{
				return;
			}

			response.AddProductDocument(new POCOProductDocument(efProductDocument.ProductID, efProductDocument.DocumentNode, efProductDocument.ModifiedDate));

			this.ProductMapEFToPOCO(efProductDocument.Product, response);

			this.DocumentMapEFToPOCO(efProductDocument.Document, response);
		}

		public virtual void ProductInventoryMapModelToEF(
			int productID,
			ProductInventoryModel model,
			EFProductInventory efProductInventory)
		{
			efProductInventory.SetProperties(
				productID,
				model.LocationID,
				model.Shelf,
				model.Bin,
				model.Quantity,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void ProductInventoryMapEFToPOCO(
			EFProductInventory efProductInventory,
			ApiResponse response)
		{
			if (efProductInventory == null)
			{
				return;
			}

			response.AddProductInventory(new POCOProductInventory(efProductInventory.ProductID, efProductInventory.LocationID, efProductInventory.Shelf, efProductInventory.Bin, efProductInventory.Quantity, efProductInventory.Rowguid, efProductInventory.ModifiedDate));

			this.ProductMapEFToPOCO(efProductInventory.Product, response);

			this.LocationMapEFToPOCO(efProductInventory.Location, response);
		}

		public virtual void ProductListPriceHistoryMapModelToEF(
			int productID,
			ProductListPriceHistoryModel model,
			EFProductListPriceHistory efProductListPriceHistory)
		{
			efProductListPriceHistory.SetProperties(
				productID,
				model.StartDate,
				model.EndDate,
				model.ListPrice,
				model.ModifiedDate);
		}

		public virtual void ProductListPriceHistoryMapEFToPOCO(
			EFProductListPriceHistory efProductListPriceHistory,
			ApiResponse response)
		{
			if (efProductListPriceHistory == null)
			{
				return;
			}

			response.AddProductListPriceHistory(new POCOProductListPriceHistory(efProductListPriceHistory.ProductID, efProductListPriceHistory.StartDate, efProductListPriceHistory.EndDate, efProductListPriceHistory.ListPrice, efProductListPriceHistory.ModifiedDate));

			this.ProductMapEFToPOCO(efProductListPriceHistory.Product, response);
		}

		public virtual void ProductModelMapModelToEF(
			int productModelID,
			ProductModelModel model,
			EFProductModel efProductModel)
		{
			efProductModel.SetProperties(
				productModelID,
				model.Name,
				model.CatalogDescription,
				model.Instructions,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void ProductModelMapEFToPOCO(
			EFProductModel efProductModel,
			ApiResponse response)
		{
			if (efProductModel == null)
			{
				return;
			}

			response.AddProductModel(new POCOProductModel(efProductModel.ProductModelID, efProductModel.Name, efProductModel.CatalogDescription, efProductModel.Instructions, efProductModel.Rowguid, efProductModel.ModifiedDate));
		}

		public virtual void ProductModelIllustrationMapModelToEF(
			int productModelID,
			ProductModelIllustrationModel model,
			EFProductModelIllustration efProductModelIllustration)
		{
			efProductModelIllustration.SetProperties(
				productModelID,
				model.IllustrationID,
				model.ModifiedDate);
		}

		public virtual void ProductModelIllustrationMapEFToPOCO(
			EFProductModelIllustration efProductModelIllustration,
			ApiResponse response)
		{
			if (efProductModelIllustration == null)
			{
				return;
			}

			response.AddProductModelIllustration(new POCOProductModelIllustration(efProductModelIllustration.ProductModelID, efProductModelIllustration.IllustrationID, efProductModelIllustration.ModifiedDate));

			this.ProductModelMapEFToPOCO(efProductModelIllustration.ProductModel, response);

			this.IllustrationMapEFToPOCO(efProductModelIllustration.Illustration, response);
		}

		public virtual void ProductModelProductDescriptionCultureMapModelToEF(
			int productModelID,
			ProductModelProductDescriptionCultureModel model,
			EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture)
		{
			efProductModelProductDescriptionCulture.SetProperties(
				productModelID,
				model.ProductDescriptionID,
				model.CultureID,
				model.ModifiedDate);
		}

		public virtual void ProductModelProductDescriptionCultureMapEFToPOCO(
			EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture,
			ApiResponse response)
		{
			if (efProductModelProductDescriptionCulture == null)
			{
				return;
			}

			response.AddProductModelProductDescriptionCulture(new POCOProductModelProductDescriptionCulture(efProductModelProductDescriptionCulture.ProductModelID, efProductModelProductDescriptionCulture.ProductDescriptionID, efProductModelProductDescriptionCulture.CultureID, efProductModelProductDescriptionCulture.ModifiedDate));

			this.ProductModelMapEFToPOCO(efProductModelProductDescriptionCulture.ProductModel, response);

			this.ProductDescriptionMapEFToPOCO(efProductModelProductDescriptionCulture.ProductDescription, response);

			this.CultureMapEFToPOCO(efProductModelProductDescriptionCulture.Culture, response);
		}

		public virtual void ProductPhotoMapModelToEF(
			int productPhotoID,
			ProductPhotoModel model,
			EFProductPhoto efProductPhoto)
		{
			efProductPhoto.SetProperties(
				productPhotoID,
				model.ThumbNailPhoto,
				model.ThumbnailPhotoFileName,
				model.LargePhoto,
				model.LargePhotoFileName,
				model.ModifiedDate);
		}

		public virtual void ProductPhotoMapEFToPOCO(
			EFProductPhoto efProductPhoto,
			ApiResponse response)
		{
			if (efProductPhoto == null)
			{
				return;
			}

			response.AddProductPhoto(new POCOProductPhoto(efProductPhoto.ProductPhotoID, efProductPhoto.ThumbNailPhoto, efProductPhoto.ThumbnailPhotoFileName, efProductPhoto.LargePhoto, efProductPhoto.LargePhotoFileName, efProductPhoto.ModifiedDate));
		}

		public virtual void ProductProductPhotoMapModelToEF(
			int productID,
			ProductProductPhotoModel model,
			EFProductProductPhoto efProductProductPhoto)
		{
			efProductProductPhoto.SetProperties(
				productID,
				model.ProductPhotoID,
				model.Primary,
				model.ModifiedDate);
		}

		public virtual void ProductProductPhotoMapEFToPOCO(
			EFProductProductPhoto efProductProductPhoto,
			ApiResponse response)
		{
			if (efProductProductPhoto == null)
			{
				return;
			}

			response.AddProductProductPhoto(new POCOProductProductPhoto(efProductProductPhoto.ProductID, efProductProductPhoto.ProductPhotoID, efProductProductPhoto.Primary, efProductProductPhoto.ModifiedDate));

			this.ProductMapEFToPOCO(efProductProductPhoto.Product, response);

			this.ProductPhotoMapEFToPOCO(efProductProductPhoto.ProductPhoto, response);
		}

		public virtual void ProductReviewMapModelToEF(
			int productReviewID,
			ProductReviewModel model,
			EFProductReview efProductReview)
		{
			efProductReview.SetProperties(
				productReviewID,
				model.ProductID,
				model.ReviewerName,
				model.ReviewDate,
				model.EmailAddress,
				model.Rating,
				model.Comments,
				model.ModifiedDate);
		}

		public virtual void ProductReviewMapEFToPOCO(
			EFProductReview efProductReview,
			ApiResponse response)
		{
			if (efProductReview == null)
			{
				return;
			}

			response.AddProductReview(new POCOProductReview(efProductReview.ProductReviewID, efProductReview.ProductID, efProductReview.ReviewerName, efProductReview.ReviewDate, efProductReview.EmailAddress, efProductReview.Rating, efProductReview.Comments, efProductReview.ModifiedDate));

			this.ProductMapEFToPOCO(efProductReview.Product, response);
		}

		public virtual void ProductSubcategoryMapModelToEF(
			int productSubcategoryID,
			ProductSubcategoryModel model,
			EFProductSubcategory efProductSubcategory)
		{
			efProductSubcategory.SetProperties(
				productSubcategoryID,
				model.ProductCategoryID,
				model.Name,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void ProductSubcategoryMapEFToPOCO(
			EFProductSubcategory efProductSubcategory,
			ApiResponse response)
		{
			if (efProductSubcategory == null)
			{
				return;
			}

			response.AddProductSubcategory(new POCOProductSubcategory(efProductSubcategory.ProductSubcategoryID, efProductSubcategory.ProductCategoryID, efProductSubcategory.Name, efProductSubcategory.Rowguid, efProductSubcategory.ModifiedDate));

			this.ProductCategoryMapEFToPOCO(efProductSubcategory.ProductCategory, response);
		}

		public virtual void ScrapReasonMapModelToEF(
			short scrapReasonID,
			ScrapReasonModel model,
			EFScrapReason efScrapReason)
		{
			efScrapReason.SetProperties(
				scrapReasonID,
				model.Name,
				model.ModifiedDate);
		}

		public virtual void ScrapReasonMapEFToPOCO(
			EFScrapReason efScrapReason,
			ApiResponse response)
		{
			if (efScrapReason == null)
			{
				return;
			}

			response.AddScrapReason(new POCOScrapReason(efScrapReason.ScrapReasonID, efScrapReason.Name, efScrapReason.ModifiedDate));
		}

		public virtual void TransactionHistoryMapModelToEF(
			int transactionID,
			TransactionHistoryModel model,
			EFTransactionHistory efTransactionHistory)
		{
			efTransactionHistory.SetProperties(
				transactionID,
				model.ProductID,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType,
				model.Quantity,
				model.ActualCost,
				model.ModifiedDate);
		}

		public virtual void TransactionHistoryMapEFToPOCO(
			EFTransactionHistory efTransactionHistory,
			ApiResponse response)
		{
			if (efTransactionHistory == null)
			{
				return;
			}

			response.AddTransactionHistory(new POCOTransactionHistory(efTransactionHistory.TransactionID, efTransactionHistory.ProductID, efTransactionHistory.ReferenceOrderID, efTransactionHistory.ReferenceOrderLineID, efTransactionHistory.TransactionDate, efTransactionHistory.TransactionType, efTransactionHistory.Quantity, efTransactionHistory.ActualCost, efTransactionHistory.ModifiedDate));

			this.ProductMapEFToPOCO(efTransactionHistory.Product, response);
		}

		public virtual void TransactionHistoryArchiveMapModelToEF(
			int transactionID,
			TransactionHistoryArchiveModel model,
			EFTransactionHistoryArchive efTransactionHistoryArchive)
		{
			efTransactionHistoryArchive.SetProperties(
				transactionID,
				model.ProductID,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType,
				model.Quantity,
				model.ActualCost,
				model.ModifiedDate);
		}

		public virtual void TransactionHistoryArchiveMapEFToPOCO(
			EFTransactionHistoryArchive efTransactionHistoryArchive,
			ApiResponse response)
		{
			if (efTransactionHistoryArchive == null)
			{
				return;
			}

			response.AddTransactionHistoryArchive(new POCOTransactionHistoryArchive(efTransactionHistoryArchive.TransactionID, efTransactionHistoryArchive.ProductID, efTransactionHistoryArchive.ReferenceOrderID, efTransactionHistoryArchive.ReferenceOrderLineID, efTransactionHistoryArchive.TransactionDate, efTransactionHistoryArchive.TransactionType, efTransactionHistoryArchive.Quantity, efTransactionHistoryArchive.ActualCost, efTransactionHistoryArchive.ModifiedDate));
		}

		public virtual void UnitMeasureMapModelToEF(
			string unitMeasureCode,
			UnitMeasureModel model,
			EFUnitMeasure efUnitMeasure)
		{
			efUnitMeasure.SetProperties(
				unitMeasureCode,
				model.Name,
				model.ModifiedDate);
		}

		public virtual void UnitMeasureMapEFToPOCO(
			EFUnitMeasure efUnitMeasure,
			ApiResponse response)
		{
			if (efUnitMeasure == null)
			{
				return;
			}

			response.AddUnitMeasure(new POCOUnitMeasure(efUnitMeasure.UnitMeasureCode, efUnitMeasure.Name, efUnitMeasure.ModifiedDate));
		}

		public virtual void WorkOrderMapModelToEF(
			int workOrderID,
			WorkOrderModel model,
			EFWorkOrder efWorkOrder)
		{
			efWorkOrder.SetProperties(
				workOrderID,
				model.ProductID,
				model.OrderQty,
				model.StockedQty,
				model.ScrappedQty,
				model.StartDate,
				model.EndDate,
				model.DueDate,
				model.ScrapReasonID,
				model.ModifiedDate);
		}

		public virtual void WorkOrderMapEFToPOCO(
			EFWorkOrder efWorkOrder,
			ApiResponse response)
		{
			if (efWorkOrder == null)
			{
				return;
			}

			response.AddWorkOrder(new POCOWorkOrder(efWorkOrder.WorkOrderID, efWorkOrder.ProductID, efWorkOrder.OrderQty, efWorkOrder.StockedQty, efWorkOrder.ScrappedQty, efWorkOrder.StartDate, efWorkOrder.EndDate, efWorkOrder.DueDate, efWorkOrder.ScrapReasonID, efWorkOrder.ModifiedDate));

			this.ProductMapEFToPOCO(efWorkOrder.Product, response);

			this.ScrapReasonMapEFToPOCO(efWorkOrder.ScrapReason, response);
		}

		public virtual void WorkOrderRoutingMapModelToEF(
			int workOrderID,
			WorkOrderRoutingModel model,
			EFWorkOrderRouting efWorkOrderRouting)
		{
			efWorkOrderRouting.SetProperties(
				workOrderID,
				model.ProductID,
				model.OperationSequence,
				model.LocationID,
				model.ScheduledStartDate,
				model.ScheduledEndDate,
				model.ActualStartDate,
				model.ActualEndDate,
				model.ActualResourceHrs,
				model.PlannedCost,
				model.ActualCost,
				model.ModifiedDate);
		}

		public virtual void WorkOrderRoutingMapEFToPOCO(
			EFWorkOrderRouting efWorkOrderRouting,
			ApiResponse response)
		{
			if (efWorkOrderRouting == null)
			{
				return;
			}

			response.AddWorkOrderRouting(new POCOWorkOrderRouting(efWorkOrderRouting.WorkOrderID, efWorkOrderRouting.ProductID, efWorkOrderRouting.OperationSequence, efWorkOrderRouting.LocationID, efWorkOrderRouting.ScheduledStartDate, efWorkOrderRouting.ScheduledEndDate, efWorkOrderRouting.ActualStartDate, efWorkOrderRouting.ActualEndDate, efWorkOrderRouting.ActualResourceHrs, efWorkOrderRouting.PlannedCost, efWorkOrderRouting.ActualCost, efWorkOrderRouting.ModifiedDate));

			this.WorkOrderMapEFToPOCO(efWorkOrderRouting.WorkOrder, response);

			this.LocationMapEFToPOCO(efWorkOrderRouting.Location, response);
		}

		public virtual void ProductVendorMapModelToEF(
			int productID,
			ProductVendorModel model,
			EFProductVendor efProductVendor)
		{
			efProductVendor.SetProperties(
				productID,
				model.BusinessEntityID,
				model.AverageLeadTime,
				model.StandardPrice,
				model.LastReceiptCost,
				model.LastReceiptDate,
				model.MinOrderQty,
				model.MaxOrderQty,
				model.OnOrderQty,
				model.UnitMeasureCode,
				model.ModifiedDate);
		}

		public virtual void ProductVendorMapEFToPOCO(
			EFProductVendor efProductVendor,
			ApiResponse response)
		{
			if (efProductVendor == null)
			{
				return;
			}

			response.AddProductVendor(new POCOProductVendor(efProductVendor.ProductID, efProductVendor.BusinessEntityID, efProductVendor.AverageLeadTime, efProductVendor.StandardPrice, efProductVendor.LastReceiptCost, efProductVendor.LastReceiptDate, efProductVendor.MinOrderQty, efProductVendor.MaxOrderQty, efProductVendor.OnOrderQty, efProductVendor.UnitMeasureCode, efProductVendor.ModifiedDate));

			this.ProductMapEFToPOCO(efProductVendor.Product, response);

			this.VendorMapEFToPOCO(efProductVendor.Vendor, response);

			this.UnitMeasureMapEFToPOCO(efProductVendor.UnitMeasure, response);
		}

		public virtual void PurchaseOrderDetailMapModelToEF(
			int purchaseOrderID,
			PurchaseOrderDetailModel model,
			EFPurchaseOrderDetail efPurchaseOrderDetail)
		{
			efPurchaseOrderDetail.SetProperties(
				purchaseOrderID,
				model.PurchaseOrderDetailID,
				model.DueDate,
				model.OrderQty,
				model.ProductID,
				model.UnitPrice,
				model.LineTotal,
				model.ReceivedQty,
				model.RejectedQty,
				model.StockedQty,
				model.ModifiedDate);
		}

		public virtual void PurchaseOrderDetailMapEFToPOCO(
			EFPurchaseOrderDetail efPurchaseOrderDetail,
			ApiResponse response)
		{
			if (efPurchaseOrderDetail == null)
			{
				return;
			}

			response.AddPurchaseOrderDetail(new POCOPurchaseOrderDetail(efPurchaseOrderDetail.PurchaseOrderID, efPurchaseOrderDetail.PurchaseOrderDetailID, efPurchaseOrderDetail.DueDate, efPurchaseOrderDetail.OrderQty, efPurchaseOrderDetail.ProductID, efPurchaseOrderDetail.UnitPrice, efPurchaseOrderDetail.LineTotal, efPurchaseOrderDetail.ReceivedQty, efPurchaseOrderDetail.RejectedQty, efPurchaseOrderDetail.StockedQty, efPurchaseOrderDetail.ModifiedDate));

			this.PurchaseOrderHeaderMapEFToPOCO(efPurchaseOrderDetail.PurchaseOrderHeader, response);

			this.ProductMapEFToPOCO(efPurchaseOrderDetail.Product, response);
		}

		public virtual void PurchaseOrderHeaderMapModelToEF(
			int purchaseOrderID,
			PurchaseOrderHeaderModel model,
			EFPurchaseOrderHeader efPurchaseOrderHeader)
		{
			efPurchaseOrderHeader.SetProperties(
				purchaseOrderID,
				model.RevisionNumber,
				model.Status,
				model.EmployeeID,
				model.VendorID,
				model.ShipMethodID,
				model.OrderDate,
				model.ShipDate,
				model.SubTotal,
				model.TaxAmt,
				model.Freight,
				model.TotalDue,
				model.ModifiedDate);
		}

		public virtual void PurchaseOrderHeaderMapEFToPOCO(
			EFPurchaseOrderHeader efPurchaseOrderHeader,
			ApiResponse response)
		{
			if (efPurchaseOrderHeader == null)
			{
				return;
			}

			response.AddPurchaseOrderHeader(new POCOPurchaseOrderHeader(efPurchaseOrderHeader.PurchaseOrderID, efPurchaseOrderHeader.RevisionNumber, efPurchaseOrderHeader.Status, efPurchaseOrderHeader.EmployeeID, efPurchaseOrderHeader.VendorID, efPurchaseOrderHeader.ShipMethodID, efPurchaseOrderHeader.OrderDate, efPurchaseOrderHeader.ShipDate, efPurchaseOrderHeader.SubTotal, efPurchaseOrderHeader.TaxAmt, efPurchaseOrderHeader.Freight, efPurchaseOrderHeader.TotalDue, efPurchaseOrderHeader.ModifiedDate));

			this.EmployeeMapEFToPOCO(efPurchaseOrderHeader.Employee, response);

			this.VendorMapEFToPOCO(efPurchaseOrderHeader.Vendor, response);

			this.ShipMethodMapEFToPOCO(efPurchaseOrderHeader.ShipMethod, response);
		}

		public virtual void ShipMethodMapModelToEF(
			int shipMethodID,
			ShipMethodModel model,
			EFShipMethod efShipMethod)
		{
			efShipMethod.SetProperties(
				shipMethodID,
				model.Name,
				model.ShipBase,
				model.ShipRate,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void ShipMethodMapEFToPOCO(
			EFShipMethod efShipMethod,
			ApiResponse response)
		{
			if (efShipMethod == null)
			{
				return;
			}

			response.AddShipMethod(new POCOShipMethod(efShipMethod.ShipMethodID, efShipMethod.Name, efShipMethod.ShipBase, efShipMethod.ShipRate, efShipMethod.Rowguid, efShipMethod.ModifiedDate));
		}

		public virtual void VendorMapModelToEF(
			int businessEntityID,
			VendorModel model,
			EFVendor efVendor)
		{
			efVendor.SetProperties(
				businessEntityID,
				model.AccountNumber,
				model.Name,
				model.CreditRating,
				model.PreferredVendorStatus,
				model.ActiveFlag,
				model.PurchasingWebServiceURL,
				model.ModifiedDate);
		}

		public virtual void VendorMapEFToPOCO(
			EFVendor efVendor,
			ApiResponse response)
		{
			if (efVendor == null)
			{
				return;
			}

			response.AddVendor(new POCOVendor(efVendor.BusinessEntityID, efVendor.AccountNumber, efVendor.Name, efVendor.CreditRating, efVendor.PreferredVendorStatus, efVendor.ActiveFlag, efVendor.PurchasingWebServiceURL, efVendor.ModifiedDate));

			this.BusinessEntityMapEFToPOCO(efVendor.BusinessEntity, response);
		}

		public virtual void CountryRegionCurrencyMapModelToEF(
			string countryRegionCode,
			CountryRegionCurrencyModel model,
			EFCountryRegionCurrency efCountryRegionCurrency)
		{
			efCountryRegionCurrency.SetProperties(
				countryRegionCode,
				model.CurrencyCode,
				model.ModifiedDate);
		}

		public virtual void CountryRegionCurrencyMapEFToPOCO(
			EFCountryRegionCurrency efCountryRegionCurrency,
			ApiResponse response)
		{
			if (efCountryRegionCurrency == null)
			{
				return;
			}

			response.AddCountryRegionCurrency(new POCOCountryRegionCurrency(efCountryRegionCurrency.CountryRegionCode, efCountryRegionCurrency.CurrencyCode, efCountryRegionCurrency.ModifiedDate));

			this.CountryRegionMapEFToPOCO(efCountryRegionCurrency.CountryRegion, response);

			this.CurrencyMapEFToPOCO(efCountryRegionCurrency.Currency, response);
		}

		public virtual void CreditCardMapModelToEF(
			int creditCardID,
			CreditCardModel model,
			EFCreditCard efCreditCard)
		{
			efCreditCard.SetProperties(
				creditCardID,
				model.CardType,
				model.CardNumber,
				model.ExpMonth,
				model.ExpYear,
				model.ModifiedDate);
		}

		public virtual void CreditCardMapEFToPOCO(
			EFCreditCard efCreditCard,
			ApiResponse response)
		{
			if (efCreditCard == null)
			{
				return;
			}

			response.AddCreditCard(new POCOCreditCard(efCreditCard.CreditCardID, efCreditCard.CardType, efCreditCard.CardNumber, efCreditCard.ExpMonth, efCreditCard.ExpYear, efCreditCard.ModifiedDate));
		}

		public virtual void CurrencyMapModelToEF(
			string currencyCode,
			CurrencyModel model,
			EFCurrency efCurrency)
		{
			efCurrency.SetProperties(
				currencyCode,
				model.Name,
				model.ModifiedDate);
		}

		public virtual void CurrencyMapEFToPOCO(
			EFCurrency efCurrency,
			ApiResponse response)
		{
			if (efCurrency == null)
			{
				return;
			}

			response.AddCurrency(new POCOCurrency(efCurrency.CurrencyCode, efCurrency.Name, efCurrency.ModifiedDate));
		}

		public virtual void CurrencyRateMapModelToEF(
			int currencyRateID,
			CurrencyRateModel model,
			EFCurrencyRate efCurrencyRate)
		{
			efCurrencyRate.SetProperties(
				currencyRateID,
				model.CurrencyRateDate,
				model.FromCurrencyCode,
				model.ToCurrencyCode,
				model.AverageRate,
				model.EndOfDayRate,
				model.ModifiedDate);
		}

		public virtual void CurrencyRateMapEFToPOCO(
			EFCurrencyRate efCurrencyRate,
			ApiResponse response)
		{
			if (efCurrencyRate == null)
			{
				return;
			}

			response.AddCurrencyRate(new POCOCurrencyRate(efCurrencyRate.CurrencyRateID, efCurrencyRate.CurrencyRateDate, efCurrencyRate.FromCurrencyCode, efCurrencyRate.ToCurrencyCode, efCurrencyRate.AverageRate, efCurrencyRate.EndOfDayRate, efCurrencyRate.ModifiedDate));

			this.CurrencyMapEFToPOCO(efCurrencyRate.Currency, response);

			this.CurrencyMapEFToPOCO(efCurrencyRate.Currency1, response);
		}

		public virtual void CustomerMapModelToEF(
			int customerID,
			CustomerModel model,
			EFCustomer efCustomer)
		{
			efCustomer.SetProperties(
				customerID,
				model.PersonID,
				model.StoreID,
				model.TerritoryID,
				model.AccountNumber,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void CustomerMapEFToPOCO(
			EFCustomer efCustomer,
			ApiResponse response)
		{
			if (efCustomer == null)
			{
				return;
			}

			response.AddCustomer(new POCOCustomer(efCustomer.CustomerID, efCustomer.PersonID, efCustomer.StoreID, efCustomer.TerritoryID, efCustomer.AccountNumber, efCustomer.Rowguid, efCustomer.ModifiedDate));

			this.PersonMapEFToPOCO(efCustomer.Person, response);

			this.StoreMapEFToPOCO(efCustomer.Store, response);

			this.SalesTerritoryMapEFToPOCO(efCustomer.SalesTerritory, response);
		}

		public virtual void PersonCreditCardMapModelToEF(
			int businessEntityID,
			PersonCreditCardModel model,
			EFPersonCreditCard efPersonCreditCard)
		{
			efPersonCreditCard.SetProperties(
				businessEntityID,
				model.CreditCardID,
				model.ModifiedDate);
		}

		public virtual void PersonCreditCardMapEFToPOCO(
			EFPersonCreditCard efPersonCreditCard,
			ApiResponse response)
		{
			if (efPersonCreditCard == null)
			{
				return;
			}

			response.AddPersonCreditCard(new POCOPersonCreditCard(efPersonCreditCard.BusinessEntityID, efPersonCreditCard.CreditCardID, efPersonCreditCard.ModifiedDate));

			this.PersonMapEFToPOCO(efPersonCreditCard.Person, response);

			this.CreditCardMapEFToPOCO(efPersonCreditCard.CreditCard, response);
		}

		public virtual void SalesOrderDetailMapModelToEF(
			int salesOrderID,
			SalesOrderDetailModel model,
			EFSalesOrderDetail efSalesOrderDetail)
		{
			efSalesOrderDetail.SetProperties(
				salesOrderID,
				model.SalesOrderDetailID,
				model.CarrierTrackingNumber,
				model.OrderQty,
				model.ProductID,
				model.SpecialOfferID,
				model.UnitPrice,
				model.UnitPriceDiscount,
				model.LineTotal,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void SalesOrderDetailMapEFToPOCO(
			EFSalesOrderDetail efSalesOrderDetail,
			ApiResponse response)
		{
			if (efSalesOrderDetail == null)
			{
				return;
			}

			response.AddSalesOrderDetail(new POCOSalesOrderDetail(efSalesOrderDetail.SalesOrderID, efSalesOrderDetail.SalesOrderDetailID, efSalesOrderDetail.CarrierTrackingNumber, efSalesOrderDetail.OrderQty, efSalesOrderDetail.ProductID, efSalesOrderDetail.SpecialOfferID, efSalesOrderDetail.UnitPrice, efSalesOrderDetail.UnitPriceDiscount, efSalesOrderDetail.LineTotal, efSalesOrderDetail.Rowguid, efSalesOrderDetail.ModifiedDate));

			this.SalesOrderHeaderMapEFToPOCO(efSalesOrderDetail.SalesOrderHeader, response);

			this.SpecialOfferProductMapEFToPOCO(efSalesOrderDetail.SpecialOfferProduct, response);
		}

		public virtual void SalesOrderHeaderMapModelToEF(
			int salesOrderID,
			SalesOrderHeaderModel model,
			EFSalesOrderHeader efSalesOrderHeader)
		{
			efSalesOrderHeader.SetProperties(
				salesOrderID,
				model.RevisionNumber,
				model.OrderDate,
				model.DueDate,
				model.ShipDate,
				model.Status,
				model.OnlineOrderFlag,
				model.SalesOrderNumber,
				model.PurchaseOrderNumber,
				model.AccountNumber,
				model.CustomerID,
				model.SalesPersonID,
				model.TerritoryID,
				model.BillToAddressID,
				model.ShipToAddressID,
				model.ShipMethodID,
				model.CreditCardID,
				model.CreditCardApprovalCode,
				model.CurrencyRateID,
				model.SubTotal,
				model.TaxAmt,
				model.Freight,
				model.TotalDue,
				model.Comment,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void SalesOrderHeaderMapEFToPOCO(
			EFSalesOrderHeader efSalesOrderHeader,
			ApiResponse response)
		{
			if (efSalesOrderHeader == null)
			{
				return;
			}

			response.AddSalesOrderHeader(new POCOSalesOrderHeader(efSalesOrderHeader.SalesOrderID, efSalesOrderHeader.RevisionNumber, efSalesOrderHeader.OrderDate, efSalesOrderHeader.DueDate, efSalesOrderHeader.ShipDate, efSalesOrderHeader.Status, efSalesOrderHeader.OnlineOrderFlag, efSalesOrderHeader.SalesOrderNumber, efSalesOrderHeader.PurchaseOrderNumber, efSalesOrderHeader.AccountNumber, efSalesOrderHeader.CustomerID, efSalesOrderHeader.SalesPersonID, efSalesOrderHeader.TerritoryID, efSalesOrderHeader.BillToAddressID, efSalesOrderHeader.ShipToAddressID, efSalesOrderHeader.ShipMethodID, efSalesOrderHeader.CreditCardID, efSalesOrderHeader.CreditCardApprovalCode, efSalesOrderHeader.CurrencyRateID, efSalesOrderHeader.SubTotal, efSalesOrderHeader.TaxAmt, efSalesOrderHeader.Freight, efSalesOrderHeader.TotalDue, efSalesOrderHeader.Comment, efSalesOrderHeader.Rowguid, efSalesOrderHeader.ModifiedDate));

			this.CustomerMapEFToPOCO(efSalesOrderHeader.Customer, response);

			this.SalesPersonMapEFToPOCO(efSalesOrderHeader.SalesPerson, response);

			this.SalesTerritoryMapEFToPOCO(efSalesOrderHeader.SalesTerritory, response);

			this.AddressMapEFToPOCO(efSalesOrderHeader.Address, response);

			this.AddressMapEFToPOCO(efSalesOrderHeader.Address1, response);

			this.ShipMethodMapEFToPOCO(efSalesOrderHeader.ShipMethod, response);

			this.CreditCardMapEFToPOCO(efSalesOrderHeader.CreditCard, response);

			this.CurrencyRateMapEFToPOCO(efSalesOrderHeader.CurrencyRate, response);
		}

		public virtual void SalesOrderHeaderSalesReasonMapModelToEF(
			int salesOrderID,
			SalesOrderHeaderSalesReasonModel model,
			EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason)
		{
			efSalesOrderHeaderSalesReason.SetProperties(
				salesOrderID,
				model.SalesReasonID,
				model.ModifiedDate);
		}

		public virtual void SalesOrderHeaderSalesReasonMapEFToPOCO(
			EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason,
			ApiResponse response)
		{
			if (efSalesOrderHeaderSalesReason == null)
			{
				return;
			}

			response.AddSalesOrderHeaderSalesReason(new POCOSalesOrderHeaderSalesReason(efSalesOrderHeaderSalesReason.SalesOrderID, efSalesOrderHeaderSalesReason.SalesReasonID, efSalesOrderHeaderSalesReason.ModifiedDate));

			this.SalesOrderHeaderMapEFToPOCO(efSalesOrderHeaderSalesReason.SalesOrderHeader, response);

			this.SalesReasonMapEFToPOCO(efSalesOrderHeaderSalesReason.SalesReason, response);
		}

		public virtual void SalesPersonMapModelToEF(
			int businessEntityID,
			SalesPersonModel model,
			EFSalesPerson efSalesPerson)
		{
			efSalesPerson.SetProperties(
				businessEntityID,
				model.TerritoryID,
				model.SalesQuota,
				model.Bonus,
				model.CommissionPct,
				model.SalesYTD,
				model.SalesLastYear,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void SalesPersonMapEFToPOCO(
			EFSalesPerson efSalesPerson,
			ApiResponse response)
		{
			if (efSalesPerson == null)
			{
				return;
			}

			response.AddSalesPerson(new POCOSalesPerson(efSalesPerson.BusinessEntityID, efSalesPerson.TerritoryID, efSalesPerson.SalesQuota, efSalesPerson.Bonus, efSalesPerson.CommissionPct, efSalesPerson.SalesYTD, efSalesPerson.SalesLastYear, efSalesPerson.Rowguid, efSalesPerson.ModifiedDate));

			this.EmployeeMapEFToPOCO(efSalesPerson.Employee, response);

			this.SalesTerritoryMapEFToPOCO(efSalesPerson.SalesTerritory, response);
		}

		public virtual void SalesPersonQuotaHistoryMapModelToEF(
			int businessEntityID,
			SalesPersonQuotaHistoryModel model,
			EFSalesPersonQuotaHistory efSalesPersonQuotaHistory)
		{
			efSalesPersonQuotaHistory.SetProperties(
				businessEntityID,
				model.QuotaDate,
				model.SalesQuota,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void SalesPersonQuotaHistoryMapEFToPOCO(
			EFSalesPersonQuotaHistory efSalesPersonQuotaHistory,
			ApiResponse response)
		{
			if (efSalesPersonQuotaHistory == null)
			{
				return;
			}

			response.AddSalesPersonQuotaHistory(new POCOSalesPersonQuotaHistory(efSalesPersonQuotaHistory.BusinessEntityID, efSalesPersonQuotaHistory.QuotaDate, efSalesPersonQuotaHistory.SalesQuota, efSalesPersonQuotaHistory.Rowguid, efSalesPersonQuotaHistory.ModifiedDate));

			this.SalesPersonMapEFToPOCO(efSalesPersonQuotaHistory.SalesPerson, response);
		}

		public virtual void SalesReasonMapModelToEF(
			int salesReasonID,
			SalesReasonModel model,
			EFSalesReason efSalesReason)
		{
			efSalesReason.SetProperties(
				salesReasonID,
				model.Name,
				model.ReasonType,
				model.ModifiedDate);
		}

		public virtual void SalesReasonMapEFToPOCO(
			EFSalesReason efSalesReason,
			ApiResponse response)
		{
			if (efSalesReason == null)
			{
				return;
			}

			response.AddSalesReason(new POCOSalesReason(efSalesReason.SalesReasonID, efSalesReason.Name, efSalesReason.ReasonType, efSalesReason.ModifiedDate));
		}

		public virtual void SalesTaxRateMapModelToEF(
			int salesTaxRateID,
			SalesTaxRateModel model,
			EFSalesTaxRate efSalesTaxRate)
		{
			efSalesTaxRate.SetProperties(
				salesTaxRateID,
				model.StateProvinceID,
				model.TaxType,
				model.TaxRate,
				model.Name,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void SalesTaxRateMapEFToPOCO(
			EFSalesTaxRate efSalesTaxRate,
			ApiResponse response)
		{
			if (efSalesTaxRate == null)
			{
				return;
			}

			response.AddSalesTaxRate(new POCOSalesTaxRate(efSalesTaxRate.SalesTaxRateID, efSalesTaxRate.StateProvinceID, efSalesTaxRate.TaxType, efSalesTaxRate.TaxRate, efSalesTaxRate.Name, efSalesTaxRate.Rowguid, efSalesTaxRate.ModifiedDate));

			this.StateProvinceMapEFToPOCO(efSalesTaxRate.StateProvince, response);
		}

		public virtual void SalesTerritoryMapModelToEF(
			int territoryID,
			SalesTerritoryModel model,
			EFSalesTerritory efSalesTerritory)
		{
			efSalesTerritory.SetProperties(
				territoryID,
				model.Name,
				model.CountryRegionCode,
				model.@Group,
				model.SalesYTD,
				model.SalesLastYear,
				model.CostYTD,
				model.CostLastYear,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void SalesTerritoryMapEFToPOCO(
			EFSalesTerritory efSalesTerritory,
			ApiResponse response)
		{
			if (efSalesTerritory == null)
			{
				return;
			}

			response.AddSalesTerritory(new POCOSalesTerritory(efSalesTerritory.TerritoryID, efSalesTerritory.Name, efSalesTerritory.CountryRegionCode, efSalesTerritory.@Group, efSalesTerritory.SalesYTD, efSalesTerritory.SalesLastYear, efSalesTerritory.CostYTD, efSalesTerritory.CostLastYear, efSalesTerritory.Rowguid, efSalesTerritory.ModifiedDate));

			this.CountryRegionMapEFToPOCO(efSalesTerritory.CountryRegion, response);
		}

		public virtual void SalesTerritoryHistoryMapModelToEF(
			int businessEntityID,
			SalesTerritoryHistoryModel model,
			EFSalesTerritoryHistory efSalesTerritoryHistory)
		{
			efSalesTerritoryHistory.SetProperties(
				businessEntityID,
				model.TerritoryID,
				model.StartDate,
				model.EndDate,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void SalesTerritoryHistoryMapEFToPOCO(
			EFSalesTerritoryHistory efSalesTerritoryHistory,
			ApiResponse response)
		{
			if (efSalesTerritoryHistory == null)
			{
				return;
			}

			response.AddSalesTerritoryHistory(new POCOSalesTerritoryHistory(efSalesTerritoryHistory.BusinessEntityID, efSalesTerritoryHistory.TerritoryID, efSalesTerritoryHistory.StartDate, efSalesTerritoryHistory.EndDate, efSalesTerritoryHistory.Rowguid, efSalesTerritoryHistory.ModifiedDate));

			this.SalesPersonMapEFToPOCO(efSalesTerritoryHistory.SalesPerson, response);

			this.SalesTerritoryMapEFToPOCO(efSalesTerritoryHistory.SalesTerritory, response);
		}

		public virtual void ShoppingCartItemMapModelToEF(
			int shoppingCartItemID,
			ShoppingCartItemModel model,
			EFShoppingCartItem efShoppingCartItem)
		{
			efShoppingCartItem.SetProperties(
				shoppingCartItemID,
				model.ShoppingCartID,
				model.Quantity,
				model.ProductID,
				model.DateCreated,
				model.ModifiedDate);
		}

		public virtual void ShoppingCartItemMapEFToPOCO(
			EFShoppingCartItem efShoppingCartItem,
			ApiResponse response)
		{
			if (efShoppingCartItem == null)
			{
				return;
			}

			response.AddShoppingCartItem(new POCOShoppingCartItem(efShoppingCartItem.ShoppingCartItemID, efShoppingCartItem.ShoppingCartID, efShoppingCartItem.Quantity, efShoppingCartItem.ProductID, efShoppingCartItem.DateCreated, efShoppingCartItem.ModifiedDate));

			this.ProductMapEFToPOCO(efShoppingCartItem.Product, response);
		}

		public virtual void SpecialOfferMapModelToEF(
			int specialOfferID,
			SpecialOfferModel model,
			EFSpecialOffer efSpecialOffer)
		{
			efSpecialOffer.SetProperties(
				specialOfferID,
				model.Description,
				model.DiscountPct,
				model.Type,
				model.Category,
				model.StartDate,
				model.EndDate,
				model.MinQty,
				model.MaxQty,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void SpecialOfferMapEFToPOCO(
			EFSpecialOffer efSpecialOffer,
			ApiResponse response)
		{
			if (efSpecialOffer == null)
			{
				return;
			}

			response.AddSpecialOffer(new POCOSpecialOffer(efSpecialOffer.SpecialOfferID, efSpecialOffer.Description, efSpecialOffer.DiscountPct, efSpecialOffer.Type, efSpecialOffer.Category, efSpecialOffer.StartDate, efSpecialOffer.EndDate, efSpecialOffer.MinQty, efSpecialOffer.MaxQty, efSpecialOffer.Rowguid, efSpecialOffer.ModifiedDate));
		}

		public virtual void SpecialOfferProductMapModelToEF(
			int specialOfferID,
			SpecialOfferProductModel model,
			EFSpecialOfferProduct efSpecialOfferProduct)
		{
			efSpecialOfferProduct.SetProperties(
				specialOfferID,
				model.ProductID,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void SpecialOfferProductMapEFToPOCO(
			EFSpecialOfferProduct efSpecialOfferProduct,
			ApiResponse response)
		{
			if (efSpecialOfferProduct == null)
			{
				return;
			}

			response.AddSpecialOfferProduct(new POCOSpecialOfferProduct(efSpecialOfferProduct.SpecialOfferID, efSpecialOfferProduct.ProductID, efSpecialOfferProduct.Rowguid, efSpecialOfferProduct.ModifiedDate));

			this.SpecialOfferMapEFToPOCO(efSpecialOfferProduct.SpecialOffer, response);

			this.ProductMapEFToPOCO(efSpecialOfferProduct.Product, response);
		}

		public virtual void StoreMapModelToEF(
			int businessEntityID,
			StoreModel model,
			EFStore efStore)
		{
			efStore.SetProperties(
				businessEntityID,
				model.Name,
				model.SalesPersonID,
				model.Demographics,
				model.Rowguid,
				model.ModifiedDate);
		}

		public virtual void StoreMapEFToPOCO(
			EFStore efStore,
			ApiResponse response)
		{
			if (efStore == null)
			{
				return;
			}

			response.AddStore(new POCOStore(efStore.BusinessEntityID, efStore.Name, efStore.SalesPersonID, efStore.Demographics, efStore.Rowguid, efStore.ModifiedDate));

			this.BusinessEntityMapEFToPOCO(efStore.BusinessEntity, response);

			this.SalesPersonMapEFToPOCO(efStore.SalesPerson, response);
		}
	}
}

/*<Codenesium>
    <Hash>0623ab32885b1a93ff92f020b757bc5d</Hash>
</Codenesium>*/