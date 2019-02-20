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
export const wrapperHeader = (Component: React.ComponentClass<any> | React.SFC<any>) => {
  class WrapperHeaderComponent extends React.Component<WrapperHeaderProps & RouteComponentProps, WrapperHeaderState> {
    state = { collapsed: false };

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
                key="Dashboard"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Dashboard</span>
                  </span>
                }
              >
              <Link to={"/"}>Dashboard</Link>
              </MenuItem>

			   			   <MenuItem
                key="admin"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Admin</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Admins}>Admins</Link>
              </MenuItem>

							   <MenuItem
                key="city"
                title={
                  <span>
                    <Icon type="user" />
                    <span>City</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Cities}>Cities</Link>
              </MenuItem>

							   <MenuItem
                key="country"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Country</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Countries}>Countries</Link>
              </MenuItem>

							   <MenuItem
                key="customer"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Customer</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Customers}>Customers</Link>
              </MenuItem>

							   <MenuItem
                key="event"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Event</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Events}>Events</Link>
              </MenuItem>

							   <MenuItem
                key="province"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Province</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Provinces}>Provinces</Link>
              </MenuItem>

							   <MenuItem
                key="sale"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Sale</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Sales}>Sales</Link>
              </MenuItem>

							   <MenuItem
                key="saleTicket"
                title={
                  <span>
                    <Icon type="user" />
                    <span>SaleTicket</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.SaleTickets}>SaleTickets</Link>
              </MenuItem>

							   <MenuItem
                key="ticket"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Ticket</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Tickets}>Tickets</Link>
              </MenuItem>

							   <MenuItem
                key="ticketStatus"
                title={
                  <span>
                    <Icon type="user" />
                    <span>TicketStatus</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.TicketStatus}>TicketStatus</Link>
              </MenuItem>

							   <MenuItem
                key="transaction"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Transaction</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Transactions}>Transactions</Link>
              </MenuItem>

							   <MenuItem
                key="transactionStatus"
                title={
                  <span>
                    <Icon type="user" />
                    <span>TransactionStatus</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.TransactionStatus}>TransactionStatus</Link>
              </MenuItem>

							   <MenuItem
                key="venue"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Venue</span>
                  </span>
                }
              >
              <Link to={ClientRoutes.Venues}>Venues</Link>
              </MenuItem>

				
            </Menu>
          </Sider>
          <Layout>
            <Header style={{ background: '#fff', padding: 0 }} />
            <Content style={{ margin: '0 16px' }}>
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
    <Hash>4a85490a75804d7bee75368c33c0350d</Hash>
</Codenesium>*/