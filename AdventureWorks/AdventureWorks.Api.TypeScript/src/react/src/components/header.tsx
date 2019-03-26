import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants, AuthClientRoutes } from '../constants';
import ErrorBoundary from './errorBoundary';
const { Header, Content, Footer, Sider } = Layout;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (
  Component: React.ComponentClass<any> | React.SFC<any>,
  displayName: string
) => {
  class WrapperHeaderComponent extends React.Component<
    WrapperHeaderProps & RouteComponentProps,
    WrapperHeaderState
  > {
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
              <Menu.Item
                key="Home"
                onClick={() => {
                  this.setState({ ...this.state, collapsed: true });
                }}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'} />
              </Menu.Item>

              <Menu.Item key="aWBuildVersion">
                <Icon type="pie-chart" />
                <span>A W Build Version</span>
                <Link to={ClientRoutes.AWBuildVersions} />
              </Menu.Item>

              <Menu.Item key="databaseLog">
                <Icon type="rise" />
                <span>Database Log</span>
                <Link to={ClientRoutes.DatabaseLogs} />
              </Menu.Item>

              <Menu.Item key="errorLog">
                <Icon type="bars" />
                <span>Error Log</span>
                <Link to={ClientRoutes.ErrorLogs} />
              </Menu.Item>

              <Menu.Item key="department">
                <Icon type="pie-chart" />
                <span>Department</span>
                <Link to={ClientRoutes.Departments} />
              </Menu.Item>

              <Menu.Item key="employee">
                <Icon type="rise" />
                <span>Employee</span>
                <Link to={ClientRoutes.Employees} />
              </Menu.Item>

              <Menu.Item key="jobCandidate">
                <Icon type="bars" />
                <span>Job Candidate</span>
                <Link to={ClientRoutes.JobCandidates} />
              </Menu.Item>

              <Menu.Item key="shift">
                <Icon type="cloud" />
                <span>Shift</span>
                <Link to={ClientRoutes.Shifts} />
              </Menu.Item>

              <Menu.Item key="address">
                <Icon type="pie-chart" />
                <span>Address</span>
                <Link to={ClientRoutes.Addresses} />
              </Menu.Item>

              <Menu.Item key="addressType">
                <Icon type="rise" />
                <span>Address Type</span>
                <Link to={ClientRoutes.AddressTypes} />
              </Menu.Item>

              <Menu.Item key="businessEntity">
                <Icon type="bars" />
                <span>Business Entity</span>
                <Link to={ClientRoutes.BusinessEntities} />
              </Menu.Item>

              <Menu.Item key="contactType">
                <Icon type="cloud" />
                <span>Contact Type</span>
                <Link to={ClientRoutes.ContactTypes} />
              </Menu.Item>

              <Menu.Item key="countryRegion">
                <Icon type="code" />
                <span>Country Region</span>
                <Link to={ClientRoutes.CountryRegions} />
              </Menu.Item>

              <Menu.Item key="password">
                <Icon type="smile" />
                <span>Password</span>
                <Link to={ClientRoutes.Passwords} />
              </Menu.Item>

              <Menu.Item key="person">
                <Icon type="laptop" />
                <span>Person</span>
                <Link to={ClientRoutes.People} />
              </Menu.Item>

              <Menu.Item key="phoneNumberType">
                <Icon type="mobile" />
                <span>Phone Number Type</span>
                <Link to={ClientRoutes.PhoneNumberTypes} />
              </Menu.Item>

              <Menu.Item key="stateProvince">
                <Icon type="paper-clip" />
                <span>State Province</span>
                <Link to={ClientRoutes.StateProvinces} />
              </Menu.Item>

              <Menu.Item key="billOfMaterial">
                <Icon type="pie-chart" />
                <span>Bill Of Materials</span>
                <Link to={ClientRoutes.BillOfMaterials} />
              </Menu.Item>

              <Menu.Item key="culture">
                <Icon type="rise" />
                <span>Culture</span>
                <Link to={ClientRoutes.Cultures} />
              </Menu.Item>

              <Menu.Item key="document">
                <Icon type="bars" />
                <span>Document</span>
                <Link to={ClientRoutes.Documents} />
              </Menu.Item>

              <Menu.Item key="illustration">
                <Icon type="cloud" />
                <span>Illustration</span>
                <Link to={ClientRoutes.Illustrations} />
              </Menu.Item>

              <Menu.Item key="location">
                <Icon type="code" />
                <span>Location</span>
                <Link to={ClientRoutes.Locations} />
              </Menu.Item>

              <Menu.Item key="product">
                <Icon type="smile" />
                <span>Product</span>
                <Link to={ClientRoutes.Products} />
              </Menu.Item>

              <Menu.Item key="productCategory">
                <Icon type="laptop" />
                <span>Product Category</span>
                <Link to={ClientRoutes.ProductCategories} />
              </Menu.Item>

              <Menu.Item key="productDescription">
                <Icon type="mobile" />
                <span>Product Description</span>
                <Link to={ClientRoutes.ProductDescriptions} />
              </Menu.Item>

              <Menu.Item key="productModel">
                <Icon type="paper-clip" />
                <span>Product Model</span>
                <Link to={ClientRoutes.ProductModels} />
              </Menu.Item>

              <Menu.Item key="productPhoto">
                <Icon type="setting" />
                <span>Product Photo</span>
                <Link to={ClientRoutes.ProductPhotoes} />
              </Menu.Item>

              <Menu.Item key="productProductPhoto">
                <Icon type="user" />
                <span>Product Product Photo</span>
                <Link to={ClientRoutes.ProductProductPhotoes} />
              </Menu.Item>

              <Menu.Item key="productReview">
                <Icon type="home" />
                <span>Product Review</span>
                <Link to={ClientRoutes.ProductReviews} />
              </Menu.Item>

              <Menu.Item key="productSubcategory">
                <Icon type="camera" />
                <span>Product Subcategory</span>
                <Link to={ClientRoutes.ProductSubcategories} />
              </Menu.Item>

              <Menu.Item key="scrapReason">
                <Icon type="like" />
                <span>Scrap Reason</span>
                <Link to={ClientRoutes.ScrapReasons} />
              </Menu.Item>

              <Menu.Item key="transactionHistory">
                <Icon type="bulb" />
                <span>Transaction History</span>
                <Link to={ClientRoutes.TransactionHistories} />
              </Menu.Item>

              <Menu.Item key="transactionHistoryArchive">
                <Icon type="tool" />
                <span>Transaction History Archive</span>
                <Link to={ClientRoutes.TransactionHistoryArchives} />
              </Menu.Item>

              <Menu.Item key="unitMeasure">
                <Icon type="coffee" />
                <span>Unit Measure</span>
                <Link to={ClientRoutes.UnitMeasures} />
              </Menu.Item>

              <Menu.Item key="workOrder">
                <Icon type="experiment" />
                <span>Work Order</span>
                <Link to={ClientRoutes.WorkOrders} />
              </Menu.Item>

              <Menu.Item key="purchaseOrderHeader">
                <Icon type="pie-chart" />
                <span>Purchase Order Header</span>
                <Link to={ClientRoutes.PurchaseOrderHeaders} />
              </Menu.Item>

              <Menu.Item key="shipMethod">
                <Icon type="rise" />
                <span>Ship Method</span>
                <Link to={ClientRoutes.ShipMethods} />
              </Menu.Item>

              <Menu.Item key="vendor">
                <Icon type="bars" />
                <span>Vendor</span>
                <Link to={ClientRoutes.Vendors} />
              </Menu.Item>

              <Menu.Item key="creditCard">
                <Icon type="pie-chart" />
                <span>Credit Card</span>
                <Link to={ClientRoutes.CreditCards} />
              </Menu.Item>

              <Menu.Item key="currency">
                <Icon type="rise" />
                <span>Currency</span>
                <Link to={ClientRoutes.Currencies} />
              </Menu.Item>

              <Menu.Item key="currencyRate">
                <Icon type="bars" />
                <span>Currency Rate</span>
                <Link to={ClientRoutes.CurrencyRates} />
              </Menu.Item>

              <Menu.Item key="customer">
                <Icon type="cloud" />
                <span>Customer</span>
                <Link to={ClientRoutes.Customers} />
              </Menu.Item>

              <Menu.Item key="salesOrderHeader">
                <Icon type="code" />
                <span>Sales Order Header</span>
                <Link to={ClientRoutes.SalesOrderHeaders} />
              </Menu.Item>

              <Menu.Item key="salesPerson">
                <Icon type="smile" />
                <span>Sales Person</span>
                <Link to={ClientRoutes.SalesPersons} />
              </Menu.Item>

              <Menu.Item key="salesReason">
                <Icon type="laptop" />
                <span>Sales Reason</span>
                <Link to={ClientRoutes.SalesReasons} />
              </Menu.Item>

              <Menu.Item key="salesTaxRate">
                <Icon type="mobile" />
                <span>Sales Tax Rate</span>
                <Link to={ClientRoutes.SalesTaxRates} />
              </Menu.Item>

              <Menu.Item key="salesTerritory">
                <Icon type="paper-clip" />
                <span>Sales Territory</span>
                <Link to={ClientRoutes.SalesTerritories} />
              </Menu.Item>

              <Menu.Item key="shoppingCartItem">
                <Icon type="setting" />
                <span>Shopping Cart Item</span>
                <Link to={ClientRoutes.ShoppingCartItems} />
              </Menu.Item>

              <Menu.Item key="specialOffer">
                <Icon type="user" />
                <span>Special Offer</span>
                <Link to={ClientRoutes.SpecialOffers} />
              </Menu.Item>

              <Menu.Item key="store">
                <Icon type="home" />
                <span>Store</span>
                <Link to={ClientRoutes.Stores} />
              </Menu.Item>

              <Menu.SubMenu
                title={
                  <span>
                    <Icon type="setting" />
                    <span>Settings</span>
                  </span>
                }
              >
                <Menu.Item key="lock">
                  <Icon type="lock" />
                  <span>Change Password</span>
                  <Link to={AuthClientRoutes.ChangePassword} />
                </Menu.Item>
                <Menu.Item key="logout">
                  <Icon type="logout" />
                  <span>Logout</span>
                  <Link to={AuthClientRoutes.Logout} />
                </Menu.Item>
              </Menu.SubMenu>
            </Menu>
          </Sider>
          <Layout>
            <Content style={{ margin: '0 16px' }}>
              <h2>{displayName}</h2>
              <div
                style={{ padding: 24, background: '#fff', minHeight: '600px' }}
              >
                <ErrorBoundary>
                  <Component {...this.props} />
                </ErrorBoundary>
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
    <Hash>b896e0b072c4c93c70c84e46792c0d7e</Hash>
</Codenesium>*/