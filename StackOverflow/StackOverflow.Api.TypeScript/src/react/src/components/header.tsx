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

              <Menu.Item key="badge">
                <Icon type="pie-chart" />
                <span>Badges</span>
                <Link to={ClientRoutes.Badges} />
              </Menu.Item>

              <Menu.Item key="comment">
                <Icon type="rise" />
                <span>Comments</span>
                <Link to={ClientRoutes.Comments} />
              </Menu.Item>

              <Menu.Item key="linkType">
                <Icon type="bars" />
                <span>Link Types</span>
                <Link to={ClientRoutes.LinkTypes} />
              </Menu.Item>

              <Menu.Item key="postHistory">
                <Icon type="cloud" />
                <span>Post History</span>
                <Link to={ClientRoutes.PostHistories} />
              </Menu.Item>

              <Menu.Item key="postHistoryType">
                <Icon type="code" />
                <span>Post History Types</span>
                <Link to={ClientRoutes.PostHistoryTypes} />
              </Menu.Item>

              <Menu.Item key="postLink">
                <Icon type="smile" />
                <span>Post Links</span>
                <Link to={ClientRoutes.PostLinks} />
              </Menu.Item>

              <Menu.Item key="post">
                <Icon type="laptop" />
                <span>Posts</span>
                <Link to={ClientRoutes.Posts} />
              </Menu.Item>

              <Menu.Item key="postType">
                <Icon type="mobile" />
                <span>Post Types</span>
                <Link to={ClientRoutes.PostTypes} />
              </Menu.Item>

              <Menu.Item key="tag">
                <Icon type="paper-clip" />
                <span>Tags</span>
                <Link to={ClientRoutes.Tags} />
              </Menu.Item>

              <Menu.Item key="user">
                <Icon type="setting" />
                <span>Users</span>
                <Link to={ClientRoutes.Users} />
              </Menu.Item>

              <Menu.Item key="vote">
                <Icon type="user" />
                <span>Votes</span>
                <Link to={ClientRoutes.Votes} />
              </Menu.Item>

              <Menu.Item key="voteType">
                <Icon type="home" />
                <span>Vote Types</span>
                <Link to={ClientRoutes.VoteTypes} />
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
    <Hash>2e8a1fa5ec87a3617c1a2346853952c8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/