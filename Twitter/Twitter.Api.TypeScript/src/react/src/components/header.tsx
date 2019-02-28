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
              <MenuItem
                key="Home"
                onClick={() => {
                  this.setState({ ...this.state, collapsed: true });
                }}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'} />
              </MenuItem>

              <MenuItem key="directTweet">
                <Icon type="pie-chart" />
                <span>DirectTweets</span>
                <Link to={ClientRoutes.DirectTweets} />
              </MenuItem>

              <MenuItem key="follower">
                <Icon type="rise" />
                <span>Followers</span>
                <Link to={ClientRoutes.Followers} />
              </MenuItem>

              <MenuItem key="following">
                <Icon type="bars" />
                <span>Followings</span>
                <Link to={ClientRoutes.Followings} />
              </MenuItem>

              <MenuItem key="location">
                <Icon type="cloud" />
                <span>Locations</span>
                <Link to={ClientRoutes.Locations} />
              </MenuItem>

              <MenuItem key="message">
                <Icon type="code" />
                <span>Messages</span>
                <Link to={ClientRoutes.Messages} />
              </MenuItem>

              <MenuItem key="messenger">
                <Icon type="smile" />
                <span>Messengers</span>
                <Link to={ClientRoutes.Messengers} />
              </MenuItem>

              <MenuItem key="quoteTweet">
                <Icon type="laptop" />
                <span>QuoteTweets</span>
                <Link to={ClientRoutes.QuoteTweets} />
              </MenuItem>

              <MenuItem key="reply">
                <Icon type="mobile" />
                <span>Replies</span>
                <Link to={ClientRoutes.Replies} />
              </MenuItem>

              <MenuItem key="retweet">
                <Icon type="paper-clip" />
                <span>Retweets</span>
                <Link to={ClientRoutes.Retweets} />
              </MenuItem>

              <MenuItem key="tweet">
                <Icon type="setting" />
                <span>Tweets</span>
                <Link to={ClientRoutes.Tweets} />
              </MenuItem>

              <MenuItem key="user">
                <Icon type="user" />
                <span>Users</span>
                <Link to={ClientRoutes.Users} />
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
    <Hash>1ffb732b418ae25b48518693a7549d11</Hash>
</Codenesium>*/