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

              <Menu.Item key="admin">
                <Icon type="pie-chart" />
                <span>Admins</span>
                <Link to={ClientRoutes.Admins} />
              </Menu.Item>

              <Menu.Item key="city">
                <Icon type="rise" />
                <span>Cities</span>
                <Link to={ClientRoutes.Cities} />
              </Menu.Item>

              <Menu.Item key="country">
                <Icon type="bars" />
                <span>Countries</span>
                <Link to={ClientRoutes.Countries} />
              </Menu.Item>

              <Menu.Item key="customer">
                <Icon type="cloud" />
                <span>Customers</span>
                <Link to={ClientRoutes.Customers} />
              </Menu.Item>

              <Menu.Item key="event">
                <Icon type="code" />
                <span>Events</span>
                <Link to={ClientRoutes.Events} />
              </Menu.Item>

              <Menu.Item key="province">
                <Icon type="smile" />
                <span>Provinces</span>
                <Link to={ClientRoutes.Provinces} />
              </Menu.Item>

              <Menu.Item key="sale">
                <Icon type="laptop" />
                <span>Sales</span>
                <Link to={ClientRoutes.Sales} />
              </Menu.Item>

              <Menu.Item key="saleTicket">
                <Icon type="mobile" />
                <span>Sale Tickets</span>
                <Link to={ClientRoutes.SaleTickets} />
              </Menu.Item>

              <Menu.Item key="ticket">
                <Icon type="paper-clip" />
                <span>Tickets</span>
                <Link to={ClientRoutes.Tickets} />
              </Menu.Item>

              <Menu.Item key="ticketStatus">
                <Icon type="setting" />
                <span>Ticket Status</span>
                <Link to={ClientRoutes.TicketStatus} />
              </Menu.Item>

              <Menu.Item key="transaction">
                <Icon type="user" />
                <span>Transactions</span>
                <Link to={ClientRoutes.Transactions} />
              </Menu.Item>

              <Menu.Item key="transactionStatus">
                <Icon type="home" />
                <span>Transaction Status</span>
                <Link to={ClientRoutes.TransactionStatus} />
              </Menu.Item>

              <Menu.Item key="venue">
                <Icon type="camera" />
                <span>Venues</span>
                <Link to={ClientRoutes.Venues} />
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
    <Hash>bedf9b39aa635205d0d4aaa1ba2e3ca2</Hash>
</Codenesium>*/