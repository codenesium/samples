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

              <Menu.Item key="directTweet">
                <Icon type="pie-chart" />
                <span>DirectTweets</span>
                <Link to={ClientRoutes.DirectTweets} />
              </Menu.Item>

              <Menu.Item key="follower">
                <Icon type="rise" />
                <span>Followers</span>
                <Link to={ClientRoutes.Followers} />
              </Menu.Item>

              <Menu.Item key="following">
                <Icon type="bars" />
                <span>Followings</span>
                <Link to={ClientRoutes.Followings} />
              </Menu.Item>

              <Menu.Item key="location">
                <Icon type="cloud" />
                <span>Locations</span>
                <Link to={ClientRoutes.Locations} />
              </Menu.Item>

              <Menu.Item key="message">
                <Icon type="code" />
                <span>Messages</span>
                <Link to={ClientRoutes.Messages} />
              </Menu.Item>

              <Menu.Item key="messenger">
                <Icon type="smile" />
                <span>Messengers</span>
                <Link to={ClientRoutes.Messengers} />
              </Menu.Item>

              <Menu.Item key="quoteTweet">
                <Icon type="laptop" />
                <span>QuoteTweets</span>
                <Link to={ClientRoutes.QuoteTweets} />
              </Menu.Item>

              <Menu.Item key="reply">
                <Icon type="mobile" />
                <span>Replies</span>
                <Link to={ClientRoutes.Replies} />
              </Menu.Item>

              <Menu.Item key="retweet">
                <Icon type="paper-clip" />
                <span>Retweets</span>
                <Link to={ClientRoutes.Retweets} />
              </Menu.Item>

              <Menu.Item key="tweet">
                <Icon type="setting" />
                <span>Tweets</span>
                <Link to={ClientRoutes.Tweets} />
              </Menu.Item>

              <Menu.Item key="user">
                <Icon type="user" />
                <span>Users</span>
                <Link to={ClientRoutes.Users} />
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
    <Hash>9e2e2b84253e8159d1d72957b52d8731</Hash>
</Codenesium>*/