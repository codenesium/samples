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

              <Menu.Item key="customer">
                <Icon type="pie-chart" />
                <span>Customer</span>
                <Link to={ClientRoutes.Customers} />
              </Menu.Item>

              <Menu.Item key="product">
                <Icon type="rise" />
                <span>Product</span>
                <Link to={ClientRoutes.Products} />
              </Menu.Item>

              <Menu.Item key="sale">
                <Icon type="bars" />
                <span>Sale</span>
                <Link to={ClientRoutes.Sales} />
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
                <Menu.Item key="mail">
                  <Icon type="mail" />
                  <span>Change Email</span>
                  <Link to={AuthClientRoutes.ChangeEmail} />
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
    <Hash>b41fbe6569cc0776fb42975d019dcba0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/