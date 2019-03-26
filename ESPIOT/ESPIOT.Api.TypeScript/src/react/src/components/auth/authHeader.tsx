import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants, AuthClientRoutes } from '../../constants';
import ErrorBoundary from '../errorBoundary';
const { Header, Content, Footer, Sider } = Layout;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperAuthHeader = (
  Component: React.ComponentClass<any> | React.SFC<any>,
  displayName: string
) => {
  class AuthHeaderComponent extends React.Component<
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
            <div className='logo' />
            <Menu theme='dark' defaultSelectedKeys={['1']} mode='inline'>
                <Menu.Item key='login'>
                  <Icon type='lock' />
                  <span>Log in</span>
                  <Link to={AuthClientRoutes.Login} />
                </Menu.Item>

                <Menu.Item key='register'>
                  <Icon type='mail' />
                  <span>Register</span>
                  <Link to={AuthClientRoutes.Register} />
                </Menu.Item>

                <Menu.Item key='resetpassword'>
                  <Icon type='rocket' />
                  <span>Reset Password</span>
                  <Link to={AuthClientRoutes.ResetPassword} />
                </Menu.Item>
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
  return AuthHeaderComponent;
};