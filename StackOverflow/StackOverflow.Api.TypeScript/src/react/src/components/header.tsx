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
                key="Home"
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'}>Home</Link>
              </MenuItem>

			   			   <MenuItem
                key="badge"
              >
			  <Icon type="pie-chart" />
              <span>Badges</span>
              <Link to={ClientRoutes.Badges}></Link>
              </MenuItem>

							   <MenuItem
                key="comment"
              >
			  <Icon type="rise" />
              <span>Comments</span>
              <Link to={ClientRoutes.Comments}></Link>
              </MenuItem>

							   <MenuItem
                key="linkType"
              >
			  <Icon type="bars" />
              <span>LinkTypes</span>
              <Link to={ClientRoutes.LinkTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="postHistory"
              >
			  <Icon type="cloud" />
              <span>PostHistories</span>
              <Link to={ClientRoutes.PostHistories}></Link>
              </MenuItem>

							   <MenuItem
                key="postHistoryType"
              >
			  <Icon type="code" />
              <span>PostHistoryTypes</span>
              <Link to={ClientRoutes.PostHistoryTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="postLink"
              >
			  <Icon type="smile" />
              <span>PostLinks</span>
              <Link to={ClientRoutes.PostLinks}></Link>
              </MenuItem>

							   <MenuItem
                key="post"
              >
			  <Icon type="laptop" />
              <span>Posts</span>
              <Link to={ClientRoutes.Posts}></Link>
              </MenuItem>

							   <MenuItem
                key="postType"
              >
			  <Icon type="mobile" />
              <span>PostTypes</span>
              <Link to={ClientRoutes.PostTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="tag"
              >
			  <Icon type="paper-clip" />
              <span>Tags</span>
              <Link to={ClientRoutes.Tags}></Link>
              </MenuItem>

							   <MenuItem
                key="user"
              >
			  <Icon type="setting" />
              <span>Users</span>
              <Link to={ClientRoutes.Users}></Link>
              </MenuItem>

							   <MenuItem
                key="vote"
              >
			  <Icon type="user" />
              <span>Votes</span>
              <Link to={ClientRoutes.Votes}></Link>
              </MenuItem>

							   <MenuItem
                key="voteType"
              >
			  <Icon type="home" />
              <span>VoteTypes</span>
              <Link to={ClientRoutes.VoteTypes}></Link>
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
    <Hash>af3ea7f8f06f1331637322bb538ffe03</Hash>
</Codenesium>*/