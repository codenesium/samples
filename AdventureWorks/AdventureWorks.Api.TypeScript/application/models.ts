export class ApiAWBuildVersionRequestModel {
				database_Version:string;
modifiedDate:string;
systemInformationID:number;
versionDate:string;

	
				constructor() {
					this.database_Version = '';
this.modifiedDate = '';
this.systemInformationID = 0;
this.versionDate = '';

		
				}
			}

			export class ApiAWBuildVersionResponseModel {
				database_Version:string;
modifiedDate:string;
systemInformationID:number;
versionDate:string;

	
				constructor() {
					this.database_Version = '';
this.modifiedDate = '';
this.systemInformationID = 0;
this.versionDate = '';

		
				}
			}
			export class ApiDatabaseLogRequestModel {
				databaseLogID:number;
databaseUser:string;
event:string;
object:string;
postTime:string;
schema:string;
tsql:string;
xmlEvent:string;

	
				constructor() {
					this.databaseLogID = 0;
this.databaseUser = '';
this.event = '';
this.object = '';
this.postTime = '';
this.schema = '';
this.tsql = '';
this.xmlEvent = '';

		
				}
			}

			export class ApiDatabaseLogResponseModel {
				databaseLogID:number;
databaseUser:string;
event:string;
object:string;
postTime:string;
schema:string;
tsql:string;
xmlEvent:string;

	
				constructor() {
					this.databaseLogID = 0;
this.databaseUser = '';
this.event = '';
this.object = '';
this.postTime = '';
this.schema = '';
this.tsql = '';
this.xmlEvent = '';

		
				}
			}
			export class ApiErrorLogRequestModel {
				errorLine:number;
errorLogID:number;
errorMessage:string;
errorNumber:number;
errorProcedure:string;
errorSeverity:number;
errorState:number;
errorTime:string;
userName:string;

	
				constructor() {
					this.errorLine = 0;
this.errorLogID = 0;
this.errorMessage = '';
this.errorNumber = 0;
this.errorProcedure = '';
this.errorSeverity = 0;
this.errorState = 0;
this.errorTime = '';
this.userName = '';

		
				}
			}

			export class ApiErrorLogResponseModel {
				errorLine:number;
errorLogID:number;
errorMessage:string;
errorNumber:number;
errorProcedure:string;
errorSeverity:number;
errorState:number;
errorTime:string;
userName:string;

	
				constructor() {
					this.errorLine = 0;
this.errorLogID = 0;
this.errorMessage = '';
this.errorNumber = 0;
this.errorProcedure = '';
this.errorSeverity = 0;
this.errorState = 0;
this.errorTime = '';
this.userName = '';

		
				}
			}
			export class ApiDepartmentRequestModel {
				departmentID:number;
groupName:string;
modifiedDate:string;
name:string;

	
				constructor() {
					this.departmentID = 0;
this.groupName = '';
this.modifiedDate = '';
this.name = '';

		
				}
			}

			export class ApiDepartmentResponseModel {
				departmentID:number;
groupName:string;
modifiedDate:string;
name:string;

	
				constructor() {
					this.departmentID = 0;
this.groupName = '';
this.modifiedDate = '';
this.name = '';

		
				}
			}
			export class ApiEmployeeRequestModel {
				birthDate:string;
businessEntityID:number;
currentFlag:boolean;
gender:string;
hireDate:string;
jobTitle:string;
loginID:string;
maritalStatu:string;
modifiedDate:string;
nationalIDNumber:string;
organizationLevel:number;
rowguid:string;
salariedFlag:boolean;
sickLeaveHour:number;
vacationHour:number;

	
				constructor() {
					this.birthDate = '';
this.businessEntityID = 0;
this.currentFlag = false;
this.gender = '';
this.hireDate = '';
this.jobTitle = '';
this.loginID = '';
this.maritalStatu = '';
this.modifiedDate = '';
this.nationalIDNumber = '';
this.organizationLevel = 0;
this.rowguid = '';
this.salariedFlag = false;
this.sickLeaveHour = 0;
this.vacationHour = 0;

		
				}
			}

			export class ApiEmployeeResponseModel {
				birthDate:string;
businessEntityID:number;
currentFlag:boolean;
gender:string;
hireDate:string;
jobTitle:string;
loginID:string;
maritalStatu:string;
modifiedDate:string;
nationalIDNumber:string;
organizationLevel:number;
rowguid:string;
salariedFlag:boolean;
sickLeaveHour:number;
vacationHour:number;

	
				constructor() {
					this.birthDate = '';
this.businessEntityID = 0;
this.currentFlag = false;
this.gender = '';
this.hireDate = '';
this.jobTitle = '';
this.loginID = '';
this.maritalStatu = '';
this.modifiedDate = '';
this.nationalIDNumber = '';
this.organizationLevel = 0;
this.rowguid = '';
this.salariedFlag = false;
this.sickLeaveHour = 0;
this.vacationHour = 0;

		
				}
			}
			export class ApiEmployeeDepartmentHistoryRequestModel {
				businessEntityID:number;
departmentID:number;
endDate:string;
modifiedDate:string;
shiftID:number;
startDate:string;

	
				constructor() {
					this.businessEntityID = 0;
this.departmentID = 0;
this.endDate = '';
this.modifiedDate = '';
this.shiftID = 0;
this.startDate = '';

		
				}
			}

			export class ApiEmployeeDepartmentHistoryResponseModel {
				businessEntityID:number;
departmentID:number;
endDate:string;
modifiedDate:string;
shiftID:number;
startDate:string;

	
				constructor() {
					this.businessEntityID = 0;
this.departmentID = 0;
this.endDate = '';
this.modifiedDate = '';
this.shiftID = 0;
this.startDate = '';

		
				}
			}
			export class ApiEmployeePayHistoryRequestModel {
				businessEntityID:number;
modifiedDate:string;
payFrequency:number;
rate:number;
rateChangeDate:string;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.payFrequency = 0;
this.rate = 0;
this.rateChangeDate = '';

		
				}
			}

			export class ApiEmployeePayHistoryResponseModel {
				businessEntityID:number;
modifiedDate:string;
payFrequency:number;
rate:number;
rateChangeDate:string;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.payFrequency = 0;
this.rate = 0;
this.rateChangeDate = '';

		
				}
			}
			export class ApiJobCandidateRequestModel {
				businessEntityID:number;
jobCandidateID:number;
modifiedDate:string;
resume:string;

	
				constructor() {
					this.businessEntityID = 0;
this.jobCandidateID = 0;
this.modifiedDate = '';
this.resume = '';

		
				}
			}

			export class ApiJobCandidateResponseModel {
				businessEntityID:number;
jobCandidateID:number;
modifiedDate:string;
resume:string;

	
				constructor() {
					this.businessEntityID = 0;
this.jobCandidateID = 0;
this.modifiedDate = '';
this.resume = '';

		
				}
			}
			export class ApiShiftRequestModel {
				endTime:string;
modifiedDate:string;
name:string;
shiftID:number;
startTime:string;

	
				constructor() {
					this.endTime = '';
this.modifiedDate = '';
this.name = '';
this.shiftID = 0;
this.startTime = '';

		
				}
			}

			export class ApiShiftResponseModel {
				endTime:string;
modifiedDate:string;
name:string;
shiftID:number;
startTime:string;

	
				constructor() {
					this.endTime = '';
this.modifiedDate = '';
this.name = '';
this.shiftID = 0;
this.startTime = '';

		
				}
			}
			export class ApiAddressRequestModel {
				addressID:number;
addressLine1:string;
addressLine2:string;
city:string;
modifiedDate:string;
postalCode:string;
rowguid:string;
stateProvinceID:number;

	
				constructor() {
					this.addressID = 0;
this.addressLine1 = '';
this.addressLine2 = '';
this.city = '';
this.modifiedDate = '';
this.postalCode = '';
this.rowguid = '';
this.stateProvinceID = 0;

		
				}
			}

			export class ApiAddressResponseModel {
				addressID:number;
addressLine1:string;
addressLine2:string;
city:string;
modifiedDate:string;
postalCode:string;
rowguid:string;
stateProvinceID:number;

	
				constructor() {
					this.addressID = 0;
this.addressLine1 = '';
this.addressLine2 = '';
this.city = '';
this.modifiedDate = '';
this.postalCode = '';
this.rowguid = '';
this.stateProvinceID = 0;

		
				}
			}
			export class ApiAddressTypeRequestModel {
				addressTypeID:number;
modifiedDate:string;
name:string;
rowguid:string;

	
				constructor() {
					this.addressTypeID = 0;
this.modifiedDate = '';
this.name = '';
this.rowguid = '';

		
				}
			}

			export class ApiAddressTypeResponseModel {
				addressTypeID:number;
modifiedDate:string;
name:string;
rowguid:string;

	
				constructor() {
					this.addressTypeID = 0;
this.modifiedDate = '';
this.name = '';
this.rowguid = '';

		
				}
			}
			export class ApiBusinessEntityRequestModel {
				businessEntityID:number;
modifiedDate:string;
rowguid:string;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.rowguid = '';

		
				}
			}

			export class ApiBusinessEntityResponseModel {
				businessEntityID:number;
modifiedDate:string;
rowguid:string;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.rowguid = '';

		
				}
			}
			export class ApiBusinessEntityAddressRequestModel {
				addressID:number;
addressTypeID:number;
businessEntityID:number;
modifiedDate:string;
rowguid:string;

	
				constructor() {
					this.addressID = 0;
this.addressTypeID = 0;
this.businessEntityID = 0;
this.modifiedDate = '';
this.rowguid = '';

		
				}
			}

			export class ApiBusinessEntityAddressResponseModel {
				addressID:number;
addressTypeID:number;
businessEntityID:number;
modifiedDate:string;
rowguid:string;

	
				constructor() {
					this.addressID = 0;
this.addressTypeID = 0;
this.businessEntityID = 0;
this.modifiedDate = '';
this.rowguid = '';

		
				}
			}
			export class ApiBusinessEntityContactRequestModel {
				businessEntityID:number;
contactTypeID:number;
modifiedDate:string;
personID:number;
rowguid:string;

	
				constructor() {
					this.businessEntityID = 0;
this.contactTypeID = 0;
this.modifiedDate = '';
this.personID = 0;
this.rowguid = '';

		
				}
			}

			export class ApiBusinessEntityContactResponseModel {
				businessEntityID:number;
contactTypeID:number;
modifiedDate:string;
personID:number;
rowguid:string;

	
				constructor() {
					this.businessEntityID = 0;
this.contactTypeID = 0;
this.modifiedDate = '';
this.personID = 0;
this.rowguid = '';

		
				}
			}
			export class ApiContactTypeRequestModel {
				contactTypeID:number;
modifiedDate:string;
name:string;

	
				constructor() {
					this.contactTypeID = 0;
this.modifiedDate = '';
this.name = '';

		
				}
			}

			export class ApiContactTypeResponseModel {
				contactTypeID:number;
modifiedDate:string;
name:string;

	
				constructor() {
					this.contactTypeID = 0;
this.modifiedDate = '';
this.name = '';

		
				}
			}
			export class ApiCountryRegionRequestModel {
				countryRegionCode:string;
modifiedDate:string;
name:string;

	
				constructor() {
					this.countryRegionCode = '';
this.modifiedDate = '';
this.name = '';

		
				}
			}

			export class ApiCountryRegionResponseModel {
				countryRegionCode:string;
modifiedDate:string;
name:string;

	
				constructor() {
					this.countryRegionCode = '';
this.modifiedDate = '';
this.name = '';

		
				}
			}
			export class ApiEmailAddressRequestModel {
				businessEntityID:number;
emailAddress1:string;
emailAddressID:number;
modifiedDate:string;
rowguid:string;

	
				constructor() {
					this.businessEntityID = 0;
this.emailAddress1 = '';
this.emailAddressID = 0;
this.modifiedDate = '';
this.rowguid = '';

		
				}
			}

			export class ApiEmailAddressResponseModel {
				businessEntityID:number;
emailAddress1:string;
emailAddressID:number;
modifiedDate:string;
rowguid:string;

	
				constructor() {
					this.businessEntityID = 0;
this.emailAddress1 = '';
this.emailAddressID = 0;
this.modifiedDate = '';
this.rowguid = '';

		
				}
			}
			export class ApiPasswordRequestModel {
				businessEntityID:number;
modifiedDate:string;
passwordHash:string;
passwordSalt:string;
rowguid:string;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.passwordHash = '';
this.passwordSalt = '';
this.rowguid = '';

		
				}
			}

			export class ApiPasswordResponseModel {
				businessEntityID:number;
modifiedDate:string;
passwordHash:string;
passwordSalt:string;
rowguid:string;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.passwordHash = '';
this.passwordSalt = '';
this.rowguid = '';

		
				}
			}
			export class ApiPersonRequestModel {
				additionalContactInfo:string;
businessEntityID:number;
demographic:string;
emailPromotion:number;
firstName:string;
lastName:string;
middleName:string;
modifiedDate:string;
nameStyle:boolean;
personType:string;
rowguid:string;
suffix:string;
title:string;

	
				constructor() {
					this.additionalContactInfo = '';
this.businessEntityID = 0;
this.demographic = '';
this.emailPromotion = 0;
this.firstName = '';
this.lastName = '';
this.middleName = '';
this.modifiedDate = '';
this.nameStyle = false;
this.personType = '';
this.rowguid = '';
this.suffix = '';
this.title = '';

		
				}
			}

			export class ApiPersonResponseModel {
				additionalContactInfo:string;
businessEntityID:number;
demographic:string;
emailPromotion:number;
firstName:string;
lastName:string;
middleName:string;
modifiedDate:string;
nameStyle:boolean;
personType:string;
rowguid:string;
suffix:string;
title:string;

	
				constructor() {
					this.additionalContactInfo = '';
this.businessEntityID = 0;
this.demographic = '';
this.emailPromotion = 0;
this.firstName = '';
this.lastName = '';
this.middleName = '';
this.modifiedDate = '';
this.nameStyle = false;
this.personType = '';
this.rowguid = '';
this.suffix = '';
this.title = '';

		
				}
			}
			export class ApiPersonPhoneRequestModel {
				businessEntityID:number;
modifiedDate:string;
phoneNumber:string;
phoneNumberTypeID:number;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.phoneNumber = '';
this.phoneNumberTypeID = 0;

		
				}
			}

			export class ApiPersonPhoneResponseModel {
				businessEntityID:number;
modifiedDate:string;
phoneNumber:string;
phoneNumberTypeID:number;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.phoneNumber = '';
this.phoneNumberTypeID = 0;

		
				}
			}
			export class ApiPhoneNumberTypeRequestModel {
				modifiedDate:string;
name:string;
phoneNumberTypeID:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.phoneNumberTypeID = 0;

		
				}
			}

			export class ApiPhoneNumberTypeResponseModel {
				modifiedDate:string;
name:string;
phoneNumberTypeID:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.phoneNumberTypeID = 0;

		
				}
			}
			export class ApiStateProvinceRequestModel {
				countryRegionCode:string;
isOnlyStateProvinceFlag:boolean;
modifiedDate:string;
name:string;
rowguid:string;
stateProvinceCode:string;
stateProvinceID:number;
territoryID:number;

	
				constructor() {
					this.countryRegionCode = '';
this.isOnlyStateProvinceFlag = false;
this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.stateProvinceCode = '';
this.stateProvinceID = 0;
this.territoryID = 0;

		
				}
			}

			export class ApiStateProvinceResponseModel {
				countryRegionCode:string;
isOnlyStateProvinceFlag:boolean;
modifiedDate:string;
name:string;
rowguid:string;
stateProvinceCode:string;
stateProvinceID:number;
territoryID:number;

	
				constructor() {
					this.countryRegionCode = '';
this.isOnlyStateProvinceFlag = false;
this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.stateProvinceCode = '';
this.stateProvinceID = 0;
this.territoryID = 0;

		
				}
			}
			export class ApiVStateProvinceCountryRegionRequestModel {
				countryRegionCode:string;
countryRegionName:string;
isOnlyStateProvinceFlag:boolean;
stateProvinceCode:string;
stateProvinceID:number;
stateProvinceName:string;
territoryID:number;

	
				constructor() {
					this.countryRegionCode = '';
this.countryRegionName = '';
this.isOnlyStateProvinceFlag = false;
this.stateProvinceCode = '';
this.stateProvinceID = 0;
this.stateProvinceName = '';
this.territoryID = 0;

		
				}
			}

			export class ApiVStateProvinceCountryRegionResponseModel {
				countryRegionCode:string;
countryRegionName:string;
isOnlyStateProvinceFlag:boolean;
stateProvinceCode:string;
stateProvinceID:number;
stateProvinceName:string;
territoryID:number;

	
				constructor() {
					this.countryRegionCode = '';
this.countryRegionName = '';
this.isOnlyStateProvinceFlag = false;
this.stateProvinceCode = '';
this.stateProvinceID = 0;
this.stateProvinceName = '';
this.territoryID = 0;

		
				}
			}
			export class ApiBillOfMaterialRequestModel {
				billOfMaterialsID:number;
bOMLevel:number;
componentID:number;
endDate:string;
modifiedDate:string;
perAssemblyQty:number;
productAssemblyID:number;
startDate:string;
unitMeasureCode:string;

	
				constructor() {
					this.billOfMaterialsID = 0;
this.bOMLevel = 0;
this.componentID = 0;
this.endDate = '';
this.modifiedDate = '';
this.perAssemblyQty = 0;
this.productAssemblyID = 0;
this.startDate = '';
this.unitMeasureCode = '';

		
				}
			}

			export class ApiBillOfMaterialResponseModel {
				billOfMaterialsID:number;
bOMLevel:number;
componentID:number;
endDate:string;
modifiedDate:string;
perAssemblyQty:number;
productAssemblyID:number;
startDate:string;
unitMeasureCode:string;

	
				constructor() {
					this.billOfMaterialsID = 0;
this.bOMLevel = 0;
this.componentID = 0;
this.endDate = '';
this.modifiedDate = '';
this.perAssemblyQty = 0;
this.productAssemblyID = 0;
this.startDate = '';
this.unitMeasureCode = '';

		
				}
			}
			export class ApiCultureRequestModel {
				cultureID:string;
modifiedDate:string;
name:string;

	
				constructor() {
					this.cultureID = '';
this.modifiedDate = '';
this.name = '';

		
				}
			}

			export class ApiCultureResponseModel {
				cultureID:string;
modifiedDate:string;
name:string;

	
				constructor() {
					this.cultureID = '';
this.modifiedDate = '';
this.name = '';

		
				}
			}
			export class ApiDocumentRequestModel {
				changeNumber:number;
document1:string;
documentLevel:number;
documentSummary:string;
fileExtension:string;
fileName:string;
folderFlag:boolean;
modifiedDate:string;
owner:number;
revision:string;
rowguid:string;
status:number;
title:string;

	
				constructor() {
					this.changeNumber = 0;
this.document1 = '';
this.documentLevel = 0;
this.documentSummary = '';
this.fileExtension = '';
this.fileName = '';
this.folderFlag = false;
this.modifiedDate = '';
this.owner = 0;
this.revision = '';
this.rowguid = '';
this.status = 0;
this.title = '';

		
				}
			}

			export class ApiDocumentResponseModel {
				changeNumber:number;
document1:string;
documentLevel:number;
documentSummary:string;
fileExtension:string;
fileName:string;
folderFlag:boolean;
modifiedDate:string;
owner:number;
revision:string;
rowguid:string;
status:number;
title:string;

	
				constructor() {
					this.changeNumber = 0;
this.document1 = '';
this.documentLevel = 0;
this.documentSummary = '';
this.fileExtension = '';
this.fileName = '';
this.folderFlag = false;
this.modifiedDate = '';
this.owner = 0;
this.revision = '';
this.rowguid = '';
this.status = 0;
this.title = '';

		
				}
			}
			export class ApiIllustrationRequestModel {
				diagram:string;
illustrationID:number;
modifiedDate:string;

	
				constructor() {
					this.diagram = '';
this.illustrationID = 0;
this.modifiedDate = '';

		
				}
			}

			export class ApiIllustrationResponseModel {
				diagram:string;
illustrationID:number;
modifiedDate:string;

	
				constructor() {
					this.diagram = '';
this.illustrationID = 0;
this.modifiedDate = '';

		
				}
			}
			export class ApiLocationRequestModel {
				availability:number;
costRate:number;
locationID:number;
modifiedDate:string;
name:string;

	
				constructor() {
					this.availability = 0;
this.costRate = 0;
this.locationID = 0;
this.modifiedDate = '';
this.name = '';

		
				}
			}

			export class ApiLocationResponseModel {
				availability:number;
costRate:number;
locationID:number;
modifiedDate:string;
name:string;

	
				constructor() {
					this.availability = 0;
this.costRate = 0;
this.locationID = 0;
this.modifiedDate = '';
this.name = '';

		
				}
			}
			export class ApiProductRequestModel {
				class:string;
color:string;
daysToManufacture:number;
discontinuedDate:string;
finishedGoodsFlag:boolean;
listPrice:number;
makeFlag:boolean;
modifiedDate:string;
name:string;
productID:number;
productLine:string;
productModelID:number;
productNumber:string;
productSubcategoryID:number;
reorderPoint:number;
rowguid:string;
safetyStockLevel:number;
sellEndDate:string;
sellStartDate:string;
size:string;
sizeUnitMeasureCode:string;
standardCost:number;
style:string;
weight:number;
weightUnitMeasureCode:string;

	
				constructor() {
					this.class = '';
this.color = '';
this.daysToManufacture = 0;
this.discontinuedDate = '';
this.finishedGoodsFlag = false;
this.listPrice = 0;
this.makeFlag = false;
this.modifiedDate = '';
this.name = '';
this.productID = 0;
this.productLine = '';
this.productModelID = 0;
this.productNumber = '';
this.productSubcategoryID = 0;
this.reorderPoint = 0;
this.rowguid = '';
this.safetyStockLevel = 0;
this.sellEndDate = '';
this.sellStartDate = '';
this.size = '';
this.sizeUnitMeasureCode = '';
this.standardCost = 0;
this.style = '';
this.weight = 0;
this.weightUnitMeasureCode = '';

		
				}
			}

			export class ApiProductResponseModel {
				class:string;
color:string;
daysToManufacture:number;
discontinuedDate:string;
finishedGoodsFlag:boolean;
listPrice:number;
makeFlag:boolean;
modifiedDate:string;
name:string;
productID:number;
productLine:string;
productModelID:number;
productNumber:string;
productSubcategoryID:number;
reorderPoint:number;
rowguid:string;
safetyStockLevel:number;
sellEndDate:string;
sellStartDate:string;
size:string;
sizeUnitMeasureCode:string;
standardCost:number;
style:string;
weight:number;
weightUnitMeasureCode:string;

	
				constructor() {
					this.class = '';
this.color = '';
this.daysToManufacture = 0;
this.discontinuedDate = '';
this.finishedGoodsFlag = false;
this.listPrice = 0;
this.makeFlag = false;
this.modifiedDate = '';
this.name = '';
this.productID = 0;
this.productLine = '';
this.productModelID = 0;
this.productNumber = '';
this.productSubcategoryID = 0;
this.reorderPoint = 0;
this.rowguid = '';
this.safetyStockLevel = 0;
this.sellEndDate = '';
this.sellStartDate = '';
this.size = '';
this.sizeUnitMeasureCode = '';
this.standardCost = 0;
this.style = '';
this.weight = 0;
this.weightUnitMeasureCode = '';

		
				}
			}
			export class ApiProductCategoryRequestModel {
				modifiedDate:string;
name:string;
productCategoryID:number;
rowguid:string;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.productCategoryID = 0;
this.rowguid = '';

		
				}
			}

			export class ApiProductCategoryResponseModel {
				modifiedDate:string;
name:string;
productCategoryID:number;
rowguid:string;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.productCategoryID = 0;
this.rowguid = '';

		
				}
			}
			export class ApiProductCostHistoryRequestModel {
				endDate:string;
modifiedDate:string;
productID:number;
standardCost:number;
startDate:string;

	
				constructor() {
					this.endDate = '';
this.modifiedDate = '';
this.productID = 0;
this.standardCost = 0;
this.startDate = '';

		
				}
			}

			export class ApiProductCostHistoryResponseModel {
				endDate:string;
modifiedDate:string;
productID:number;
standardCost:number;
startDate:string;

	
				constructor() {
					this.endDate = '';
this.modifiedDate = '';
this.productID = 0;
this.standardCost = 0;
this.startDate = '';

		
				}
			}
			export class ApiProductDescriptionRequestModel {
				description:string;
modifiedDate:string;
productDescriptionID:number;
rowguid:string;

	
				constructor() {
					this.description = '';
this.modifiedDate = '';
this.productDescriptionID = 0;
this.rowguid = '';

		
				}
			}

			export class ApiProductDescriptionResponseModel {
				description:string;
modifiedDate:string;
productDescriptionID:number;
rowguid:string;

	
				constructor() {
					this.description = '';
this.modifiedDate = '';
this.productDescriptionID = 0;
this.rowguid = '';

		
				}
			}
			export class ApiProductInventoryRequestModel {
				bin:number;
locationID:number;
modifiedDate:string;
productID:number;
quantity:number;
rowguid:string;
shelf:string;

	
				constructor() {
					this.bin = 0;
this.locationID = 0;
this.modifiedDate = '';
this.productID = 0;
this.quantity = 0;
this.rowguid = '';
this.shelf = '';

		
				}
			}

			export class ApiProductInventoryResponseModel {
				bin:number;
locationID:number;
modifiedDate:string;
productID:number;
quantity:number;
rowguid:string;
shelf:string;

	
				constructor() {
					this.bin = 0;
this.locationID = 0;
this.modifiedDate = '';
this.productID = 0;
this.quantity = 0;
this.rowguid = '';
this.shelf = '';

		
				}
			}
			export class ApiProductListPriceHistoryRequestModel {
				endDate:string;
listPrice:number;
modifiedDate:string;
productID:number;
startDate:string;

	
				constructor() {
					this.endDate = '';
this.listPrice = 0;
this.modifiedDate = '';
this.productID = 0;
this.startDate = '';

		
				}
			}

			export class ApiProductListPriceHistoryResponseModel {
				endDate:string;
listPrice:number;
modifiedDate:string;
productID:number;
startDate:string;

	
				constructor() {
					this.endDate = '';
this.listPrice = 0;
this.modifiedDate = '';
this.productID = 0;
this.startDate = '';

		
				}
			}
			export class ApiProductModelRequestModel {
				catalogDescription:string;
instruction:string;
modifiedDate:string;
name:string;
productModelID:number;
rowguid:string;

	
				constructor() {
					this.catalogDescription = '';
this.instruction = '';
this.modifiedDate = '';
this.name = '';
this.productModelID = 0;
this.rowguid = '';

		
				}
			}

			export class ApiProductModelResponseModel {
				catalogDescription:string;
instruction:string;
modifiedDate:string;
name:string;
productModelID:number;
rowguid:string;

	
				constructor() {
					this.catalogDescription = '';
this.instruction = '';
this.modifiedDate = '';
this.name = '';
this.productModelID = 0;
this.rowguid = '';

		
				}
			}
			export class ApiProductModelProductDescriptionCultureRequestModel {
				cultureID:string;
modifiedDate:string;
productDescriptionID:number;
productModelID:number;

	
				constructor() {
					this.cultureID = '';
this.modifiedDate = '';
this.productDescriptionID = 0;
this.productModelID = 0;

		
				}
			}

			export class ApiProductModelProductDescriptionCultureResponseModel {
				cultureID:string;
modifiedDate:string;
productDescriptionID:number;
productModelID:number;

	
				constructor() {
					this.cultureID = '';
this.modifiedDate = '';
this.productDescriptionID = 0;
this.productModelID = 0;

		
				}
			}
			export class ApiProductPhotoRequestModel {
				largePhoto:string;
largePhotoFileName:string;
modifiedDate:string;
productPhotoID:number;
thumbNailPhoto:string;
thumbnailPhotoFileName:string;

	
				constructor() {
					this.largePhoto = '';
this.largePhotoFileName = '';
this.modifiedDate = '';
this.productPhotoID = 0;
this.thumbNailPhoto = '';
this.thumbnailPhotoFileName = '';

		
				}
			}

			export class ApiProductPhotoResponseModel {
				largePhoto:string;
largePhotoFileName:string;
modifiedDate:string;
productPhotoID:number;
thumbNailPhoto:string;
thumbnailPhotoFileName:string;

	
				constructor() {
					this.largePhoto = '';
this.largePhotoFileName = '';
this.modifiedDate = '';
this.productPhotoID = 0;
this.thumbNailPhoto = '';
this.thumbnailPhotoFileName = '';

		
				}
			}
			export class ApiProductProductPhotoRequestModel {
				modifiedDate:string;
primary:boolean;
productID:number;
productPhotoID:number;

	
				constructor() {
					this.modifiedDate = '';
this.primary = false;
this.productID = 0;
this.productPhotoID = 0;

		
				}
			}

			export class ApiProductProductPhotoResponseModel {
				modifiedDate:string;
primary:boolean;
productID:number;
productPhotoID:number;

	
				constructor() {
					this.modifiedDate = '';
this.primary = false;
this.productID = 0;
this.productPhotoID = 0;

		
				}
			}
			export class ApiProductReviewRequestModel {
				comment:string;
emailAddress:string;
modifiedDate:string;
productID:number;
productReviewID:number;
rating:number;
reviewDate:string;
reviewerName:string;

	
				constructor() {
					this.comment = '';
this.emailAddress = '';
this.modifiedDate = '';
this.productID = 0;
this.productReviewID = 0;
this.rating = 0;
this.reviewDate = '';
this.reviewerName = '';

		
				}
			}

			export class ApiProductReviewResponseModel {
				comment:string;
emailAddress:string;
modifiedDate:string;
productID:number;
productReviewID:number;
rating:number;
reviewDate:string;
reviewerName:string;

	
				constructor() {
					this.comment = '';
this.emailAddress = '';
this.modifiedDate = '';
this.productID = 0;
this.productReviewID = 0;
this.rating = 0;
this.reviewDate = '';
this.reviewerName = '';

		
				}
			}
			export class ApiProductSubcategoryRequestModel {
				modifiedDate:string;
name:string;
productCategoryID:number;
productSubcategoryID:number;
rowguid:string;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.productCategoryID = 0;
this.productSubcategoryID = 0;
this.rowguid = '';

		
				}
			}

			export class ApiProductSubcategoryResponseModel {
				modifiedDate:string;
name:string;
productCategoryID:number;
productSubcategoryID:number;
rowguid:string;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.productCategoryID = 0;
this.productSubcategoryID = 0;
this.rowguid = '';

		
				}
			}
			export class ApiScrapReasonRequestModel {
				modifiedDate:string;
name:string;
scrapReasonID:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.scrapReasonID = 0;

		
				}
			}

			export class ApiScrapReasonResponseModel {
				modifiedDate:string;
name:string;
scrapReasonID:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.scrapReasonID = 0;

		
				}
			}
			export class ApiTransactionHistoryRequestModel {
				actualCost:number;
modifiedDate:string;
productID:number;
quantity:number;
referenceOrderID:number;
referenceOrderLineID:number;
transactionDate:string;
transactionID:number;
transactionType:string;

	
				constructor() {
					this.actualCost = 0;
this.modifiedDate = '';
this.productID = 0;
this.quantity = 0;
this.referenceOrderID = 0;
this.referenceOrderLineID = 0;
this.transactionDate = '';
this.transactionID = 0;
this.transactionType = '';

		
				}
			}

			export class ApiTransactionHistoryResponseModel {
				actualCost:number;
modifiedDate:string;
productID:number;
quantity:number;
referenceOrderID:number;
referenceOrderLineID:number;
transactionDate:string;
transactionID:number;
transactionType:string;

	
				constructor() {
					this.actualCost = 0;
this.modifiedDate = '';
this.productID = 0;
this.quantity = 0;
this.referenceOrderID = 0;
this.referenceOrderLineID = 0;
this.transactionDate = '';
this.transactionID = 0;
this.transactionType = '';

		
				}
			}
			export class ApiTransactionHistoryArchiveRequestModel {
				actualCost:number;
modifiedDate:string;
productID:number;
quantity:number;
referenceOrderID:number;
referenceOrderLineID:number;
transactionDate:string;
transactionID:number;
transactionType:string;

	
				constructor() {
					this.actualCost = 0;
this.modifiedDate = '';
this.productID = 0;
this.quantity = 0;
this.referenceOrderID = 0;
this.referenceOrderLineID = 0;
this.transactionDate = '';
this.transactionID = 0;
this.transactionType = '';

		
				}
			}

			export class ApiTransactionHistoryArchiveResponseModel {
				actualCost:number;
modifiedDate:string;
productID:number;
quantity:number;
referenceOrderID:number;
referenceOrderLineID:number;
transactionDate:string;
transactionID:number;
transactionType:string;

	
				constructor() {
					this.actualCost = 0;
this.modifiedDate = '';
this.productID = 0;
this.quantity = 0;
this.referenceOrderID = 0;
this.referenceOrderLineID = 0;
this.transactionDate = '';
this.transactionID = 0;
this.transactionType = '';

		
				}
			}
			export class ApiUnitMeasureRequestModel {
				modifiedDate:string;
name:string;
unitMeasureCode:string;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.unitMeasureCode = '';

		
				}
			}

			export class ApiUnitMeasureResponseModel {
				modifiedDate:string;
name:string;
unitMeasureCode:string;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.unitMeasureCode = '';

		
				}
			}
			export class ApiVProductAndDescriptionRequestModel {
				cultureID:string;
description:string;
name:string;
productID:number;
productModel:string;

	
				constructor() {
					this.cultureID = '';
this.description = '';
this.name = '';
this.productID = 0;
this.productModel = '';

		
				}
			}

			export class ApiVProductAndDescriptionResponseModel {
				cultureID:string;
description:string;
name:string;
productID:number;
productModel:string;

	
				constructor() {
					this.cultureID = '';
this.description = '';
this.name = '';
this.productID = 0;
this.productModel = '';

		
				}
			}
			export class ApiWorkOrderRequestModel {
				dueDate:string;
endDate:string;
modifiedDate:string;
orderQty:number;
productID:number;
scrappedQty:number;
scrapReasonID:number;
startDate:string;
stockedQty:number;
workOrderID:number;

	
				constructor() {
					this.dueDate = '';
this.endDate = '';
this.modifiedDate = '';
this.orderQty = 0;
this.productID = 0;
this.scrappedQty = 0;
this.scrapReasonID = 0;
this.startDate = '';
this.stockedQty = 0;
this.workOrderID = 0;

		
				}
			}

			export class ApiWorkOrderResponseModel {
				dueDate:string;
endDate:string;
modifiedDate:string;
orderQty:number;
productID:number;
scrappedQty:number;
scrapReasonID:number;
startDate:string;
stockedQty:number;
workOrderID:number;

	
				constructor() {
					this.dueDate = '';
this.endDate = '';
this.modifiedDate = '';
this.orderQty = 0;
this.productID = 0;
this.scrappedQty = 0;
this.scrapReasonID = 0;
this.startDate = '';
this.stockedQty = 0;
this.workOrderID = 0;

		
				}
			}
			export class ApiWorkOrderRoutingRequestModel {
				actualCost:number;
actualEndDate:string;
actualResourceHr:number;
actualStartDate:string;
locationID:number;
modifiedDate:string;
operationSequence:number;
plannedCost:number;
productID:number;
scheduledEndDate:string;
scheduledStartDate:string;
workOrderID:number;

	
				constructor() {
					this.actualCost = 0;
this.actualEndDate = '';
this.actualResourceHr = 0;
this.actualStartDate = '';
this.locationID = 0;
this.modifiedDate = '';
this.operationSequence = 0;
this.plannedCost = 0;
this.productID = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.workOrderID = 0;

		
				}
			}

			export class ApiWorkOrderRoutingResponseModel {
				actualCost:number;
actualEndDate:string;
actualResourceHr:number;
actualStartDate:string;
locationID:number;
modifiedDate:string;
operationSequence:number;
plannedCost:number;
productID:number;
scheduledEndDate:string;
scheduledStartDate:string;
workOrderID:number;

	
				constructor() {
					this.actualCost = 0;
this.actualEndDate = '';
this.actualResourceHr = 0;
this.actualStartDate = '';
this.locationID = 0;
this.modifiedDate = '';
this.operationSequence = 0;
this.plannedCost = 0;
this.productID = 0;
this.scheduledEndDate = '';
this.scheduledStartDate = '';
this.workOrderID = 0;

		
				}
			}
			export class ApiProductVendorRequestModel {
				averageLeadTime:number;
businessEntityID:number;
lastReceiptCost:number;
lastReceiptDate:string;
maxOrderQty:number;
minOrderQty:number;
modifiedDate:string;
onOrderQty:number;
productID:number;
standardPrice:number;
unitMeasureCode:string;

	
				constructor() {
					this.averageLeadTime = 0;
this.businessEntityID = 0;
this.lastReceiptCost = 0;
this.lastReceiptDate = '';
this.maxOrderQty = 0;
this.minOrderQty = 0;
this.modifiedDate = '';
this.onOrderQty = 0;
this.productID = 0;
this.standardPrice = 0;
this.unitMeasureCode = '';

		
				}
			}

			export class ApiProductVendorResponseModel {
				averageLeadTime:number;
businessEntityID:number;
lastReceiptCost:number;
lastReceiptDate:string;
maxOrderQty:number;
minOrderQty:number;
modifiedDate:string;
onOrderQty:number;
productID:number;
standardPrice:number;
unitMeasureCode:string;

	
				constructor() {
					this.averageLeadTime = 0;
this.businessEntityID = 0;
this.lastReceiptCost = 0;
this.lastReceiptDate = '';
this.maxOrderQty = 0;
this.minOrderQty = 0;
this.modifiedDate = '';
this.onOrderQty = 0;
this.productID = 0;
this.standardPrice = 0;
this.unitMeasureCode = '';

		
				}
			}
			export class ApiPurchaseOrderDetailRequestModel {
				dueDate:string;
lineTotal:number;
modifiedDate:string;
orderQty:number;
productID:number;
purchaseOrderDetailID:number;
purchaseOrderID:number;
receivedQty:number;
rejectedQty:number;
stockedQty:number;
unitPrice:number;

	
				constructor() {
					this.dueDate = '';
this.lineTotal = 0;
this.modifiedDate = '';
this.orderQty = 0;
this.productID = 0;
this.purchaseOrderDetailID = 0;
this.purchaseOrderID = 0;
this.receivedQty = 0;
this.rejectedQty = 0;
this.stockedQty = 0;
this.unitPrice = 0;

		
				}
			}

			export class ApiPurchaseOrderDetailResponseModel {
				dueDate:string;
lineTotal:number;
modifiedDate:string;
orderQty:number;
productID:number;
purchaseOrderDetailID:number;
purchaseOrderID:number;
receivedQty:number;
rejectedQty:number;
stockedQty:number;
unitPrice:number;

	
				constructor() {
					this.dueDate = '';
this.lineTotal = 0;
this.modifiedDate = '';
this.orderQty = 0;
this.productID = 0;
this.purchaseOrderDetailID = 0;
this.purchaseOrderID = 0;
this.receivedQty = 0;
this.rejectedQty = 0;
this.stockedQty = 0;
this.unitPrice = 0;

		
				}
			}
			export class ApiPurchaseOrderHeaderRequestModel {
				employeeID:number;
freight:number;
modifiedDate:string;
orderDate:string;
purchaseOrderID:number;
revisionNumber:number;
shipDate:string;
shipMethodID:number;
status:number;
subTotal:number;
taxAmt:number;
totalDue:number;
vendorID:number;

	
				constructor() {
					this.employeeID = 0;
this.freight = 0;
this.modifiedDate = '';
this.orderDate = '';
this.purchaseOrderID = 0;
this.revisionNumber = 0;
this.shipDate = '';
this.shipMethodID = 0;
this.status = 0;
this.subTotal = 0;
this.taxAmt = 0;
this.totalDue = 0;
this.vendorID = 0;

		
				}
			}

			export class ApiPurchaseOrderHeaderResponseModel {
				employeeID:number;
freight:number;
modifiedDate:string;
orderDate:string;
purchaseOrderID:number;
revisionNumber:number;
shipDate:string;
shipMethodID:number;
status:number;
subTotal:number;
taxAmt:number;
totalDue:number;
vendorID:number;

	
				constructor() {
					this.employeeID = 0;
this.freight = 0;
this.modifiedDate = '';
this.orderDate = '';
this.purchaseOrderID = 0;
this.revisionNumber = 0;
this.shipDate = '';
this.shipMethodID = 0;
this.status = 0;
this.subTotal = 0;
this.taxAmt = 0;
this.totalDue = 0;
this.vendorID = 0;

		
				}
			}
			export class ApiShipMethodRequestModel {
				modifiedDate:string;
name:string;
rowguid:string;
shipBase:number;
shipMethodID:number;
shipRate:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.shipBase = 0;
this.shipMethodID = 0;
this.shipRate = 0;

		
				}
			}

			export class ApiShipMethodResponseModel {
				modifiedDate:string;
name:string;
rowguid:string;
shipBase:number;
shipMethodID:number;
shipRate:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.shipBase = 0;
this.shipMethodID = 0;
this.shipRate = 0;

		
				}
			}
			export class ApiVendorRequestModel {
				accountNumber:string;
activeFlag:boolean;
businessEntityID:number;
creditRating:number;
modifiedDate:string;
name:string;
preferredVendorStatu:boolean;
purchasingWebServiceURL:string;

	
				constructor() {
					this.accountNumber = '';
this.activeFlag = false;
this.businessEntityID = 0;
this.creditRating = 0;
this.modifiedDate = '';
this.name = '';
this.preferredVendorStatu = false;
this.purchasingWebServiceURL = '';

		
				}
			}

			export class ApiVendorResponseModel {
				accountNumber:string;
activeFlag:boolean;
businessEntityID:number;
creditRating:number;
modifiedDate:string;
name:string;
preferredVendorStatu:boolean;
purchasingWebServiceURL:string;

	
				constructor() {
					this.accountNumber = '';
this.activeFlag = false;
this.businessEntityID = 0;
this.creditRating = 0;
this.modifiedDate = '';
this.name = '';
this.preferredVendorStatu = false;
this.purchasingWebServiceURL = '';

		
				}
			}
			export class ApiCreditCardRequestModel {
				cardNumber:string;
cardType:string;
creditCardID:number;
expMonth:number;
expYear:number;
modifiedDate:string;

	
				constructor() {
					this.cardNumber = '';
this.cardType = '';
this.creditCardID = 0;
this.expMonth = 0;
this.expYear = 0;
this.modifiedDate = '';

		
				}
			}

			export class ApiCreditCardResponseModel {
				cardNumber:string;
cardType:string;
creditCardID:number;
expMonth:number;
expYear:number;
modifiedDate:string;

	
				constructor() {
					this.cardNumber = '';
this.cardType = '';
this.creditCardID = 0;
this.expMonth = 0;
this.expYear = 0;
this.modifiedDate = '';

		
				}
			}
			export class ApiCurrencyRequestModel {
				currencyCode:string;
modifiedDate:string;
name:string;

	
				constructor() {
					this.currencyCode = '';
this.modifiedDate = '';
this.name = '';

		
				}
			}

			export class ApiCurrencyResponseModel {
				currencyCode:string;
modifiedDate:string;
name:string;

	
				constructor() {
					this.currencyCode = '';
this.modifiedDate = '';
this.name = '';

		
				}
			}
			export class ApiCurrencyRateRequestModel {
				averageRate:number;
currencyRateDate:string;
currencyRateID:number;
endOfDayRate:number;
fromCurrencyCode:string;
fromCurrencyCodeEntity:string;
modifiedDate:string;
toCurrencyCode:string;
toCurrencyCodeEntity:string;

	
				constructor() {
					this.averageRate = 0;
this.currencyRateDate = '';
this.currencyRateID = 0;
this.endOfDayRate = 0;
this.fromCurrencyCode = '';
this.modifiedDate = '';
this.toCurrencyCode = '';

		
				}
			}

			export class ApiCurrencyRateResponseModel {
				averageRate:number;
currencyRateDate:string;
currencyRateID:number;
endOfDayRate:number;
fromCurrencyCode:string;
fromCurrencyCodeEntity:string;
modifiedDate:string;
toCurrencyCode:string;
toCurrencyCodeEntity:string;

	
				constructor() {
					this.averageRate = 0;
this.currencyRateDate = '';
this.currencyRateID = 0;
this.endOfDayRate = 0;
this.fromCurrencyCode = '';
this.modifiedDate = '';
this.toCurrencyCode = '';

		
				}
			}
			export class ApiCustomerRequestModel {
				accountNumber:string;
customerID:number;
modifiedDate:string;
personID:number;
rowguid:string;
storeID:number;
storeIDEntity:number;
territoryID:number;
territoryIDEntity:number;

	
				constructor() {
					this.accountNumber = '';
this.customerID = 0;
this.modifiedDate = '';
this.personID = 0;
this.rowguid = '';
this.storeID = 0;
this.territoryID = 0;

		
				}
			}

			export class ApiCustomerResponseModel {
				accountNumber:string;
customerID:number;
modifiedDate:string;
personID:number;
rowguid:string;
storeID:number;
storeIDEntity:number;
territoryID:number;
territoryIDEntity:number;

	
				constructor() {
					this.accountNumber = '';
this.customerID = 0;
this.modifiedDate = '';
this.personID = 0;
this.rowguid = '';
this.storeID = 0;
this.territoryID = 0;

		
				}
			}
			export class ApiSalesOrderDetailRequestModel {
				carrierTrackingNumber:string;
lineTotal:number;
modifiedDate:string;
orderQty:number;
productID:number;
productIDEntity:number;
rowguid:string;
salesOrderDetailID:number;
salesOrderID:number;
salesOrderIDEntity:number;
specialOfferID:number;
specialOfferIDEntity:number;
unitPrice:number;
unitPriceDiscount:number;

	
				constructor() {
					this.carrierTrackingNumber = '';
this.lineTotal = 0;
this.modifiedDate = '';
this.orderQty = 0;
this.productID = 0;
this.rowguid = '';
this.salesOrderDetailID = 0;
this.salesOrderID = 0;
this.specialOfferID = 0;
this.unitPrice = 0;
this.unitPriceDiscount = 0;

		
				}
			}

			export class ApiSalesOrderDetailResponseModel {
				carrierTrackingNumber:string;
lineTotal:number;
modifiedDate:string;
orderQty:number;
productID:number;
productIDEntity:number;
rowguid:string;
salesOrderDetailID:number;
salesOrderID:number;
salesOrderIDEntity:number;
specialOfferID:number;
specialOfferIDEntity:number;
unitPrice:number;
unitPriceDiscount:number;

	
				constructor() {
					this.carrierTrackingNumber = '';
this.lineTotal = 0;
this.modifiedDate = '';
this.orderQty = 0;
this.productID = 0;
this.rowguid = '';
this.salesOrderDetailID = 0;
this.salesOrderID = 0;
this.specialOfferID = 0;
this.unitPrice = 0;
this.unitPriceDiscount = 0;

		
				}
			}
			export class ApiSalesOrderHeaderRequestModel {
				accountNumber:string;
billToAddressID:number;
comment:string;
creditCardApprovalCode:string;
creditCardID:number;
creditCardIDEntity:number;
currencyRateID:number;
currencyRateIDEntity:number;
customerID:number;
customerIDEntity:number;
dueDate:string;
freight:number;
modifiedDate:string;
onlineOrderFlag:boolean;
orderDate:string;
purchaseOrderNumber:string;
revisionNumber:number;
rowguid:string;
salesOrderID:number;
salesOrderNumber:string;
salesPersonID:number;
salesPersonIDEntity:number;
shipDate:string;
shipMethodID:number;
shipToAddressID:number;
status:number;
subTotal:number;
taxAmt:number;
territoryID:number;
territoryIDEntity:number;
totalDue:number;

	
				constructor() {
					this.accountNumber = '';
this.billToAddressID = 0;
this.comment = '';
this.creditCardApprovalCode = '';
this.creditCardID = 0;
this.currencyRateID = 0;
this.customerID = 0;
this.dueDate = '';
this.freight = 0;
this.modifiedDate = '';
this.onlineOrderFlag = false;
this.orderDate = '';
this.purchaseOrderNumber = '';
this.revisionNumber = 0;
this.rowguid = '';
this.salesOrderID = 0;
this.salesOrderNumber = '';
this.salesPersonID = 0;
this.shipDate = '';
this.shipMethodID = 0;
this.shipToAddressID = 0;
this.status = 0;
this.subTotal = 0;
this.taxAmt = 0;
this.territoryID = 0;
this.totalDue = 0;

		
				}
			}

			export class ApiSalesOrderHeaderResponseModel {
				accountNumber:string;
billToAddressID:number;
comment:string;
creditCardApprovalCode:string;
creditCardID:number;
creditCardIDEntity:number;
currencyRateID:number;
currencyRateIDEntity:number;
customerID:number;
customerIDEntity:number;
dueDate:string;
freight:number;
modifiedDate:string;
onlineOrderFlag:boolean;
orderDate:string;
purchaseOrderNumber:string;
revisionNumber:number;
rowguid:string;
salesOrderID:number;
salesOrderNumber:string;
salesPersonID:number;
salesPersonIDEntity:number;
shipDate:string;
shipMethodID:number;
shipToAddressID:number;
status:number;
subTotal:number;
taxAmt:number;
territoryID:number;
territoryIDEntity:number;
totalDue:number;

	
				constructor() {
					this.accountNumber = '';
this.billToAddressID = 0;
this.comment = '';
this.creditCardApprovalCode = '';
this.creditCardID = 0;
this.currencyRateID = 0;
this.customerID = 0;
this.dueDate = '';
this.freight = 0;
this.modifiedDate = '';
this.onlineOrderFlag = false;
this.orderDate = '';
this.purchaseOrderNumber = '';
this.revisionNumber = 0;
this.rowguid = '';
this.salesOrderID = 0;
this.salesOrderNumber = '';
this.salesPersonID = 0;
this.shipDate = '';
this.shipMethodID = 0;
this.shipToAddressID = 0;
this.status = 0;
this.subTotal = 0;
this.taxAmt = 0;
this.territoryID = 0;
this.totalDue = 0;

		
				}
			}
			export class ApiSalesPersonRequestModel {
				bonus:number;
businessEntityID:number;
commissionPct:number;
modifiedDate:string;
rowguid:string;
salesLastYear:number;
salesQuota:number;
salesYTD:number;
territoryID:number;
territoryIDEntity:number;

	
				constructor() {
					this.bonus = 0;
this.businessEntityID = 0;
this.commissionPct = 0;
this.modifiedDate = '';
this.rowguid = '';
this.salesLastYear = 0;
this.salesQuota = 0;
this.salesYTD = 0;
this.territoryID = 0;

		
				}
			}

			export class ApiSalesPersonResponseModel {
				bonus:number;
businessEntityID:number;
commissionPct:number;
modifiedDate:string;
rowguid:string;
salesLastYear:number;
salesQuota:number;
salesYTD:number;
territoryID:number;
territoryIDEntity:number;

	
				constructor() {
					this.bonus = 0;
this.businessEntityID = 0;
this.commissionPct = 0;
this.modifiedDate = '';
this.rowguid = '';
this.salesLastYear = 0;
this.salesQuota = 0;
this.salesYTD = 0;
this.territoryID = 0;

		
				}
			}
			export class ApiSalesPersonQuotaHistoryRequestModel {
				businessEntityID:number;
businessEntityIDEntity:number;
modifiedDate:string;
quotaDate:string;
rowguid:string;
salesQuota:number;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.quotaDate = '';
this.rowguid = '';
this.salesQuota = 0;

		
				}
			}

			export class ApiSalesPersonQuotaHistoryResponseModel {
				businessEntityID:number;
businessEntityIDEntity:number;
modifiedDate:string;
quotaDate:string;
rowguid:string;
salesQuota:number;

	
				constructor() {
					this.businessEntityID = 0;
this.modifiedDate = '';
this.quotaDate = '';
this.rowguid = '';
this.salesQuota = 0;

		
				}
			}
			export class ApiSalesReasonRequestModel {
				modifiedDate:string;
name:string;
reasonType:string;
salesReasonID:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.reasonType = '';
this.salesReasonID = 0;

		
				}
			}

			export class ApiSalesReasonResponseModel {
				modifiedDate:string;
name:string;
reasonType:string;
salesReasonID:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.reasonType = '';
this.salesReasonID = 0;

		
				}
			}
			export class ApiSalesTaxRateRequestModel {
				modifiedDate:string;
name:string;
rowguid:string;
salesTaxRateID:number;
stateProvinceID:number;
taxRate:number;
taxType:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.salesTaxRateID = 0;
this.stateProvinceID = 0;
this.taxRate = 0;
this.taxType = 0;

		
				}
			}

			export class ApiSalesTaxRateResponseModel {
				modifiedDate:string;
name:string;
rowguid:string;
salesTaxRateID:number;
stateProvinceID:number;
taxRate:number;
taxType:number;

	
				constructor() {
					this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.salesTaxRateID = 0;
this.stateProvinceID = 0;
this.taxRate = 0;
this.taxType = 0;

		
				}
			}
			export class ApiSalesTerritoryRequestModel {
				costLastYear:number;
costYTD:number;
countryRegionCode:string;
group:string;
modifiedDate:string;
name:string;
rowguid:string;
salesLastYear:number;
salesYTD:number;
territoryID:number;

	
				constructor() {
					this.costLastYear = 0;
this.costYTD = 0;
this.countryRegionCode = '';
this.group = '';
this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.salesLastYear = 0;
this.salesYTD = 0;
this.territoryID = 0;

		
				}
			}

			export class ApiSalesTerritoryResponseModel {
				costLastYear:number;
costYTD:number;
countryRegionCode:string;
group:string;
modifiedDate:string;
name:string;
rowguid:string;
salesLastYear:number;
salesYTD:number;
territoryID:number;

	
				constructor() {
					this.costLastYear = 0;
this.costYTD = 0;
this.countryRegionCode = '';
this.group = '';
this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.salesLastYear = 0;
this.salesYTD = 0;
this.territoryID = 0;

		
				}
			}
			export class ApiSalesTerritoryHistoryRequestModel {
				businessEntityID:number;
businessEntityIDEntity:number;
endDate:string;
modifiedDate:string;
rowguid:string;
startDate:string;
territoryID:number;
territoryIDEntity:number;

	
				constructor() {
					this.businessEntityID = 0;
this.endDate = '';
this.modifiedDate = '';
this.rowguid = '';
this.startDate = '';
this.territoryID = 0;

		
				}
			}

			export class ApiSalesTerritoryHistoryResponseModel {
				businessEntityID:number;
businessEntityIDEntity:number;
endDate:string;
modifiedDate:string;
rowguid:string;
startDate:string;
territoryID:number;
territoryIDEntity:number;

	
				constructor() {
					this.businessEntityID = 0;
this.endDate = '';
this.modifiedDate = '';
this.rowguid = '';
this.startDate = '';
this.territoryID = 0;

		
				}
			}
			export class ApiShoppingCartItemRequestModel {
				dateCreated:string;
modifiedDate:string;
productID:number;
quantity:number;
shoppingCartID:string;
shoppingCartItemID:number;

	
				constructor() {
					this.dateCreated = '';
this.modifiedDate = '';
this.productID = 0;
this.quantity = 0;
this.shoppingCartID = '';
this.shoppingCartItemID = 0;

		
				}
			}

			export class ApiShoppingCartItemResponseModel {
				dateCreated:string;
modifiedDate:string;
productID:number;
quantity:number;
shoppingCartID:string;
shoppingCartItemID:number;

	
				constructor() {
					this.dateCreated = '';
this.modifiedDate = '';
this.productID = 0;
this.quantity = 0;
this.shoppingCartID = '';
this.shoppingCartItemID = 0;

		
				}
			}
			export class ApiSpecialOfferRequestModel {
				category:string;
description:string;
discountPct:number;
endDate:string;
maxQty:number;
minQty:number;
modifiedDate:string;
rowguid:string;
specialOfferID:number;
startDate:string;
type:string;

	
				constructor() {
					this.category = '';
this.description = '';
this.discountPct = 0;
this.endDate = '';
this.maxQty = 0;
this.minQty = 0;
this.modifiedDate = '';
this.rowguid = '';
this.specialOfferID = 0;
this.startDate = '';
this.type = '';

		
				}
			}

			export class ApiSpecialOfferResponseModel {
				category:string;
description:string;
discountPct:number;
endDate:string;
maxQty:number;
minQty:number;
modifiedDate:string;
rowguid:string;
specialOfferID:number;
startDate:string;
type:string;

	
				constructor() {
					this.category = '';
this.description = '';
this.discountPct = 0;
this.endDate = '';
this.maxQty = 0;
this.minQty = 0;
this.modifiedDate = '';
this.rowguid = '';
this.specialOfferID = 0;
this.startDate = '';
this.type = '';

		
				}
			}
			export class ApiSpecialOfferProductRequestModel {
				modifiedDate:string;
productID:number;
rowguid:string;
specialOfferID:number;
specialOfferIDEntity:number;

	
				constructor() {
					this.modifiedDate = '';
this.productID = 0;
this.rowguid = '';
this.specialOfferID = 0;

		
				}
			}

			export class ApiSpecialOfferProductResponseModel {
				modifiedDate:string;
productID:number;
rowguid:string;
specialOfferID:number;
specialOfferIDEntity:number;

	
				constructor() {
					this.modifiedDate = '';
this.productID = 0;
this.rowguid = '';
this.specialOfferID = 0;

		
				}
			}
			export class ApiStoreRequestModel {
				businessEntityID:number;
demographic:string;
modifiedDate:string;
name:string;
rowguid:string;
salesPersonID:number;
salesPersonIDEntity:number;

	
				constructor() {
					this.businessEntityID = 0;
this.demographic = '';
this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.salesPersonID = 0;

		
				}
			}

			export class ApiStoreResponseModel {
				businessEntityID:number;
demographic:string;
modifiedDate:string;
name:string;
rowguid:string;
salesPersonID:number;
salesPersonIDEntity:number;

	
				constructor() {
					this.businessEntityID = 0;
this.demographic = '';
this.modifiedDate = '';
this.name = '';
this.rowguid = '';
this.salesPersonID = 0;

		
				}
			}