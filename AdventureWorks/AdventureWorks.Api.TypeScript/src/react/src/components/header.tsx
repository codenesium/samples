import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import MenuItem from '../../node_modules/antd/lib/menu/MenuItem';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants } from '../constants';
const { Header, Content, Footer, Sider } = Layout;

const SubMenu = Menu.SubMenu;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (Component: React.ComponentClass<any> | React.SFC<any>,
displayName:string) => {
  class WrapperHeaderComponent extends React.Component<WrapperHeaderProps & RouteComponentProps, WrapperHeaderState> {
    state = { collapsed: true };

    onCollapse = () => {
      this.setState({ ...this.state, collapsed: !this.state.collapsed });
    };
    render() {
      return (
        <Layout style={{ minHeight: '100vh' }}>
          <Sider
            collapsible
            collapsed={this.state.collapsed}
            onCollapse={this.onCollapse}
          >
            <div className="logo" />
            <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
               <MenuItem
                key="Home"
				onClick={() =>  {this.setState({...this.state, collapsed:true})}}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'}></Link>
              </MenuItem>

			   			   <MenuItem
                key="aWBuildVersion"
              >
			  <Icon type="pie-chart" />
              <span>AWBuildVersions</span>
              <Link to={ClientRoutes.AWBuildVersions}></Link>
              </MenuItem>

							   <MenuItem
                key="databaseLog"
              >
			  <Icon type="rise" />
              <span>DatabaseLogs</span>
              <Link to={ClientRoutes.DatabaseLogs}></Link>
              </MenuItem>

							   <MenuItem
                key="errorLog"
              >
			  <Icon type="bars" />
              <span>ErrorLogs</span>
              <Link to={ClientRoutes.ErrorLogs}></Link>
              </MenuItem>

							   <MenuItem
                key="department"
              >
			  <Icon type="pie-chart" />
              <span>Departments</span>
              <Link to={ClientRoutes.Departments}></Link>
              </MenuItem>

							   <MenuItem
                key="employee"
              >
			  <Icon type="rise" />
              <span>Employees</span>
              <Link to={ClientRoutes.Employees}></Link>
              </MenuItem>

							   <MenuItem
                key="jobCandidate"
              >
			  <Icon type="bars" />
              <span>JobCandidates</span>
              <Link to={ClientRoutes.JobCandidates}></Link>
              </MenuItem>

							   <MenuItem
                key="shift"
              >
			  <Icon type="cloud" />
              <span>Shifts</span>
              <Link to={ClientRoutes.Shifts}></Link>
              </MenuItem>

							   <MenuItem
                key="address"
              >
			  <Icon type="pie-chart" />
              <span>Addresses</span>
              <Link to={ClientRoutes.Addresses}></Link>
              </MenuItem>

							   <MenuItem
                key="addressType"
              >
			  <Icon type="rise" />
              <span>AddressTypes</span>
              <Link to={ClientRoutes.AddressTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="businessEntity"
              >
			  <Icon type="bars" />
              <span>BusinessEntities</span>
              <Link to={ClientRoutes.BusinessEntities}></Link>
              </MenuItem>

							   <MenuItem
                key="contactType"
              >
			  <Icon type="cloud" />
              <span>ContactTypes</span>
              <Link to={ClientRoutes.ContactTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="countryRegion"
              >
			  <Icon type="code" />
              <span>CountryRegions</span>
              <Link to={ClientRoutes.CountryRegions}></Link>
              </MenuItem>

							   <MenuItem
                key="password"
              >
			  <Icon type="smile" />
              <span>Passwords</span>
              <Link to={ClientRoutes.Passwords}></Link>
              </MenuItem>

							   <MenuItem
                key="person"
              >
			  <Icon type="laptop" />
              <span>People</span>
              <Link to={ClientRoutes.People}></Link>
              </MenuItem>

							   <MenuItem
                key="phoneNumberType"
              >
			  <Icon type="mobile" />
              <span>PhoneNumberTypes</span>
              <Link to={ClientRoutes.PhoneNumberTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="stateProvince"
              >
			  <Icon type="paper-clip" />
              <span>StateProvinces</span>
              <Link to={ClientRoutes.StateProvinces}></Link>
              </MenuItem>

							   <MenuItem
                key="billOfMaterial"
              >
			  <Icon type="pie-chart" />
              <span>BillOfMaterials</span>
              <Link to={ClientRoutes.BillOfMaterials}></Link>
              </MenuItem>

							   <MenuItem
                key="culture"
              >
			  <Icon type="rise" />
              <span>Cultures</span>
              <Link to={ClientRoutes.Cultures}></Link>
              </MenuItem>

							   <MenuItem
                key="document"
              >
			  <Icon type="bars" />
              <span>Documents</span>
              <Link to={ClientRoutes.Documents}></Link>
              </MenuItem>

							   <MenuItem
                key="illustration"
              >
			  <Icon type="cloud" />
              <span>Illustrations</span>
              <Link to={ClientRoutes.Illustrations}></Link>
              </MenuItem>

							   <MenuItem
                key="location"
              >
			  <Icon type="code" />
              <span>Locations</span>
              <Link to={ClientRoutes.Locations}></Link>
              </MenuItem>

							   <MenuItem
                key="product"
              >
			  <Icon type="smile" />
              <span>Products</span>
              <Link to={ClientRoutes.Products}></Link>
              </MenuItem>

							   <MenuItem
                key="productCategory"
              >
			  <Icon type="laptop" />
              <span>ProductCategories</span>
              <Link to={ClientRoutes.ProductCategories}></Link>
              </MenuItem>

							   <MenuItem
                key="productDescription"
              >
			  <Icon type="mobile" />
              <span>ProductDescriptions</span>
              <Link to={ClientRoutes.ProductDescriptions}></Link>
              </MenuItem>

							   <MenuItem
                key="productModel"
              >
			  <Icon type="paper-clip" />
              <span>ProductModels</span>
              <Link to={ClientRoutes.ProductModels}></Link>
              </MenuItem>

							   <MenuItem
                key="productPhoto"
              >
			  <Icon type="setting" />
              <span>ProductPhotoes</span>
              <Link to={ClientRoutes.ProductPhotoes}></Link>
              </MenuItem>

							   <MenuItem
                key="productReview"
              >
			  <Icon type="user" />
              <span>ProductReviews</span>
              <Link to={ClientRoutes.ProductReviews}></Link>
              </MenuItem>

							   <MenuItem
                key="productSubcategory"
              >
			  <Icon type="home" />
              <span>ProductSubcategories</span>
              <Link to={ClientRoutes.ProductSubcategories}></Link>
              </MenuItem>

							   <MenuItem
                key="scrapReason"
              >
			  <Icon type="camera" />
              <span>ScrapReasons</span>
              <Link to={ClientRoutes.ScrapReasons}></Link>
              </MenuItem>

							   <MenuItem
                key="transactionHistory"
              >
			  <Icon type="like" />
              <span>TransactionHistories</span>
              <Link to={ClientRoutes.TransactionHistories}></Link>
              </MenuItem>

							   <MenuItem
                key="transactionHistoryArchive"
              >
			  <Icon type="bulb" />
              <span>TransactionHistoryArchives</span>
              <Link to={ClientRoutes.TransactionHistoryArchives}></Link>
              </MenuItem>

							   <MenuItem
                key="unitMeasure"
              >
			  <Icon type="tool" />
              <span>UnitMeasures</span>
              <Link to={ClientRoutes.UnitMeasures}></Link>
              </MenuItem>

							   <MenuItem
                key="workOrder"
              >
			  <Icon type="coffee" />
              <span>WorkOrders</span>
              <Link to={ClientRoutes.WorkOrders}></Link>
              </MenuItem>

							   <MenuItem
                key="purchaseOrderHeader"
              >
			  <Icon type="pie-chart" />
              <span>PurchaseOrderHeaders</span>
              <Link to={ClientRoutes.PurchaseOrderHeaders}></Link>
              </MenuItem>

							   <MenuItem
                key="shipMethod"
              >
			  <Icon type="rise" />
              <span>ShipMethods</span>
              <Link to={ClientRoutes.ShipMethods}></Link>
              </MenuItem>

							   <MenuItem
                key="vendor"
              >
			  <Icon type="bars" />
              <span>Vendors</span>
              <Link to={ClientRoutes.Vendors}></Link>
              </MenuItem>

							   <MenuItem
                key="creditCard"
              >
			  <Icon type="pie-chart" />
              <span>CreditCards</span>
              <Link to={ClientRoutes.CreditCards}></Link>
              </MenuItem>

							   <MenuItem
                key="currency"
              >
			  <Icon type="rise" />
              <span>Currencies</span>
              <Link to={ClientRoutes.Currencies}></Link>
              </MenuItem>

							   <MenuItem
                key="currencyRate"
              >
			  <Icon type="bars" />
              <span>CurrencyRates</span>
              <Link to={ClientRoutes.CurrencyRates}></Link>
              </MenuItem>

							   <MenuItem
                key="customer"
              >
			  <Icon type="cloud" />
              <span>Customers</span>
              <Link to={ClientRoutes.Customers}></Link>
              </MenuItem>

							   <MenuItem
                key="salesOrderHeader"
              >
			  <Icon type="code" />
              <span>SalesOrderHeaders</span>
              <Link to={ClientRoutes.SalesOrderHeaders}></Link>
              </MenuItem>

							   <MenuItem
                key="salesPerson"
              >
			  <Icon type="smile" />
              <span>SalesPersons</span>
              <Link to={ClientRoutes.SalesPersons}></Link>
              </MenuItem>

							   <MenuItem
                key="salesReason"
              >
			  <Icon type="laptop" />
              <span>SalesReasons</span>
              <Link to={ClientRoutes.SalesReasons}></Link>
              </MenuItem>

							   <MenuItem
                key="salesTaxRate"
              >
			  <Icon type="mobile" />
              <span>SalesTaxRates</span>
              <Link to={ClientRoutes.SalesTaxRates}></Link>
              </MenuItem>

							   <MenuItem
                key="salesTerritory"
              >
			  <Icon type="paper-clip" />
              <span>SalesTerritories</span>
              <Link to={ClientRoutes.SalesTerritories}></Link>
              </MenuItem>

							   <MenuItem
                key="shoppingCartItem"
              >
			  <Icon type="setting" />
              <span>ShoppingCartItems</span>
              <Link to={ClientRoutes.ShoppingCartItems}></Link>
              </MenuItem>

							   <MenuItem
                key="specialOffer"
              >
			  <Icon type="user" />
              <span>SpecialOffers</span>
              <Link to={ClientRoutes.SpecialOffers}></Link>
              </MenuItem>

							   <MenuItem
                key="store"
              >
			  <Icon type="home" />
              <span>Stores</span>
              <Link to={ClientRoutes.Stores}></Link>
              </MenuItem>

				
            </Menu>
          </Sider>
          <Layout>
            <Header style={{ background: '#fff', padding: 0 }} />
            <Content style={{ margin: '0 16px' }}>
            <h2>{displayName}</h2>
			  <div style={{ padding: 24, background: '#fff', minHeight: 360 }}>
                <Component {...this.props} />
              </div>
            </Content>
            <Footer style={{ textAlign: 'center' }}>Footer</Footer>
          </Layout>
        </Layout>
      );
    }
  }
  return WrapperHeaderComponent;
};

/*<Codenesium>
    <Hash>bf5829500353704528d1202b7b247bdd</Hash>
</Codenesium>*/