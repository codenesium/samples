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
export const wrapperHeader = (
  Component: React.ComponentClass<any> | React.SFC<any>
) => {
  class WrapperHeaderComponent extends React.Component<
    WrapperHeaderProps & RouteComponentProps,
    WrapperHeaderState
  > {
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
              <MenuItem key="Home">
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'}>Home</Link>
              </MenuItem>

              <MenuItem key="admin">
                <Icon type="pie-chart" />
                <span>Admins</span>
                <Link to={ClientRoutes.Admins} />
              </MenuItem>

              <MenuItem key="city">
                <Icon type="rise" />
                <span>Cities</span>
                <Link to={ClientRoutes.Cities} />
              </MenuItem>

              <MenuItem key="country">
                <Icon type="bars" />
                <span>Countries</span>
                <Link to={ClientRoutes.Countries} />
              </MenuItem>

              <MenuItem key="customer">
                <Icon type="cloud" />
                <span>Customers</span>
                <Link to={ClientRoutes.Customers} />
              </MenuItem>

              <MenuItem key="event">
                <Icon type="code" />
                <span>Events</span>
                <Link to={ClientRoutes.Events} />
              </MenuItem>

              <MenuItem key="province">
                <Icon type="smile" />
                <span>Provinces</span>
                <Link to={ClientRoutes.Provinces} />
              </MenuItem>

              <MenuItem key="sale">
                <Icon type="laptop" />
                <span>Sales</span>
                <Link to={ClientRoutes.Sales} />
              </MenuItem>

              <MenuItem key="saleTicket">
                <Icon type="mobile" />
                <span>SaleTickets</span>
                <Link to={ClientRoutes.SaleTickets} />
              </MenuItem>

              <MenuItem key="ticket">
                <Icon type="paper-clip" />
                <span>Tickets</span>
                <Link to={ClientRoutes.Tickets} />
              </MenuItem>

              <MenuItem key="ticketStatus">
                <Icon type="setting" />
                <span>TicketStatus</span>
                <Link to={ClientRoutes.TicketStatus} />
              </MenuItem>

              <MenuItem key="transaction">
                <Icon type="user" />
                <span>Transactions</span>
                <Link to={ClientRoutes.Transactions} />
              </MenuItem>

              <MenuItem key="transactionStatus">
                <Icon type="home" />
                <span>TransactionStatus</span>
                <Link to={ClientRoutes.TransactionStatus} />
              </MenuItem>

              <MenuItem key="venue">
                <Icon type="camera" />
                <span>Venues</span>
                <Link to={ClientRoutes.Venues} />
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
    <Hash>5dfd5b7bcc36c5e0ed6f000d6662e392</Hash>
</Codenesium>*/