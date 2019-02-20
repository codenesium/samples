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
              <MenuItem
                key="Dashboard"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Dashboard</span>
                  </span>
                }
              >
                <Link to={'/'}>Dashboard</Link>
              </MenuItem>

              <MenuItem
                key="badge"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Badge</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Badges}>Badges</Link>
              </MenuItem>

              <MenuItem
                key="comment"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Comment</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Comments}>Comments</Link>
              </MenuItem>

              <MenuItem
                key="linkType"
                title={
                  <span>
                    <Icon type="user" />
                    <span>LinkType</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.LinkTypes}>LinkTypes</Link>
              </MenuItem>

              <MenuItem
                key="postHistory"
                title={
                  <span>
                    <Icon type="user" />
                    <span>PostHistory</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.PostHistories}>PostHistories</Link>
              </MenuItem>

              <MenuItem
                key="postHistoryType"
                title={
                  <span>
                    <Icon type="user" />
                    <span>PostHistoryType</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.PostHistoryTypes}>PostHistoryTypes</Link>
              </MenuItem>

              <MenuItem
                key="postLink"
                title={
                  <span>
                    <Icon type="user" />
                    <span>PostLink</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.PostLinks}>PostLinks</Link>
              </MenuItem>

              <MenuItem
                key="post"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Post</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Posts}>Posts</Link>
              </MenuItem>

              <MenuItem
                key="postType"
                title={
                  <span>
                    <Icon type="user" />
                    <span>PostType</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.PostTypes}>PostTypes</Link>
              </MenuItem>

              <MenuItem
                key="tag"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Tag</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Tags}>Tags</Link>
              </MenuItem>

              <MenuItem
                key="user"
                title={
                  <span>
                    <Icon type="user" />
                    <span>User</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Users}>Users</Link>
              </MenuItem>

              <MenuItem
                key="vote"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Vote</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Votes}>Votes</Link>
              </MenuItem>

              <MenuItem
                key="voteType"
                title={
                  <span>
                    <Icon type="user" />
                    <span>VoteType</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.VoteTypes}>VoteTypes</Link>
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
    <Hash>3be2141e6e8f66309cbae9854a71a053</Hash>
</Codenesium>*/