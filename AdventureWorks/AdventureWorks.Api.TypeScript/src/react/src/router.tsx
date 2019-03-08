import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants'; 
import { WrappedAWBuildVersionCreateComponent } from './components/aWBuildVersion/aWBuildVersionCreateForm';
import { WrappedAWBuildVersionDetailComponent } from './components/aWBuildVersion/aWBuildVersionDetailForm';
import { WrappedAWBuildVersionEditComponent } from './components/aWBuildVersion/aWBuildVersionEditForm';
import { WrappedAWBuildVersionSearchComponent } from './components/aWBuildVersion/aWBuildVersionSearchForm';					
import { WrappedDatabaseLogCreateComponent } from './components/databaseLog/databaseLogCreateForm';
import { WrappedDatabaseLogDetailComponent } from './components/databaseLog/databaseLogDetailForm';
import { WrappedDatabaseLogEditComponent } from './components/databaseLog/databaseLogEditForm';
import { WrappedDatabaseLogSearchComponent } from './components/databaseLog/databaseLogSearchForm';					
import { WrappedErrorLogCreateComponent } from './components/errorLog/errorLogCreateForm';
import { WrappedErrorLogDetailComponent } from './components/errorLog/errorLogDetailForm';
import { WrappedErrorLogEditComponent } from './components/errorLog/errorLogEditForm';
import { WrappedErrorLogSearchComponent } from './components/errorLog/errorLogSearchForm';					
import { WrappedDepartmentCreateComponent } from './components/department/departmentCreateForm';
import { WrappedDepartmentDetailComponent } from './components/department/departmentDetailForm';
import { WrappedDepartmentEditComponent } from './components/department/departmentEditForm';
import { WrappedDepartmentSearchComponent } from './components/department/departmentSearchForm';					
import { WrappedEmployeeCreateComponent } from './components/employee/employeeCreateForm';
import { WrappedEmployeeDetailComponent } from './components/employee/employeeDetailForm';
import { WrappedEmployeeEditComponent } from './components/employee/employeeEditForm';
import { WrappedEmployeeSearchComponent } from './components/employee/employeeSearchForm';					
import { WrappedJobCandidateCreateComponent } from './components/jobCandidate/jobCandidateCreateForm';
import { WrappedJobCandidateDetailComponent } from './components/jobCandidate/jobCandidateDetailForm';
import { WrappedJobCandidateEditComponent } from './components/jobCandidate/jobCandidateEditForm';
import { WrappedJobCandidateSearchComponent } from './components/jobCandidate/jobCandidateSearchForm';					
import { WrappedShiftCreateComponent } from './components/shift/shiftCreateForm';
import { WrappedShiftDetailComponent } from './components/shift/shiftDetailForm';
import { WrappedShiftEditComponent } from './components/shift/shiftEditForm';
import { WrappedShiftSearchComponent } from './components/shift/shiftSearchForm';					
import { WrappedAddressCreateComponent } from './components/address/addressCreateForm';
import { WrappedAddressDetailComponent } from './components/address/addressDetailForm';
import { WrappedAddressEditComponent } from './components/address/addressEditForm';
import { WrappedAddressSearchComponent } from './components/address/addressSearchForm';					
import { WrappedAddressTypeCreateComponent } from './components/addressType/addressTypeCreateForm';
import { WrappedAddressTypeDetailComponent } from './components/addressType/addressTypeDetailForm';
import { WrappedAddressTypeEditComponent } from './components/addressType/addressTypeEditForm';
import { WrappedAddressTypeSearchComponent } from './components/addressType/addressTypeSearchForm';					
import { WrappedBusinessEntityCreateComponent } from './components/businessEntity/businessEntityCreateForm';
import { WrappedBusinessEntityDetailComponent } from './components/businessEntity/businessEntityDetailForm';
import { WrappedBusinessEntityEditComponent } from './components/businessEntity/businessEntityEditForm';
import { WrappedBusinessEntitySearchComponent } from './components/businessEntity/businessEntitySearchForm';					
import { WrappedContactTypeCreateComponent } from './components/contactType/contactTypeCreateForm';
import { WrappedContactTypeDetailComponent } from './components/contactType/contactTypeDetailForm';
import { WrappedContactTypeEditComponent } from './components/contactType/contactTypeEditForm';
import { WrappedContactTypeSearchComponent } from './components/contactType/contactTypeSearchForm';					
import { WrappedCountryRegionCreateComponent } from './components/countryRegion/countryRegionCreateForm';
import { WrappedCountryRegionDetailComponent } from './components/countryRegion/countryRegionDetailForm';
import { WrappedCountryRegionEditComponent } from './components/countryRegion/countryRegionEditForm';
import { WrappedCountryRegionSearchComponent } from './components/countryRegion/countryRegionSearchForm';					
import { WrappedPasswordCreateComponent } from './components/password/passwordCreateForm';
import { WrappedPasswordDetailComponent } from './components/password/passwordDetailForm';
import { WrappedPasswordEditComponent } from './components/password/passwordEditForm';
import { WrappedPasswordSearchComponent } from './components/password/passwordSearchForm';					
import { WrappedPersonCreateComponent } from './components/person/personCreateForm';
import { WrappedPersonDetailComponent } from './components/person/personDetailForm';
import { WrappedPersonEditComponent } from './components/person/personEditForm';
import { WrappedPersonSearchComponent } from './components/person/personSearchForm';					
import { WrappedPhoneNumberTypeCreateComponent } from './components/phoneNumberType/phoneNumberTypeCreateForm';
import { WrappedPhoneNumberTypeDetailComponent } from './components/phoneNumberType/phoneNumberTypeDetailForm';
import { WrappedPhoneNumberTypeEditComponent } from './components/phoneNumberType/phoneNumberTypeEditForm';
import { WrappedPhoneNumberTypeSearchComponent } from './components/phoneNumberType/phoneNumberTypeSearchForm';					
import { WrappedStateProvinceCreateComponent } from './components/stateProvince/stateProvinceCreateForm';
import { WrappedStateProvinceDetailComponent } from './components/stateProvince/stateProvinceDetailForm';
import { WrappedStateProvinceEditComponent } from './components/stateProvince/stateProvinceEditForm';
import { WrappedStateProvinceSearchComponent } from './components/stateProvince/stateProvinceSearchForm';					
import { WrappedBillOfMaterialCreateComponent } from './components/billOfMaterial/billOfMaterialCreateForm';
import { WrappedBillOfMaterialDetailComponent } from './components/billOfMaterial/billOfMaterialDetailForm';
import { WrappedBillOfMaterialEditComponent } from './components/billOfMaterial/billOfMaterialEditForm';
import { WrappedBillOfMaterialSearchComponent } from './components/billOfMaterial/billOfMaterialSearchForm';					
import { WrappedCultureCreateComponent } from './components/culture/cultureCreateForm';
import { WrappedCultureDetailComponent } from './components/culture/cultureDetailForm';
import { WrappedCultureEditComponent } from './components/culture/cultureEditForm';
import { WrappedCultureSearchComponent } from './components/culture/cultureSearchForm';					
import { WrappedDocumentCreateComponent } from './components/document/documentCreateForm';
import { WrappedDocumentDetailComponent } from './components/document/documentDetailForm';
import { WrappedDocumentEditComponent } from './components/document/documentEditForm';
import { WrappedDocumentSearchComponent } from './components/document/documentSearchForm';					
import { WrappedIllustrationCreateComponent } from './components/illustration/illustrationCreateForm';
import { WrappedIllustrationDetailComponent } from './components/illustration/illustrationDetailForm';
import { WrappedIllustrationEditComponent } from './components/illustration/illustrationEditForm';
import { WrappedIllustrationSearchComponent } from './components/illustration/illustrationSearchForm';					
import { WrappedLocationCreateComponent } from './components/location/locationCreateForm';
import { WrappedLocationDetailComponent } from './components/location/locationDetailForm';
import { WrappedLocationEditComponent } from './components/location/locationEditForm';
import { WrappedLocationSearchComponent } from './components/location/locationSearchForm';					
import { WrappedProductCreateComponent } from './components/product/productCreateForm';
import { WrappedProductDetailComponent } from './components/product/productDetailForm';
import { WrappedProductEditComponent } from './components/product/productEditForm';
import { WrappedProductSearchComponent } from './components/product/productSearchForm';					
import { WrappedProductCategoryCreateComponent } from './components/productCategory/productCategoryCreateForm';
import { WrappedProductCategoryDetailComponent } from './components/productCategory/productCategoryDetailForm';
import { WrappedProductCategoryEditComponent } from './components/productCategory/productCategoryEditForm';
import { WrappedProductCategorySearchComponent } from './components/productCategory/productCategorySearchForm';					
import { WrappedProductDescriptionCreateComponent } from './components/productDescription/productDescriptionCreateForm';
import { WrappedProductDescriptionDetailComponent } from './components/productDescription/productDescriptionDetailForm';
import { WrappedProductDescriptionEditComponent } from './components/productDescription/productDescriptionEditForm';
import { WrappedProductDescriptionSearchComponent } from './components/productDescription/productDescriptionSearchForm';					
import { WrappedProductModelCreateComponent } from './components/productModel/productModelCreateForm';
import { WrappedProductModelDetailComponent } from './components/productModel/productModelDetailForm';
import { WrappedProductModelEditComponent } from './components/productModel/productModelEditForm';
import { WrappedProductModelSearchComponent } from './components/productModel/productModelSearchForm';					
import { WrappedProductPhotoCreateComponent } from './components/productPhoto/productPhotoCreateForm';
import { WrappedProductPhotoDetailComponent } from './components/productPhoto/productPhotoDetailForm';
import { WrappedProductPhotoEditComponent } from './components/productPhoto/productPhotoEditForm';
import { WrappedProductPhotoSearchComponent } from './components/productPhoto/productPhotoSearchForm';					
import { WrappedProductReviewCreateComponent } from './components/productReview/productReviewCreateForm';
import { WrappedProductReviewDetailComponent } from './components/productReview/productReviewDetailForm';
import { WrappedProductReviewEditComponent } from './components/productReview/productReviewEditForm';
import { WrappedProductReviewSearchComponent } from './components/productReview/productReviewSearchForm';					
import { WrappedProductSubcategoryCreateComponent } from './components/productSubcategory/productSubcategoryCreateForm';
import { WrappedProductSubcategoryDetailComponent } from './components/productSubcategory/productSubcategoryDetailForm';
import { WrappedProductSubcategoryEditComponent } from './components/productSubcategory/productSubcategoryEditForm';
import { WrappedProductSubcategorySearchComponent } from './components/productSubcategory/productSubcategorySearchForm';					
import { WrappedScrapReasonCreateComponent } from './components/scrapReason/scrapReasonCreateForm';
import { WrappedScrapReasonDetailComponent } from './components/scrapReason/scrapReasonDetailForm';
import { WrappedScrapReasonEditComponent } from './components/scrapReason/scrapReasonEditForm';
import { WrappedScrapReasonSearchComponent } from './components/scrapReason/scrapReasonSearchForm';					
import { WrappedTransactionHistoryCreateComponent } from './components/transactionHistory/transactionHistoryCreateForm';
import { WrappedTransactionHistoryDetailComponent } from './components/transactionHistory/transactionHistoryDetailForm';
import { WrappedTransactionHistoryEditComponent } from './components/transactionHistory/transactionHistoryEditForm';
import { WrappedTransactionHistorySearchComponent } from './components/transactionHistory/transactionHistorySearchForm';					
import { WrappedTransactionHistoryArchiveCreateComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveCreateForm';
import { WrappedTransactionHistoryArchiveDetailComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveDetailForm';
import { WrappedTransactionHistoryArchiveEditComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveEditForm';
import { WrappedTransactionHistoryArchiveSearchComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveSearchForm';					
import { WrappedUnitMeasureCreateComponent } from './components/unitMeasure/unitMeasureCreateForm';
import { WrappedUnitMeasureDetailComponent } from './components/unitMeasure/unitMeasureDetailForm';
import { WrappedUnitMeasureEditComponent } from './components/unitMeasure/unitMeasureEditForm';
import { WrappedUnitMeasureSearchComponent } from './components/unitMeasure/unitMeasureSearchForm';					
import { WrappedWorkOrderCreateComponent } from './components/workOrder/workOrderCreateForm';
import { WrappedWorkOrderDetailComponent } from './components/workOrder/workOrderDetailForm';
import { WrappedWorkOrderEditComponent } from './components/workOrder/workOrderEditForm';
import { WrappedWorkOrderSearchComponent } from './components/workOrder/workOrderSearchForm';					
import { WrappedPurchaseOrderHeaderCreateComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderCreateForm';
import { WrappedPurchaseOrderHeaderDetailComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderDetailForm';
import { WrappedPurchaseOrderHeaderEditComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderEditForm';
import { WrappedPurchaseOrderHeaderSearchComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderSearchForm';					
import { WrappedShipMethodCreateComponent } from './components/shipMethod/shipMethodCreateForm';
import { WrappedShipMethodDetailComponent } from './components/shipMethod/shipMethodDetailForm';
import { WrappedShipMethodEditComponent } from './components/shipMethod/shipMethodEditForm';
import { WrappedShipMethodSearchComponent } from './components/shipMethod/shipMethodSearchForm';					
import { WrappedVendorCreateComponent } from './components/vendor/vendorCreateForm';
import { WrappedVendorDetailComponent } from './components/vendor/vendorDetailForm';
import { WrappedVendorEditComponent } from './components/vendor/vendorEditForm';
import { WrappedVendorSearchComponent } from './components/vendor/vendorSearchForm';					
import { WrappedCreditCardCreateComponent } from './components/creditCard/creditCardCreateForm';
import { WrappedCreditCardDetailComponent } from './components/creditCard/creditCardDetailForm';
import { WrappedCreditCardEditComponent } from './components/creditCard/creditCardEditForm';
import { WrappedCreditCardSearchComponent } from './components/creditCard/creditCardSearchForm';					
import { WrappedCurrencyCreateComponent } from './components/currency/currencyCreateForm';
import { WrappedCurrencyDetailComponent } from './components/currency/currencyDetailForm';
import { WrappedCurrencyEditComponent } from './components/currency/currencyEditForm';
import { WrappedCurrencySearchComponent } from './components/currency/currencySearchForm';					
import { WrappedCurrencyRateCreateComponent } from './components/currencyRate/currencyRateCreateForm';
import { WrappedCurrencyRateDetailComponent } from './components/currencyRate/currencyRateDetailForm';
import { WrappedCurrencyRateEditComponent } from './components/currencyRate/currencyRateEditForm';
import { WrappedCurrencyRateSearchComponent } from './components/currencyRate/currencyRateSearchForm';					
import { WrappedCustomerCreateComponent } from './components/customer/customerCreateForm';
import { WrappedCustomerDetailComponent } from './components/customer/customerDetailForm';
import { WrappedCustomerEditComponent } from './components/customer/customerEditForm';
import { WrappedCustomerSearchComponent } from './components/customer/customerSearchForm';					
import { WrappedSalesOrderHeaderCreateComponent } from './components/salesOrderHeader/salesOrderHeaderCreateForm';
import { WrappedSalesOrderHeaderDetailComponent } from './components/salesOrderHeader/salesOrderHeaderDetailForm';
import { WrappedSalesOrderHeaderEditComponent } from './components/salesOrderHeader/salesOrderHeaderEditForm';
import { WrappedSalesOrderHeaderSearchComponent } from './components/salesOrderHeader/salesOrderHeaderSearchForm';					
import { WrappedSalesPersonCreateComponent } from './components/salesPerson/salesPersonCreateForm';
import { WrappedSalesPersonDetailComponent } from './components/salesPerson/salesPersonDetailForm';
import { WrappedSalesPersonEditComponent } from './components/salesPerson/salesPersonEditForm';
import { WrappedSalesPersonSearchComponent } from './components/salesPerson/salesPersonSearchForm';					
import { WrappedSalesReasonCreateComponent } from './components/salesReason/salesReasonCreateForm';
import { WrappedSalesReasonDetailComponent } from './components/salesReason/salesReasonDetailForm';
import { WrappedSalesReasonEditComponent } from './components/salesReason/salesReasonEditForm';
import { WrappedSalesReasonSearchComponent } from './components/salesReason/salesReasonSearchForm';					
import { WrappedSalesTaxRateCreateComponent } from './components/salesTaxRate/salesTaxRateCreateForm';
import { WrappedSalesTaxRateDetailComponent } from './components/salesTaxRate/salesTaxRateDetailForm';
import { WrappedSalesTaxRateEditComponent } from './components/salesTaxRate/salesTaxRateEditForm';
import { WrappedSalesTaxRateSearchComponent } from './components/salesTaxRate/salesTaxRateSearchForm';					
import { WrappedSalesTerritoryCreateComponent } from './components/salesTerritory/salesTerritoryCreateForm';
import { WrappedSalesTerritoryDetailComponent } from './components/salesTerritory/salesTerritoryDetailForm';
import { WrappedSalesTerritoryEditComponent } from './components/salesTerritory/salesTerritoryEditForm';
import { WrappedSalesTerritorySearchComponent } from './components/salesTerritory/salesTerritorySearchForm';					
import { WrappedShoppingCartItemCreateComponent } from './components/shoppingCartItem/shoppingCartItemCreateForm';
import { WrappedShoppingCartItemDetailComponent } from './components/shoppingCartItem/shoppingCartItemDetailForm';
import { WrappedShoppingCartItemEditComponent } from './components/shoppingCartItem/shoppingCartItemEditForm';
import { WrappedShoppingCartItemSearchComponent } from './components/shoppingCartItem/shoppingCartItemSearchForm';					
import { WrappedSpecialOfferCreateComponent } from './components/specialOffer/specialOfferCreateForm';
import { WrappedSpecialOfferDetailComponent } from './components/specialOffer/specialOfferDetailForm';
import { WrappedSpecialOfferEditComponent } from './components/specialOffer/specialOfferEditForm';
import { WrappedSpecialOfferSearchComponent } from './components/specialOffer/specialOfferSearchForm';					
import { WrappedStoreCreateComponent } from './components/store/storeCreateForm';
import { WrappedStoreDetailComponent } from './components/store/storeDetailForm';
import { WrappedStoreEditComponent } from './components/store/storeEditForm';
import { WrappedStoreSearchComponent } from './components/store/storeSearchForm';					

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  }
}

export const AppRouter: React.StatelessComponent<{}> = () => {

  return (
    <BrowserRouter basename={Constants.HostedSubDirectory}>   
	<Security issuer={config.oidc.issuer}
        client_id={config.oidc.clientId}
        redirect_uri={config.oidc.redirectUri}>
	    <SecureRoute path="/protected" component={() => '<div>secure route</div>'} />
        <Switch>
          <Route exact path="/" component={wrapperHeader(Dashboard, "Dashboard")} />
		  <Route path={ClientRoutes.AWBuildVersions + "/create"} component={wrapperHeader(WrappedAWBuildVersionCreateComponent, "AWBuildVersions Create")} />
                      <Route path={ClientRoutes.AWBuildVersions + "/edit/:id"} component={wrapperHeader(WrappedAWBuildVersionEditComponent, "AWBuildVersions Edit")} />
                      <Route path={ClientRoutes.AWBuildVersions + "/:id"} component={wrapperHeader(WrappedAWBuildVersionDetailComponent , "AWBuildVersions Detail")} />
                      <Route path={ClientRoutes.AWBuildVersions} component={wrapperHeader(WrappedAWBuildVersionSearchComponent, "AWBuildVersions Search")} />
					<Route path={ClientRoutes.DatabaseLogs + "/create"} component={wrapperHeader(WrappedDatabaseLogCreateComponent, "DatabaseLogs Create")} />
                      <Route path={ClientRoutes.DatabaseLogs + "/edit/:id"} component={wrapperHeader(WrappedDatabaseLogEditComponent, "DatabaseLogs Edit")} />
                      <Route path={ClientRoutes.DatabaseLogs + "/:id"} component={wrapperHeader(WrappedDatabaseLogDetailComponent , "DatabaseLogs Detail")} />
                      <Route path={ClientRoutes.DatabaseLogs} component={wrapperHeader(WrappedDatabaseLogSearchComponent, "DatabaseLogs Search")} />
					<Route path={ClientRoutes.ErrorLogs + "/create"} component={wrapperHeader(WrappedErrorLogCreateComponent, "ErrorLogs Create")} />
                      <Route path={ClientRoutes.ErrorLogs + "/edit/:id"} component={wrapperHeader(WrappedErrorLogEditComponent, "ErrorLogs Edit")} />
                      <Route path={ClientRoutes.ErrorLogs + "/:id"} component={wrapperHeader(WrappedErrorLogDetailComponent , "ErrorLogs Detail")} />
                      <Route path={ClientRoutes.ErrorLogs} component={wrapperHeader(WrappedErrorLogSearchComponent, "ErrorLogs Search")} />
					<Route path={ClientRoutes.Departments + "/create"} component={wrapperHeader(WrappedDepartmentCreateComponent, "Departments Create")} />
                      <Route path={ClientRoutes.Departments + "/edit/:id"} component={wrapperHeader(WrappedDepartmentEditComponent, "Departments Edit")} />
                      <Route path={ClientRoutes.Departments + "/:id"} component={wrapperHeader(WrappedDepartmentDetailComponent , "Departments Detail")} />
                      <Route path={ClientRoutes.Departments} component={wrapperHeader(WrappedDepartmentSearchComponent, "Departments Search")} />
					<Route path={ClientRoutes.Employees + "/create"} component={wrapperHeader(WrappedEmployeeCreateComponent, "Employees Create")} />
                      <Route path={ClientRoutes.Employees + "/edit/:id"} component={wrapperHeader(WrappedEmployeeEditComponent, "Employees Edit")} />
                      <Route path={ClientRoutes.Employees + "/:id"} component={wrapperHeader(WrappedEmployeeDetailComponent , "Employees Detail")} />
                      <Route path={ClientRoutes.Employees} component={wrapperHeader(WrappedEmployeeSearchComponent, "Employees Search")} />
					<Route path={ClientRoutes.JobCandidates + "/create"} component={wrapperHeader(WrappedJobCandidateCreateComponent, "JobCandidates Create")} />
                      <Route path={ClientRoutes.JobCandidates + "/edit/:id"} component={wrapperHeader(WrappedJobCandidateEditComponent, "JobCandidates Edit")} />
                      <Route path={ClientRoutes.JobCandidates + "/:id"} component={wrapperHeader(WrappedJobCandidateDetailComponent , "JobCandidates Detail")} />
                      <Route path={ClientRoutes.JobCandidates} component={wrapperHeader(WrappedJobCandidateSearchComponent, "JobCandidates Search")} />
					<Route path={ClientRoutes.Shifts + "/create"} component={wrapperHeader(WrappedShiftCreateComponent, "Shifts Create")} />
                      <Route path={ClientRoutes.Shifts + "/edit/:id"} component={wrapperHeader(WrappedShiftEditComponent, "Shifts Edit")} />
                      <Route path={ClientRoutes.Shifts + "/:id"} component={wrapperHeader(WrappedShiftDetailComponent , "Shifts Detail")} />
                      <Route path={ClientRoutes.Shifts} component={wrapperHeader(WrappedShiftSearchComponent, "Shifts Search")} />
					<Route path={ClientRoutes.Addresses + "/create"} component={wrapperHeader(WrappedAddressCreateComponent, "Addresses Create")} />
                      <Route path={ClientRoutes.Addresses + "/edit/:id"} component={wrapperHeader(WrappedAddressEditComponent, "Addresses Edit")} />
                      <Route path={ClientRoutes.Addresses + "/:id"} component={wrapperHeader(WrappedAddressDetailComponent , "Addresses Detail")} />
                      <Route path={ClientRoutes.Addresses} component={wrapperHeader(WrappedAddressSearchComponent, "Addresses Search")} />
					<Route path={ClientRoutes.AddressTypes + "/create"} component={wrapperHeader(WrappedAddressTypeCreateComponent, "AddressTypes Create")} />
                      <Route path={ClientRoutes.AddressTypes + "/edit/:id"} component={wrapperHeader(WrappedAddressTypeEditComponent, "AddressTypes Edit")} />
                      <Route path={ClientRoutes.AddressTypes + "/:id"} component={wrapperHeader(WrappedAddressTypeDetailComponent , "AddressTypes Detail")} />
                      <Route path={ClientRoutes.AddressTypes} component={wrapperHeader(WrappedAddressTypeSearchComponent, "AddressTypes Search")} />
					<Route path={ClientRoutes.BusinessEntities + "/create"} component={wrapperHeader(WrappedBusinessEntityCreateComponent, "BusinessEntities Create")} />
                      <Route path={ClientRoutes.BusinessEntities + "/edit/:id"} component={wrapperHeader(WrappedBusinessEntityEditComponent, "BusinessEntities Edit")} />
                      <Route path={ClientRoutes.BusinessEntities + "/:id"} component={wrapperHeader(WrappedBusinessEntityDetailComponent , "BusinessEntities Detail")} />
                      <Route path={ClientRoutes.BusinessEntities} component={wrapperHeader(WrappedBusinessEntitySearchComponent, "BusinessEntities Search")} />
					<Route path={ClientRoutes.ContactTypes + "/create"} component={wrapperHeader(WrappedContactTypeCreateComponent, "ContactTypes Create")} />
                      <Route path={ClientRoutes.ContactTypes + "/edit/:id"} component={wrapperHeader(WrappedContactTypeEditComponent, "ContactTypes Edit")} />
                      <Route path={ClientRoutes.ContactTypes + "/:id"} component={wrapperHeader(WrappedContactTypeDetailComponent , "ContactTypes Detail")} />
                      <Route path={ClientRoutes.ContactTypes} component={wrapperHeader(WrappedContactTypeSearchComponent, "ContactTypes Search")} />
					<Route path={ClientRoutes.CountryRegions + "/create"} component={wrapperHeader(WrappedCountryRegionCreateComponent, "CountryRegions Create")} />
                      <Route path={ClientRoutes.CountryRegions + "/edit/:id"} component={wrapperHeader(WrappedCountryRegionEditComponent, "CountryRegions Edit")} />
                      <Route path={ClientRoutes.CountryRegions + "/:id"} component={wrapperHeader(WrappedCountryRegionDetailComponent , "CountryRegions Detail")} />
                      <Route path={ClientRoutes.CountryRegions} component={wrapperHeader(WrappedCountryRegionSearchComponent, "CountryRegions Search")} />
					<Route path={ClientRoutes.Passwords + "/create"} component={wrapperHeader(WrappedPasswordCreateComponent, "Passwords Create")} />
                      <Route path={ClientRoutes.Passwords + "/edit/:id"} component={wrapperHeader(WrappedPasswordEditComponent, "Passwords Edit")} />
                      <Route path={ClientRoutes.Passwords + "/:id"} component={wrapperHeader(WrappedPasswordDetailComponent , "Passwords Detail")} />
                      <Route path={ClientRoutes.Passwords} component={wrapperHeader(WrappedPasswordSearchComponent, "Passwords Search")} />
					<Route path={ClientRoutes.People + "/create"} component={wrapperHeader(WrappedPersonCreateComponent, "People Create")} />
                      <Route path={ClientRoutes.People + "/edit/:id"} component={wrapperHeader(WrappedPersonEditComponent, "People Edit")} />
                      <Route path={ClientRoutes.People + "/:id"} component={wrapperHeader(WrappedPersonDetailComponent , "People Detail")} />
                      <Route path={ClientRoutes.People} component={wrapperHeader(WrappedPersonSearchComponent, "People Search")} />
					<Route path={ClientRoutes.PhoneNumberTypes + "/create"} component={wrapperHeader(WrappedPhoneNumberTypeCreateComponent, "PhoneNumberTypes Create")} />
                      <Route path={ClientRoutes.PhoneNumberTypes + "/edit/:id"} component={wrapperHeader(WrappedPhoneNumberTypeEditComponent, "PhoneNumberTypes Edit")} />
                      <Route path={ClientRoutes.PhoneNumberTypes + "/:id"} component={wrapperHeader(WrappedPhoneNumberTypeDetailComponent , "PhoneNumberTypes Detail")} />
                      <Route path={ClientRoutes.PhoneNumberTypes} component={wrapperHeader(WrappedPhoneNumberTypeSearchComponent, "PhoneNumberTypes Search")} />
					<Route path={ClientRoutes.StateProvinces + "/create"} component={wrapperHeader(WrappedStateProvinceCreateComponent, "StateProvinces Create")} />
                      <Route path={ClientRoutes.StateProvinces + "/edit/:id"} component={wrapperHeader(WrappedStateProvinceEditComponent, "StateProvinces Edit")} />
                      <Route path={ClientRoutes.StateProvinces + "/:id"} component={wrapperHeader(WrappedStateProvinceDetailComponent , "StateProvinces Detail")} />
                      <Route path={ClientRoutes.StateProvinces} component={wrapperHeader(WrappedStateProvinceSearchComponent, "StateProvinces Search")} />
					<Route path={ClientRoutes.BillOfMaterials + "/create"} component={wrapperHeader(WrappedBillOfMaterialCreateComponent, "BillOfMaterials Create")} />
                      <Route path={ClientRoutes.BillOfMaterials + "/edit/:id"} component={wrapperHeader(WrappedBillOfMaterialEditComponent, "BillOfMaterials Edit")} />
                      <Route path={ClientRoutes.BillOfMaterials + "/:id"} component={wrapperHeader(WrappedBillOfMaterialDetailComponent , "BillOfMaterials Detail")} />
                      <Route path={ClientRoutes.BillOfMaterials} component={wrapperHeader(WrappedBillOfMaterialSearchComponent, "BillOfMaterials Search")} />
					<Route path={ClientRoutes.Cultures + "/create"} component={wrapperHeader(WrappedCultureCreateComponent, "Cultures Create")} />
                      <Route path={ClientRoutes.Cultures + "/edit/:id"} component={wrapperHeader(WrappedCultureEditComponent, "Cultures Edit")} />
                      <Route path={ClientRoutes.Cultures + "/:id"} component={wrapperHeader(WrappedCultureDetailComponent , "Cultures Detail")} />
                      <Route path={ClientRoutes.Cultures} component={wrapperHeader(WrappedCultureSearchComponent, "Cultures Search")} />
					<Route path={ClientRoutes.Documents + "/create"} component={wrapperHeader(WrappedDocumentCreateComponent, "Documents Create")} />
                      <Route path={ClientRoutes.Documents + "/edit/:id"} component={wrapperHeader(WrappedDocumentEditComponent, "Documents Edit")} />
                      <Route path={ClientRoutes.Documents + "/:id"} component={wrapperHeader(WrappedDocumentDetailComponent , "Documents Detail")} />
                      <Route path={ClientRoutes.Documents} component={wrapperHeader(WrappedDocumentSearchComponent, "Documents Search")} />
					<Route path={ClientRoutes.Illustrations + "/create"} component={wrapperHeader(WrappedIllustrationCreateComponent, "Illustrations Create")} />
                      <Route path={ClientRoutes.Illustrations + "/edit/:id"} component={wrapperHeader(WrappedIllustrationEditComponent, "Illustrations Edit")} />
                      <Route path={ClientRoutes.Illustrations + "/:id"} component={wrapperHeader(WrappedIllustrationDetailComponent , "Illustrations Detail")} />
                      <Route path={ClientRoutes.Illustrations} component={wrapperHeader(WrappedIllustrationSearchComponent, "Illustrations Search")} />
					<Route path={ClientRoutes.Locations + "/create"} component={wrapperHeader(WrappedLocationCreateComponent, "Locations Create")} />
                      <Route path={ClientRoutes.Locations + "/edit/:id"} component={wrapperHeader(WrappedLocationEditComponent, "Locations Edit")} />
                      <Route path={ClientRoutes.Locations + "/:id"} component={wrapperHeader(WrappedLocationDetailComponent , "Locations Detail")} />
                      <Route path={ClientRoutes.Locations} component={wrapperHeader(WrappedLocationSearchComponent, "Locations Search")} />
					<Route path={ClientRoutes.Products + "/create"} component={wrapperHeader(WrappedProductCreateComponent, "Products Create")} />
                      <Route path={ClientRoutes.Products + "/edit/:id"} component={wrapperHeader(WrappedProductEditComponent, "Products Edit")} />
                      <Route path={ClientRoutes.Products + "/:id"} component={wrapperHeader(WrappedProductDetailComponent , "Products Detail")} />
                      <Route path={ClientRoutes.Products} component={wrapperHeader(WrappedProductSearchComponent, "Products Search")} />
					<Route path={ClientRoutes.ProductCategories + "/create"} component={wrapperHeader(WrappedProductCategoryCreateComponent, "ProductCategories Create")} />
                      <Route path={ClientRoutes.ProductCategories + "/edit/:id"} component={wrapperHeader(WrappedProductCategoryEditComponent, "ProductCategories Edit")} />
                      <Route path={ClientRoutes.ProductCategories + "/:id"} component={wrapperHeader(WrappedProductCategoryDetailComponent , "ProductCategories Detail")} />
                      <Route path={ClientRoutes.ProductCategories} component={wrapperHeader(WrappedProductCategorySearchComponent, "ProductCategories Search")} />
					<Route path={ClientRoutes.ProductDescriptions + "/create"} component={wrapperHeader(WrappedProductDescriptionCreateComponent, "ProductDescriptions Create")} />
                      <Route path={ClientRoutes.ProductDescriptions + "/edit/:id"} component={wrapperHeader(WrappedProductDescriptionEditComponent, "ProductDescriptions Edit")} />
                      <Route path={ClientRoutes.ProductDescriptions + "/:id"} component={wrapperHeader(WrappedProductDescriptionDetailComponent , "ProductDescriptions Detail")} />
                      <Route path={ClientRoutes.ProductDescriptions} component={wrapperHeader(WrappedProductDescriptionSearchComponent, "ProductDescriptions Search")} />
					<Route path={ClientRoutes.ProductModels + "/create"} component={wrapperHeader(WrappedProductModelCreateComponent, "ProductModels Create")} />
                      <Route path={ClientRoutes.ProductModels + "/edit/:id"} component={wrapperHeader(WrappedProductModelEditComponent, "ProductModels Edit")} />
                      <Route path={ClientRoutes.ProductModels + "/:id"} component={wrapperHeader(WrappedProductModelDetailComponent , "ProductModels Detail")} />
                      <Route path={ClientRoutes.ProductModels} component={wrapperHeader(WrappedProductModelSearchComponent, "ProductModels Search")} />
					<Route path={ClientRoutes.ProductPhotoes + "/create"} component={wrapperHeader(WrappedProductPhotoCreateComponent, "ProductPhotoes Create")} />
                      <Route path={ClientRoutes.ProductPhotoes + "/edit/:id"} component={wrapperHeader(WrappedProductPhotoEditComponent, "ProductPhotoes Edit")} />
                      <Route path={ClientRoutes.ProductPhotoes + "/:id"} component={wrapperHeader(WrappedProductPhotoDetailComponent , "ProductPhotoes Detail")} />
                      <Route path={ClientRoutes.ProductPhotoes} component={wrapperHeader(WrappedProductPhotoSearchComponent, "ProductPhotoes Search")} />
					<Route path={ClientRoutes.ProductReviews + "/create"} component={wrapperHeader(WrappedProductReviewCreateComponent, "ProductReviews Create")} />
                      <Route path={ClientRoutes.ProductReviews + "/edit/:id"} component={wrapperHeader(WrappedProductReviewEditComponent, "ProductReviews Edit")} />
                      <Route path={ClientRoutes.ProductReviews + "/:id"} component={wrapperHeader(WrappedProductReviewDetailComponent , "ProductReviews Detail")} />
                      <Route path={ClientRoutes.ProductReviews} component={wrapperHeader(WrappedProductReviewSearchComponent, "ProductReviews Search")} />
					<Route path={ClientRoutes.ProductSubcategories + "/create"} component={wrapperHeader(WrappedProductSubcategoryCreateComponent, "ProductSubcategories Create")} />
                      <Route path={ClientRoutes.ProductSubcategories + "/edit/:id"} component={wrapperHeader(WrappedProductSubcategoryEditComponent, "ProductSubcategories Edit")} />
                      <Route path={ClientRoutes.ProductSubcategories + "/:id"} component={wrapperHeader(WrappedProductSubcategoryDetailComponent , "ProductSubcategories Detail")} />
                      <Route path={ClientRoutes.ProductSubcategories} component={wrapperHeader(WrappedProductSubcategorySearchComponent, "ProductSubcategories Search")} />
					<Route path={ClientRoutes.ScrapReasons + "/create"} component={wrapperHeader(WrappedScrapReasonCreateComponent, "ScrapReasons Create")} />
                      <Route path={ClientRoutes.ScrapReasons + "/edit/:id"} component={wrapperHeader(WrappedScrapReasonEditComponent, "ScrapReasons Edit")} />
                      <Route path={ClientRoutes.ScrapReasons + "/:id"} component={wrapperHeader(WrappedScrapReasonDetailComponent , "ScrapReasons Detail")} />
                      <Route path={ClientRoutes.ScrapReasons} component={wrapperHeader(WrappedScrapReasonSearchComponent, "ScrapReasons Search")} />
					<Route path={ClientRoutes.TransactionHistories + "/create"} component={wrapperHeader(WrappedTransactionHistoryCreateComponent, "TransactionHistories Create")} />
                      <Route path={ClientRoutes.TransactionHistories + "/edit/:id"} component={wrapperHeader(WrappedTransactionHistoryEditComponent, "TransactionHistories Edit")} />
                      <Route path={ClientRoutes.TransactionHistories + "/:id"} component={wrapperHeader(WrappedTransactionHistoryDetailComponent , "TransactionHistories Detail")} />
                      <Route path={ClientRoutes.TransactionHistories} component={wrapperHeader(WrappedTransactionHistorySearchComponent, "TransactionHistories Search")} />
					<Route path={ClientRoutes.TransactionHistoryArchives + "/create"} component={wrapperHeader(WrappedTransactionHistoryArchiveCreateComponent, "TransactionHistoryArchives Create")} />
                      <Route path={ClientRoutes.TransactionHistoryArchives + "/edit/:id"} component={wrapperHeader(WrappedTransactionHistoryArchiveEditComponent, "TransactionHistoryArchives Edit")} />
                      <Route path={ClientRoutes.TransactionHistoryArchives + "/:id"} component={wrapperHeader(WrappedTransactionHistoryArchiveDetailComponent , "TransactionHistoryArchives Detail")} />
                      <Route path={ClientRoutes.TransactionHistoryArchives} component={wrapperHeader(WrappedTransactionHistoryArchiveSearchComponent, "TransactionHistoryArchives Search")} />
					<Route path={ClientRoutes.UnitMeasures + "/create"} component={wrapperHeader(WrappedUnitMeasureCreateComponent, "UnitMeasures Create")} />
                      <Route path={ClientRoutes.UnitMeasures + "/edit/:id"} component={wrapperHeader(WrappedUnitMeasureEditComponent, "UnitMeasures Edit")} />
                      <Route path={ClientRoutes.UnitMeasures + "/:id"} component={wrapperHeader(WrappedUnitMeasureDetailComponent , "UnitMeasures Detail")} />
                      <Route path={ClientRoutes.UnitMeasures} component={wrapperHeader(WrappedUnitMeasureSearchComponent, "UnitMeasures Search")} />
					<Route path={ClientRoutes.WorkOrders + "/create"} component={wrapperHeader(WrappedWorkOrderCreateComponent, "WorkOrders Create")} />
                      <Route path={ClientRoutes.WorkOrders + "/edit/:id"} component={wrapperHeader(WrappedWorkOrderEditComponent, "WorkOrders Edit")} />
                      <Route path={ClientRoutes.WorkOrders + "/:id"} component={wrapperHeader(WrappedWorkOrderDetailComponent , "WorkOrders Detail")} />
                      <Route path={ClientRoutes.WorkOrders} component={wrapperHeader(WrappedWorkOrderSearchComponent, "WorkOrders Search")} />
					<Route path={ClientRoutes.PurchaseOrderHeaders + "/create"} component={wrapperHeader(WrappedPurchaseOrderHeaderCreateComponent, "PurchaseOrderHeaders Create")} />
                      <Route path={ClientRoutes.PurchaseOrderHeaders + "/edit/:id"} component={wrapperHeader(WrappedPurchaseOrderHeaderEditComponent, "PurchaseOrderHeaders Edit")} />
                      <Route path={ClientRoutes.PurchaseOrderHeaders + "/:id"} component={wrapperHeader(WrappedPurchaseOrderHeaderDetailComponent , "PurchaseOrderHeaders Detail")} />
                      <Route path={ClientRoutes.PurchaseOrderHeaders} component={wrapperHeader(WrappedPurchaseOrderHeaderSearchComponent, "PurchaseOrderHeaders Search")} />
					<Route path={ClientRoutes.ShipMethods + "/create"} component={wrapperHeader(WrappedShipMethodCreateComponent, "ShipMethods Create")} />
                      <Route path={ClientRoutes.ShipMethods + "/edit/:id"} component={wrapperHeader(WrappedShipMethodEditComponent, "ShipMethods Edit")} />
                      <Route path={ClientRoutes.ShipMethods + "/:id"} component={wrapperHeader(WrappedShipMethodDetailComponent , "ShipMethods Detail")} />
                      <Route path={ClientRoutes.ShipMethods} component={wrapperHeader(WrappedShipMethodSearchComponent, "ShipMethods Search")} />
					<Route path={ClientRoutes.Vendors + "/create"} component={wrapperHeader(WrappedVendorCreateComponent, "Vendors Create")} />
                      <Route path={ClientRoutes.Vendors + "/edit/:id"} component={wrapperHeader(WrappedVendorEditComponent, "Vendors Edit")} />
                      <Route path={ClientRoutes.Vendors + "/:id"} component={wrapperHeader(WrappedVendorDetailComponent , "Vendors Detail")} />
                      <Route path={ClientRoutes.Vendors} component={wrapperHeader(WrappedVendorSearchComponent, "Vendors Search")} />
					<Route path={ClientRoutes.CreditCards + "/create"} component={wrapperHeader(WrappedCreditCardCreateComponent, "CreditCards Create")} />
                      <Route path={ClientRoutes.CreditCards + "/edit/:id"} component={wrapperHeader(WrappedCreditCardEditComponent, "CreditCards Edit")} />
                      <Route path={ClientRoutes.CreditCards + "/:id"} component={wrapperHeader(WrappedCreditCardDetailComponent , "CreditCards Detail")} />
                      <Route path={ClientRoutes.CreditCards} component={wrapperHeader(WrappedCreditCardSearchComponent, "CreditCards Search")} />
					<Route path={ClientRoutes.Currencies + "/create"} component={wrapperHeader(WrappedCurrencyCreateComponent, "Currencies Create")} />
                      <Route path={ClientRoutes.Currencies + "/edit/:id"} component={wrapperHeader(WrappedCurrencyEditComponent, "Currencies Edit")} />
                      <Route path={ClientRoutes.Currencies + "/:id"} component={wrapperHeader(WrappedCurrencyDetailComponent , "Currencies Detail")} />
                      <Route path={ClientRoutes.Currencies} component={wrapperHeader(WrappedCurrencySearchComponent, "Currencies Search")} />
					<Route path={ClientRoutes.CurrencyRates + "/create"} component={wrapperHeader(WrappedCurrencyRateCreateComponent, "CurrencyRates Create")} />
                      <Route path={ClientRoutes.CurrencyRates + "/edit/:id"} component={wrapperHeader(WrappedCurrencyRateEditComponent, "CurrencyRates Edit")} />
                      <Route path={ClientRoutes.CurrencyRates + "/:id"} component={wrapperHeader(WrappedCurrencyRateDetailComponent , "CurrencyRates Detail")} />
                      <Route path={ClientRoutes.CurrencyRates} component={wrapperHeader(WrappedCurrencyRateSearchComponent, "CurrencyRates Search")} />
					<Route path={ClientRoutes.Customers + "/create"} component={wrapperHeader(WrappedCustomerCreateComponent, "Customers Create")} />
                      <Route path={ClientRoutes.Customers + "/edit/:id"} component={wrapperHeader(WrappedCustomerEditComponent, "Customers Edit")} />
                      <Route path={ClientRoutes.Customers + "/:id"} component={wrapperHeader(WrappedCustomerDetailComponent , "Customers Detail")} />
                      <Route path={ClientRoutes.Customers} component={wrapperHeader(WrappedCustomerSearchComponent, "Customers Search")} />
					<Route path={ClientRoutes.SalesOrderHeaders + "/create"} component={wrapperHeader(WrappedSalesOrderHeaderCreateComponent, "SalesOrderHeaders Create")} />
                      <Route path={ClientRoutes.SalesOrderHeaders + "/edit/:id"} component={wrapperHeader(WrappedSalesOrderHeaderEditComponent, "SalesOrderHeaders Edit")} />
                      <Route path={ClientRoutes.SalesOrderHeaders + "/:id"} component={wrapperHeader(WrappedSalesOrderHeaderDetailComponent , "SalesOrderHeaders Detail")} />
                      <Route path={ClientRoutes.SalesOrderHeaders} component={wrapperHeader(WrappedSalesOrderHeaderSearchComponent, "SalesOrderHeaders Search")} />
					<Route path={ClientRoutes.SalesPersons + "/create"} component={wrapperHeader(WrappedSalesPersonCreateComponent, "SalesPersons Create")} />
                      <Route path={ClientRoutes.SalesPersons + "/edit/:id"} component={wrapperHeader(WrappedSalesPersonEditComponent, "SalesPersons Edit")} />
                      <Route path={ClientRoutes.SalesPersons + "/:id"} component={wrapperHeader(WrappedSalesPersonDetailComponent , "SalesPersons Detail")} />
                      <Route path={ClientRoutes.SalesPersons} component={wrapperHeader(WrappedSalesPersonSearchComponent, "SalesPersons Search")} />
					<Route path={ClientRoutes.SalesReasons + "/create"} component={wrapperHeader(WrappedSalesReasonCreateComponent, "SalesReasons Create")} />
                      <Route path={ClientRoutes.SalesReasons + "/edit/:id"} component={wrapperHeader(WrappedSalesReasonEditComponent, "SalesReasons Edit")} />
                      <Route path={ClientRoutes.SalesReasons + "/:id"} component={wrapperHeader(WrappedSalesReasonDetailComponent , "SalesReasons Detail")} />
                      <Route path={ClientRoutes.SalesReasons} component={wrapperHeader(WrappedSalesReasonSearchComponent, "SalesReasons Search")} />
					<Route path={ClientRoutes.SalesTaxRates + "/create"} component={wrapperHeader(WrappedSalesTaxRateCreateComponent, "SalesTaxRates Create")} />
                      <Route path={ClientRoutes.SalesTaxRates + "/edit/:id"} component={wrapperHeader(WrappedSalesTaxRateEditComponent, "SalesTaxRates Edit")} />
                      <Route path={ClientRoutes.SalesTaxRates + "/:id"} component={wrapperHeader(WrappedSalesTaxRateDetailComponent , "SalesTaxRates Detail")} />
                      <Route path={ClientRoutes.SalesTaxRates} component={wrapperHeader(WrappedSalesTaxRateSearchComponent, "SalesTaxRates Search")} />
					<Route path={ClientRoutes.SalesTerritories + "/create"} component={wrapperHeader(WrappedSalesTerritoryCreateComponent, "SalesTerritories Create")} />
                      <Route path={ClientRoutes.SalesTerritories + "/edit/:id"} component={wrapperHeader(WrappedSalesTerritoryEditComponent, "SalesTerritories Edit")} />
                      <Route path={ClientRoutes.SalesTerritories + "/:id"} component={wrapperHeader(WrappedSalesTerritoryDetailComponent , "SalesTerritories Detail")} />
                      <Route path={ClientRoutes.SalesTerritories} component={wrapperHeader(WrappedSalesTerritorySearchComponent, "SalesTerritories Search")} />
					<Route path={ClientRoutes.ShoppingCartItems + "/create"} component={wrapperHeader(WrappedShoppingCartItemCreateComponent, "ShoppingCartItems Create")} />
                      <Route path={ClientRoutes.ShoppingCartItems + "/edit/:id"} component={wrapperHeader(WrappedShoppingCartItemEditComponent, "ShoppingCartItems Edit")} />
                      <Route path={ClientRoutes.ShoppingCartItems + "/:id"} component={wrapperHeader(WrappedShoppingCartItemDetailComponent , "ShoppingCartItems Detail")} />
                      <Route path={ClientRoutes.ShoppingCartItems} component={wrapperHeader(WrappedShoppingCartItemSearchComponent, "ShoppingCartItems Search")} />
					<Route path={ClientRoutes.SpecialOffers + "/create"} component={wrapperHeader(WrappedSpecialOfferCreateComponent, "SpecialOffers Create")} />
                      <Route path={ClientRoutes.SpecialOffers + "/edit/:id"} component={wrapperHeader(WrappedSpecialOfferEditComponent, "SpecialOffers Edit")} />
                      <Route path={ClientRoutes.SpecialOffers + "/:id"} component={wrapperHeader(WrappedSpecialOfferDetailComponent , "SpecialOffers Detail")} />
                      <Route path={ClientRoutes.SpecialOffers} component={wrapperHeader(WrappedSpecialOfferSearchComponent, "SpecialOffers Search")} />
					<Route path={ClientRoutes.Stores + "/create"} component={wrapperHeader(WrappedStoreCreateComponent, "Stores Create")} />
                      <Route path={ClientRoutes.Stores + "/edit/:id"} component={wrapperHeader(WrappedStoreEditComponent, "Stores Edit")} />
                      <Route path={ClientRoutes.Stores + "/:id"} component={wrapperHeader(WrappedStoreDetailComponent , "Stores Detail")} />
                      <Route path={ClientRoutes.Stores} component={wrapperHeader(WrappedStoreSearchComponent, "Stores Search")} />
					        </Switch>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>fcea1cb906b7ba538bcfbce440f503a0</Hash>
</Codenesium>*/