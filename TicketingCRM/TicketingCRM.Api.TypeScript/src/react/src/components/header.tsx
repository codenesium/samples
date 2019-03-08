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
                key="admin"
              >
			  <Icon type="pie-chart" />
              <span>Admins</span>
              <Link to={ClientRoutes.Admins}></Link>
              </MenuItem>

							   <MenuItem
                key="city"
              >
			  <Icon type="rise" />
              <span>Cities</span>
              <Link to={ClientRoutes.Cities}></Link>
              </MenuItem>

							   <MenuItem
                key="country"
              >
			  <Icon type="bars" />
              <span>Countries</span>
              <Link to={ClientRoutes.Countries}></Link>
              </MenuItem>

							   <MenuItem
                key="customer"
              >
			  <Icon type="cloud" />
              <span>Customers</span>
              <Link to={ClientRoutes.Customers}></Link>
              </MenuItem>

							   <MenuItem
                key="event"
              >
			  <Icon type="code" />
              <span>Events</span>
              <Link to={ClientRoutes.Events}></Link>
              </MenuItem>

							   <MenuItem
                key="province"
              >
			  <Icon type="smile" />
              <span>Provinces</span>
              <Link to={ClientRoutes.Provinces}></Link>
              </MenuItem>

							   <MenuItem
                key="sale"
              >
			  <Icon type="laptop" />
              <span>Sales</span>
              <Link to={ClientRoutes.Sales}></Link>
              </MenuItem>

							   <MenuItem
                key="saleTicket"
              >
			  <Icon type="mobile" />
              <span>Sale Tickets</span>
              <Link to={ClientRoutes.SaleTickets}></Link>
              </MenuItem>

							   <MenuItem
                key="ticket"
              >
			  <Icon type="paper-clip" />
              <span>Tickets</span>
              <Link to={ClientRoutes.Tickets}></Link>
              </MenuItem>

							   <MenuItem
                key="ticketStatus"
              >
			  <Icon type="setting" />
              <span>Ticket Status</span>
              <Link to={ClientRoutes.TicketStatus}></Link>
              </MenuItem>

							   <MenuItem
                key="transaction"
              >
			  <Icon type="user" />
              <span>Transactions</span>
              <Link to={ClientRoutes.Transactions}></Link>
              </MenuItem>

							   <MenuItem
                key="transactionStatus"
              >
			  <Icon type="home" />
              <span>Transaction Status</span>
              <Link to={ClientRoutes.TransactionStatus}></Link>
              </MenuItem>

							   <MenuItem
                key="venue"
              >
			  <Icon type="camera" />
              <span>Venues</span>
              <Link to={ClientRoutes.Venues}></Link>
              </MenuItem>

				
            </Menu>
          </Sider>
          <Layout>
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
    <Hash>dfb7d701e490961afc14546433be2b28</Hash>
</Codenesium>*/